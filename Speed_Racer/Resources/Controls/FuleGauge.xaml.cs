using Speed_Racer.Resources.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Speed_Racer.Resources.Controls
{
    /// <summary>
    /// Interaction logic for FuleGauge.xaml
    /// </summary>
    public partial class FuleGauge : UserControl
    {
        DispatcherTimer timer1 = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        Race_Game _game;
        public FuleGauge(Race_Game game)
        {
            
            InitializeComponent();
            _game = game;
            timer1.Start();
            timer1.Tick += TimedAction;
            Tank_image.Source = Image_Import.LoadImageFromResource("FuleSymbol.png");
        }
        public void TimedAction(object sender, EventArgs e)
        {
            int barNumber = (int)(_game.Fule / 10);
           GenerateGage(barNumber);
        }
        public void GenerateGage(int number)
        {
            fule_panel.Children.Clear();
            for (int i = number; i > 0; i--)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = 100;
                rectangle.Height = 32;
                rectangle.Margin = new Thickness(5);
                if (i > 7)
                {
                    rectangle.Fill = Brushes.Green;
                }
                else if (i > 5)
                {
                    rectangle.Fill = Brushes.Yellow;
                }
                else if(i > 3)
                {
                    rectangle.Fill = Brushes.Orange;
                }
                else if(i <= 3)
                {
                    rectangle.Fill = Brushes.Red;
                }
                fule_panel.Children.Add(rectangle);
            }
        }
    }
}