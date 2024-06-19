using Common_Classes.Common_Elements;
using Common_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Common_Classes.Classes;
namespace PriorityDefiner.Classes
{
    public static class GlobalVars
    {
        const string filePath = (@"Resources\PriorityDefiner_Tasklists.json");
        public static MylistOfTakLists allTaskLists = new MylistOfTakLists();
        public static int change = 0;
        public static void addlist(MyTaskList newTaskList)
        {
            var number_of_field = 1;
            var title = "Insert Name Of Task list";
            var Input_field = new Input_box_field();
            Input_field.Input_label = "Enter name:";
            Input_box input_Box;
            UniversalVars.inputBoxReturn = null;

            do
            {
                input_Box = new Input_box(number_of_field, title, Input_field);
                input_Box.ShowDialog();
                if (UniversalVars.inputBoxReturn == null)
                {
                    MessageBox.Show("Please name your table", "Table cannot be nameless");
                }
                if (UniversalVars.inputBoxReturn != null)
                {
                    foreach (MyTaskList task_list in allTaskLists.listOfLists)
                    {
                        if (UniversalVars.inputBoxReturn[0].ToString() == task_list.TaskListName)
                        {
                            MessageBox.Show("List Name alredy in use", "Name in use");
                            UniversalVars.inputBoxReturn = null;
                        }
                    }
                }
            } while (UniversalVars.inputBoxReturn == null);
            newTaskList.TaskListName = UniversalVars.inputBoxReturn[0].ToString();
            allTaskLists.listOfLists.Add(newTaskList);

        }
        public static void LoadTaks()
        {
            if (!File.Exists(filePath))
            {
                MylistOfTakLists MewTaskLists = new MylistOfTakLists();
                allTaskLists = MewTaskLists;
                SaveTasklists();
                return;
            }
            try
            {
                var rawData = File.ReadAllText(filePath);
                var result = JsonSerializer.Deserialize<MylistOfTakLists>(rawData);
                if (result == null)
                {
                    MylistOfTakLists NewTaskLists = new MylistOfTakLists();
                    allTaskLists = NewTaskLists;
                    return;
                }
                allTaskLists = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No Task lists available");
            }
        }
        public static void SaveTasklists()
        {
            change = 0;
            var export = JsonSerializer.Serialize(allTaskLists);
            try
            {
                string directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.Write(export);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving: {ex.Message}");
            }
            LoadTaks();
        }
        public static void UpdateTaksList(MyTaskList tasklist)
        {
            foreach (MyTaskList task_list in allTaskLists.listOfLists)
            {
                if (tasklist.TaskListName == task_list.TaskListName)
                {
                    task_list.Task_List = tasklist.Task_List;
                }
            }
;
        }
        public static void SortMyTaskList()
        {
            foreach (MyTaskList tasklist in allTaskLists.listOfLists)
            {
                tasklist.Task_List = tasklist.Task_List.OrderByDescending(MyTask => MyTask.priority).ToList();
            }
        }
        public static void SortThisTaskList(MyTaskList tasklist)
        {
            tasklist.Task_List = tasklist.Task_List.OrderByDescending(MyTask => MyTask.priority).ToList();
        }
        public static void replaceTaskLists(List<MyTaskList> NewallTaskLists)
        {
            MylistOfTakLists newalltast = new MylistOfTakLists();
            newalltast.listOfLists = NewallTaskLists;
            allTaskLists = newalltast;
        }
    }
}
