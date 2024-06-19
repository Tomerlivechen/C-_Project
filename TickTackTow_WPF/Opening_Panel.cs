using Common_Classes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
namespace TickTackTow_WPF
{
    internal class Opening_Panel : IOpening_Panel
    {
        public string Name { get; set; } = "Tic Tac Toe";
        public string Description { get; set; } = "This application was developed to simulate the classic game Tic Tac Toe. Originally a two-player game, each player takes turns placing an 'X' or an 'O' on a 3x3 grid, intending to form a straight line of three of their symbols, either by row, column, or diagonal. This game also has the option to play against the computer, either with the randomized placement of symbols or an algorithm that actively tries to win, or let two computer players play against each other.";
        public List<string> Tags { get; set; } = new List<string>() { "CSharp", "WPF", "OOP" };
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
