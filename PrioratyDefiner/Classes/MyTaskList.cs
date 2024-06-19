using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PriorityDefiner.Classes
{
    public class MyTaskList
    {
        public string TaskListName { get; set; }
        public List<MyTask> Task_List { get; set; } = new List<MyTask>();
        public bool incomplete { get; set; } = true;
        public bool complete { get; set; } = false;
        public void CheckComplete()
        {
            int index = 0;
            foreach (MyTask item in Task_List)
            {
                if (item.done == false)
                {
                    incomplete = true;
                    index++;
                }
            }
            if (index == 0)
            {
                incomplete = false;
            }
            complete = !incomplete;
        }
    }
}
