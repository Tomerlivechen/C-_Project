using Speed_Racer.Resources.Classes;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Speed_Racer.Resources.Controls
{
    /// <summary>
    /// Interaction logic for Repair_item.xaml
    /// </summary>
    public partial class Repair_item : UserControl
    {
        DispatcherTimer timer1 = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        Race_Game _game;
        public Repair_item(Race_Game game)
        {
            InitializeComponent();
            _game = game;
            timer1.Start();
            timer1.Tick += TimedAction;
        }
        public void TimedAction(object sender, EventArgs e)
        {
            setUpItems(_game.repair);
        }
        public void setUpItems (int number)
        {
            repair_holder.Children.Clear();
            for (int i = 0; i < number; i++)
            {
                Image image = new Image();
                image.Source = Image_Import.LoadImageFromResource("RepairKit_stat.png");
                repair_holder.Children.Add(image);
            }
        }
    }
}