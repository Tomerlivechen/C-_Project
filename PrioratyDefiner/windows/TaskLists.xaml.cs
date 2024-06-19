using Common_Classes;
using PrioratyDefiner;
using PriorityDefiner.windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PriorityDefiner.Classes;
using Common_Classes.Classes;
namespace PriorityDefiner
{
    /// <summary>
    /// Interaction logic for TaskLists.xaml
    /// </summary>
    public partial class TaskLists : Window, INotifyPropertyChanged
    {
        ObservableCollection<MyTaskList> listOfTaskLists = new ObservableCollection<MyTaskList>();
        private ObservableCollection<MyTaskList> ListOfTaskLists
        {
            get => listOfTaskLists;
            set
            {
                listOfTaskLists = value;
                OnPropertyChanged(nameof(listOfTaskLists));
            }
        }
        ICollectionView TaskSetsView;
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public TaskLists()
        {
            InitializeComponent();
            GlobalVars.LoadTaks();
            GlobalVars.SortMyTaskList();
            Activated += Window_Activated;
            Closed += Window_Closed;
            TaskSetsView = CollectionViewSource.GetDefaultView(listOfTaskLists);
            TaskDataGrid.ItemsSource = TaskSetsView;
            updateLists();
        }
        private void Handle_Delete(object sender, RoutedEventArgs e)
        {
            MyTaskList Selectd_List = TaskDataGrid.SelectedItem as MyTaskList;
            Delete_item(Selectd_List);
            liveupdate();
        }
        public void Delete_item(MyTaskList Selectd_List)
        {
            int respons = Message_Box_Classes.DisplayMessageBox("Are you sure you want to delete this task list?", "Deleting task list");
            if (respons == 1)
            {
                List<MyTaskList> TasklistsDataGrid = TaskSetsView.SourceCollection.Cast<MyTaskList>().ToList();
                MyTaskList taskListToRemove = TasklistsDataGrid.FirstOrDefault(item => item.TaskListName == Selectd_List.TaskListName);
                if (taskListToRemove != null)
                {
                    GlobalVars.change++;
                    TasklistsDataGrid.Remove(taskListToRemove);
                    TaskSetsView = CollectionViewSource.GetDefaultView(TasklistsDataGrid);
                    TaskSetsView.Refresh();
                    TaskDataGrid.ItemsSource = TaskSetsView;
                    
                }
            }
        }
        private void Handle_Compleat(object sender, RoutedEventArgs e)
        {
            
            MyTaskList Selectd_List = TaskDataGrid.SelectedItem as MyTaskList;
            Selectd_List.CheckComplete();
            if (Selectd_List.incomplete == true)
            {
                int respons = Message_Box_Classes.DisplayMessageBox("Not all tasks are compleat, are you sure you want to sure you want to set them to complete?", "Not all taks compleat");
                if (respons == 1)
                {
                    Selectd_List.Task_List.ForEach(task => task.done = true);
                    Selectd_List.CheckComplete();
                    GlobalVars.change++;
                }
                else { return; }
            }
            liveupdate();
            updateLists();
            TaskSetsView.Refresh();
        }
        private void Handle_Update(object sender, RoutedEventArgs e)
        {
            MyTaskList Selectd_MyTaskList = TaskDataGrid.SelectedItem as MyTaskList;
            Show_list Showlist = new Show_list(Selectd_MyTaskList);
            bool? dialogResult=Showlist.ShowDialog();
            if (dialogResult == true)
            {
                Selectd_MyTaskList.CheckComplete();
                updateLists();
                liveupdate();
            }
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            updateLists();
        }
        public void updateLists()
        {
            ListOfTaskLists.Clear();
            foreach (MyTaskList tasklist in GlobalVars.allTaskLists.listOfLists)
            {
                tasklist.CheckComplete();
                ListOfTaskLists.Add(tasklist);
            }
            TaskSetsView.Refresh();
        }
        public void liveupdate()
        {
            List<MyTaskList> NewTaskLists = new List<MyTaskList>();
            List<MyTaskList> TasklistsDataGrid = TaskSetsView.SourceCollection.Cast<MyTaskList>().ToList();
            foreach (MyTaskList tasklist in TasklistsDataGrid)
            {
                NewTaskLists.Add(tasklist);
            }
            ListOfTaskLists.Clear();
            foreach (MyTaskList tasklist in NewTaskLists)
            {
                ListOfTaskLists.Add(tasklist);
            }
            GlobalVars.replaceTaskLists(NewTaskLists);
            GlobalVars.SortMyTaskList();
            TaskSetsView.Refresh();
        }
        private void AddTasklist_Click(object sender, RoutedEventArgs e)
        {
            GlobalVars.change++;
            ListCreation newlist = new ListCreation();
            newlist.Show();
            updateLists();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            liveupdate();
            GlobalVars.SaveTasklists();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            if (GlobalVars.change > 0)
            {
                int respons = Message_Box_Classes.DisplayMessageBox("Save before closeing?", "Close");
                if (respons == 1)
                {
                    liveupdate();
                    GlobalVars.SaveTasklists();
                }
                else { return; }
            }
        }

        private void New_List_Button_Click(object sender, RoutedEventArgs e)
        {
            AddTasklist_Click(sender, e);
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            Save_Click(sender, e);
        }
    }
}