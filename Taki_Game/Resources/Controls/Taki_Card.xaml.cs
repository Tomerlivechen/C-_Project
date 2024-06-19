using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
using Taki_Game.Resources.Classes;
namespace Taki_Game.Resources.Controls
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Taki_Card : UserControl
    {
        public Taki_Card(TakiCard Takicard)
        {
            InitializeComponent();
            DataContext = Takicard;
            Card_Button.MouseEnter += (sender, e) =>
            {
                Takicard.Internalflip(GlobalVars.player);
            };
            Card_Button.MouseLeave += (sender, e) =>
            {
                Takicard.InternalDeflip();
            };
            Card_Button.Click += (sender, e) =>
            {
                Takicard.PlayCard();
            };
        }
    }
}