using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Common_Classes.Classes;
using System.Reflection;
 namespace Memory_game
{
    internal class Opening_Panel : IOpening_Panel
    {
        public string Name { get; set; } = "Memory Game";
        public string Description { get; set; } = "This application simulates a tabletop memory card game. The goal is to match all the card pairs one by one by flipping two cards each time and remembering the position of the cards that have been viewed. The player wins once all the cards are matched.";
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
            MainWindow window = new MainWindow();
            window.ShowDialog();
        }
    }
}
 