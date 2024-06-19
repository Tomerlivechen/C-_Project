using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Common_Classes.Classes;
namespace API_hub
{
    internal class Opening_Panel : IOpening_Panel
    {
        public string Name { get; set; } = "API Hub";
        public string Description { get; set; } = "This project enables you to access 4 different APIs: Animal Taxonomy, Recipes, drink recipes, and cocktail recipes on the same system and displays each dataset in its own structured window.";
        public List<string> Tags { get; set; } = new List<string>() { "CSharp", "WPF" ,"API","OOP"};
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
