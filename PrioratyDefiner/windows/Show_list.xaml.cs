using Common_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
namespace PriorityDefiner.windows
{
    /// <summary>
    /// Interaction logic for Show_list.xaml
    /// </summary>
    public partial class Show_list : Window
    {
        public string listName { get; set; }
        public string listNameShort { get; set; }
        ICollectionView TaskSetsView;
        public Show_list(MyTaskList taskList)
        {
            listName = "Task list : " + taskList.TaskListName;
            listNameShort = taskList.TaskListName;
            InitializeComponent();
            ListTitle.Text = listName;
            GlobalVars.LoadTaks();
            Closed += Window_Closed;
            TaskSetsView = CollectionViewSource.GetDefaultView(taskList.Task_List);
            Task_DataGrid.ItemsSource = TaskSetsView;
        }
        private void Handle_progress(object sender, RoutedEventArgs e)
        {
            GlobalVars.change++;
            MyTask myTask = Task_DataGrid.SelectedItem as MyTask;
            myTask.inProgress = !myTask.inProgress;
            TaskSetsView.Refresh();
        }
        private void Handle_Complete(object sender, RoutedEventArgs e)
        {
            GlobalVars.change++;
            MyTask myTask = Task_DataGrid.SelectedItem as MyTask;
            if (myTask.inProgress==true) {
                myTask.inProgress = false;
            }
            myTask.done = !myTask.done;
            TaskSetsView.Refresh();
        }
        private void Handle_Delete(object sender, RoutedEventArgs e)
        {
            GlobalVars.change++;
            int respons = Message_Box_Classes.DisplayMessageBox("Are you sure you want to delete this task?", "Deleting task");
            if (respons == 1)
            {
                MyTask myTask = Task_DataGrid.SelectedItem as MyTask;
                List<MyTask> TaskDataGrid = TaskSetsView.SourceCollection.Cast<MyTask>().ToList();
                MyTask taskToRemove = TaskDataGrid.FirstOrDefault(task => task.task == myTask.task);
                if (taskToRemove != null)
                {
                    TaskDataGrid.Remove(taskToRemove);
                    TaskSetsView = CollectionViewSource.GetDefaultView(TaskDataGrid);
                    TaskSetsView.Refresh();
                    Task_DataGrid.ItemsSource = TaskSetsView;
                }
            }
        }
        private void Handle_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Handle_Decrease(object sender, RoutedEventArgs e)
        {
            GlobalVars.change++;
            MyTask myTask = Task_DataGrid.SelectedItem as MyTask;
            myTask.priority--;
            update_task_grid();
        }
        private void Handle_Increase(object sender, RoutedEventArgs e)
        {
            GlobalVars.change++;
            MyTask myTask = Task_DataGrid.SelectedItem as MyTask;
            myTask.priority++;
            update_task_grid();
        }
        public void update_task_grid()
        {

            List<MyTask> TaskDataGrid = TaskSetsView.SourceCollection.Cast<MyTask>().ToList();
            MyTaskList myTaskList = new MyTaskList();
            myTaskList.Task_List = TaskDataGrid;
            GlobalVars.SortThisTaskList(myTaskList);
            TaskSetsView = CollectionViewSource.GetDefaultView(myTaskList.Task_List);
            Task_DataGrid.ItemsSource = TaskSetsView;
            TaskSetsView.Refresh();
        }
        private void Handle_Save(object sender, RoutedEventArgs e)
        {
            MyTaskList myTaskList = new MyTaskList();
            myTaskList.TaskListName = listNameShort;
            myTaskList.Task_List = TaskSetsView.SourceCollection.Cast<MyTask>().ToList();
            myTaskList.CheckComplete();
            GlobalVars.UpdateTaksList(myTaskList);
            GlobalVars.SaveTasklists();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            if (GlobalVars.change > 0)
            {
                int respons = Message_Box_Classes.DisplayMessageBox("Save before closeing?", "Close");
                if (respons == 1)
                {
                    Handle_Save(sender, e as RoutedEventArgs);
                }
                else { return; }
            }

        }
    }
}