using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common_Classes;
using PriorityDefiner.Classes;
using System.Collections.Generic;
using PriorityDefiner;
using PriorityDefiner.windows;
using System.Diagnostics;
using Common_Classes.Classes;
namespace PrioratyDefiner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ListCreation : Window
    {
        public int listsize;
        public List<string> textBoxes;
        public ListCreation()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (
                Number_of_tasks.Text != null
                && Foolproofing.ValueVarification(1, 50, Number_of_tasks.Text)
            )
            {
                int.TryParse(Number_of_tasks.Text, out listsize);
                Submittitle.Visibility = Visibility.Hidden;
                Number_of_tasks.Visibility = Visibility.Hidden;
                Submit.Visibility = Visibility.Hidden;
                Taskstitle.Visibility = Visibility.Visible;
                tasks.Visibility = Visibility.Visible;
                start.Visibility = Visibility.Visible;
                for (int i = 0; i < listsize; i++)
                {
                    TextBox textbox = new TextBox()
                    {
                        Margin = new Thickness(1),
                        Height = 30,
                        Width = 250,
                        FontSize = 20,
                    };
                    tasks.Children.Add(textbox);
                }
            }
            else
            {
                MessageBox.Show("Must be a number between 1 and under 50", "Error");
            }
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (!Check_tasks_unique())
            {
                textBoxes = new List<string>();
                foreach (var item in tasks.Children)
                {
                    if (item is TextBox textBox)
                    {
                        textBoxes.Add(textBox.Text);
                    }
                }
                run_priority();
                Close();
            }
            else
            {
                MessageBox.Show("Task Names must be unique and have actual values", "Error");
            }
        }
        public List<string> run_priority()
        {
            string[,] priorityMatrix = new string[listsize, listsize];
            for (int i = 0; i < textBoxes.Count; i++)
            {
                string textvalue = textBoxes[i];
                priorityMatrix[i, i] = textvalue;
                for (int j = 0; j < i; j++)
                {
                    string secondtextvalue = textBoxes[j];
                    if (textvalue != secondtextvalue)
                    {
                        string resposne = Message_Box_Classes.PiorityMesageBox(
                            textvalue,
                            secondtextvalue
                        );
                        if (resposne == textvalue)
                        {
                            priorityMatrix[i, j] = (textvalue);
                        }
                        else if (resposne == secondtextvalue)
                        {
                            priorityMatrix[i, j] = (secondtextvalue);
                        }
                    }
                }
            }
            SortedDictionary<string, int> counts = Priority_Classes.CountValues(priorityMatrix);
            MyTaskList taskList = new MyTaskList();
            Taskstitle.Text = "Final priority list";
            tasks.Visibility = Visibility.Hidden;
            start.Visibility = Visibility.Hidden;
            foreach (var count in counts)
            {
                MyTask task = new MyTask();
                task.priority = count.Value;
                task.task = count.Key;
                taskList.Task_List.Add(task);
            }
            GlobalVars.SortThisTaskList(taskList);
            GlobalVars.addlist(taskList);
            GlobalVars.SaveTasklists();
            foreach (MyTaskList item in GlobalVars.allTaskLists.listOfLists)
            {
                if (taskList.TaskListName == item.TaskListName)
                {
                    Show_list show_List = new Show_list(item);
                    show_List.ShowDialog();
                }
            }
            return null;
        }
        public bool Check_tasks_unique()
        {
            foreach (TextBox item in tasks.Children)
            {
                int index = 0;
                foreach (TextBox task in tasks.Children)
                {
                    if (item.Text == task.Text)
                    {
                        index++;
                        if (index >= 2 || string.IsNullOrWhiteSpace(item.Text))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}