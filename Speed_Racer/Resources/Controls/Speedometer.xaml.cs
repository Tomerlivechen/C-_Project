using System;
using System.Collections.Generic;
using System.Linq;
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
using Speed_Racer.Resources.Classes;
using Speed_Racer.Windows;
namespace Speed_Racer.Resources.Controls
{
    /// <summary>
    /// Interaction logic for Speedometer.xaml
    /// </summary>
    public partial class Speedometer : UserControl
    {
        
        public Speedometer()
        {
            InitializeComponent();
        }
        public void GenerateGage(int number)
        {
            if (number > 10) {
                number = 10;
            }
            SpeedPanel.Children.Clear();
            for (int i =0 ; i < number; i++)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = 20;
                rectangle.Height = 120;
                rectangle.Margin = new Thickness(5);
                if (i > 7)
                {
                    rectangle.Fill = Brushes.Red;
                }
                else if (i > 5)
                {
                    rectangle.Fill = Brushes.Orange;
                }
                else if (i > 3)
                {
                    rectangle.Fill = Brushes.Yellow;
                }
                else if (i <= 3)
                {
                    rectangle.Fill = Brushes.Green;
                }
                SpeedPanel.Children.Add(rectangle);
            }
        }
    }
}