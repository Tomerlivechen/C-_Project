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
using System.Windows.Shapes;
using Taki_Game.Resources.Windows;
using Taki_Game.Resources.Classes;
namespace Taki_Game
{
    /// <summary>
    /// Interaction logic for IndexWindow.xaml
    /// </summary>
    public partial class IndexWindow : Window
    {
        public IndexWindow()
        {
            InitializeComponent();
        }
        public int Get_Player_amount()
        {
            ComboBoxItem selectedItem = Player_amount.SelectedItem as ComboBoxItem;
            int amount;
            int.TryParse((string?)selectedItem.Tag, out amount);
            return amount;
        }
        private void Start_Game_Click(object sender, RoutedEventArgs e)
        {
            int amount = Get_Player_amount();
            GlobalVars.InitilizeAllParameters();
            MainWindow window = new MainWindow(amount);
            window.ShowDialog();
        }
        private void Close_action(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void About_action(object sender, RoutedEventArgs e)
        {
            Help window = new Help();
            window.ShowDialog();
        }
    }
}