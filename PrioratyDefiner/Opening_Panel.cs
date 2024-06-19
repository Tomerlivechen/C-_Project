using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Common_Classes.Classes;
using System.Reflection;
namespace PriorityDefiner
{
    internal class Opening_Panel : IOpening_Panel
    {
        public string Name { get; set; } = "Prioritizer";
        public string Description { get; set; } = "This application was developed to organize and prioritize tasks in task lists. It uses a binary priority algorithm to ask the user about the priority of each pair of tasks culminating in a list of multiple items ordered by relative priority.\r\nNote: The priority set is positive; the higher the numerical priority, the higher priority the item is.";
        public List<string> Tags { get; set; } = new List<string>() { "CSharp", "WPF", "OOP", "JSON" };
        public BitmapImage buttonImage
        {
            get
            {
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                Uri uri = new Uri($"pack://application:,,,/{assemblyName};component/Resources/IndexImage.png");
                return new BitmapImage(uri);
            }
            set { }
        }
        public void Run()
        {
            TaskLists window = new TaskLists();
            window.ShowDialog();
        }
    }
}
