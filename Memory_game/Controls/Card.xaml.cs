using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
using Memory_game.Classes;
namespace Memory_game.Controls
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card(Memory_Card card)
        {
            InitializeComponent();
            DataContext = card;
            Card_Button.Click += (sender, e) =>
            {
                if (card.Viable && card.Face == false)
                card.Flip(sender, e);
            };
        }
    }
}