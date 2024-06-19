using Common_Classes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
namespace API_Animal_Pics
{
    internal class Opening_Panel : IOpening_Panel
    {
        public string Name { get; set; } = "API Animal Pics";
        public string Description { get; set; } = "This application enables you to collect objects (in this case, animal image objects) from different APIs into lists, save them to a local storage JSON file, view and modify the lists, and reach the object in your browser.";
        public List<string> Tags { get; set; } = new List<string>() { "CSharp", "WPF", "API", "OOP","JSON","LINQ" };
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
            MainWindow window = new MainWindow();
            window.ShowDialog();
        }
    }
}
