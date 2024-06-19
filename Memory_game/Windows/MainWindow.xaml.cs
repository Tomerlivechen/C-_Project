using Common_Classes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Memory_game.Classes;
using Common_Classes.Classes;
namespace Memory_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GlobalVars.LoadHighscores();
        }
        private void Start_Game_Click(object sender, RoutedEventArgs e)
        {
            int amount = Get_card_amount();
            MemoryGameWindow window = new MemoryGameWindow(amount);
            window.ShowDialog();
        }
        private void Hight_Scores_Click(object sender, RoutedEventArgs e)
        {
            GlobalVars.SaveHighscores();
            int amount = Get_card_amount();
            switch (amount)
            {
                case 12:
                    Common_Classes.Common_Elements.High_score HS12_window = new Common_Classes.Common_Elements.High_score(GlobalVars.highScore_Total.High_Score_12);
                    HS12_window.ShowDialog();
                    break;
                case 18:
                    Common_Classes.Common_Elements.High_score HS18_window = new Common_Classes.Common_Elements.High_score(GlobalVars.highScore_Total.High_Score_18);
                    HS18_window.ShowDialog();
                    break;
                case 24:
                    Common_Classes.Common_Elements.High_score HS24_window = new Common_Classes.Common_Elements.High_score(GlobalVars.highScore_Total.High_Score_24);
                    HS24_window.ShowDialog();
                    break;
                case 30:
                    Common_Classes.Common_Elements.High_score HS30_window = new Common_Classes.Common_Elements.High_score(GlobalVars.highScore_Total.High_Score_30);
                    HS30_window.ShowDialog();
                    break;
                case 36:
                    Common_Classes.Common_Elements.High_score HS36_window = new Common_Classes.Common_Elements.High_score(GlobalVars.highScore_Total.High_Score_36);
                    HS36_window.ShowDialog();
                    break;
                case 48:
                    Common_Classes.Common_Elements.High_score HS48_window = new Common_Classes.Common_Elements.High_score(GlobalVars.highScore_Total.High_Score_48);
                    HS48_window.ShowDialog();
                    break;
                default:
                    break;
            }
        }
        public int Get_card_amount() {
            ComboBoxItem selectedItem = Card_amount.SelectedItem as ComboBoxItem;
            int amount;
            int.TryParse((string?)selectedItem.Tag, out amount);
            return amount;
        }
    }
}