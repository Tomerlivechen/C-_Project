using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Common_Classes.Classes;
namespace Store_Database
{
    internal class Opening_Panel : IOpening_Panel
    {
        public string Name { get; set; } = "Store Inventory";
        public string Description { get; set; } = "This application is a store inventory interface connected to an API.\r\nThe item list can be sorted and filtered.\r\nThe API holds both the items in the inventory and a workers’ list for the workers in the store.\r\nModifying items requires a valid worker ID, and adding and removing items requires a manager override code.\r\nManager override code is initialized as “0000” but can be changed and is stored locally. Changing it requires a Manager edit passcode, hardcoded to \"0101”.\r\nThe workers’ list can be viewed but requires a manager override code.\r\nModifying workers requires a manager override code.\r\nModifying API URI itself is also possible and requires Manager override code.\r\nOnce lists of items or workers are filtered in a desired manner, a report can be produced.\r\nAll significant actions are logged in a local log file.";
        public List<string> Tags { get; set; } = new List<string>() { "CSharp", "WPF", "OOP","API","LINQ", "JSON" };
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
            IndexWindow window = new IndexWindow();
            window.ShowDialog();
        }
    }
}
