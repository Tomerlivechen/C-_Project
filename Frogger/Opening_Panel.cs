using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Common_Classes.Classes;
using System.Reflection;
using Frogger.Windows;




namespace Frogger
{
    internal class Opening_Panel : IOpening_Panel
    {
        public string Name { get; set; } = "Frogger";
        public string Description { get; set; } = "This application was developed for playing the classic Saga game Frogger using WPF. The player uses the arrow keys to guide the frog to fill the empty ponds across the road and river and avoid obstacles. The game has seven difficulty levels; the obstacles get faster the higher the difficulty.";
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
            IndexWindow window = new IndexWindow();
            window.ShowDialog();
        }
    }
}
