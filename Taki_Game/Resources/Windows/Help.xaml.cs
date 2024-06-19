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
namespace Taki_Game.Resources.Windows
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();
            B_Taki.Source = GlobalVars.LoadImageFromResource("B_Taki.png");
            B_Taki.Source = GlobalVars.LoadImageFromResource("B_Taki.png");
            Taki.Source = GlobalVars.LoadImageFromResource("Taki.png");
            R_COrder.Source = GlobalVars.LoadImageFromResource("R_COrder.png");
            R_Stop.Source = GlobalVars.LoadImageFromResource("R_Stop.png");
            _Color.Source = GlobalVars.LoadImageFromResource("Color.png");
            Y_2P.Source = GlobalVars.LoadImageFromResource("Y_2+.png");
            Change.Source = GlobalVars.LoadImageFromResource("Change.png");
        }
    }

}
