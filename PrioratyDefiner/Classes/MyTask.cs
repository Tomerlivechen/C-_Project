using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PriorityDefiner.Classes
{
    public class MyTask
    {
        public int priority { get; set; }
        public string task { get; set; }
        public bool inProgress { get; set; }
        public bool done { get; set; }
    }
}
