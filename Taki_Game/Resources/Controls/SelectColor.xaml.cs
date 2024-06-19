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
using Taki_Game.Resources.Classes;
namespace Taki_Game.Resources.Controls
{
    /// <summary>
    /// Interaction logic for SelectColor.xaml
    /// </summary>
    public partial class SelectColor : Window
    {
        public SelectColor()
        {
            InitializeComponent();
        }
        private void Color_select_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (GlobalVars.lastCardInStack.color == "")
            {
                GlobalVars.TakiColor = button.Tag.ToString();
            }
            Close();
        }
    }
}