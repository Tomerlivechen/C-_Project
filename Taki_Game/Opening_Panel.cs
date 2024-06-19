using Common_Classes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
namespace Taki_Game
{
    internal class Opening_Panel : IOpening_Panel
    {
        public string Name { get; set; } = "Taki Game";
        public string Description { get; set; } = "This application was developed for playing the game TAKI using WPF for up to 4 players on one computer. Each turn, there is a notification for the player to change, and the card set changes. The assets were taken from the original game website. The rules of the game here remain as they were in the original V1 game (the current public game version is V3).\r\nAn exhaustive explanation of the rules of the game is available in the pre-game panel by clicking on the 'Help' -> 'About' section in the preliminary game window.";
        public List<string> Tags { get; set; } = new List<string>() { "CSharp", "WPF", "OOP","LINQ"};
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
