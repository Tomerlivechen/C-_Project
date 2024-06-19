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
using Frogger.Classes;
namespace Frogger.Windows
{
    /// <summary>
    /// Interaction logic for IndexWindow.xaml
    /// </summary>
    public partial class IndexWindow : Window
    {
        public IndexWindow()
        {
            InitializeComponent();
            GlobalVars.LoadHighscores();
        }


    private void Start_Game_Click(object sender, RoutedEventArgs e)
    {
        int Difficulty = Get_Difficulty();

            Game_window window = new Game_window(Difficulty);
        window.ShowDialog();
    }

    private void Hight_Scores_Click(object sender, RoutedEventArgs e)
    {
        GlobalVars.SaveHighscores();
        int Difficulty = Get_Difficulty();
        switch (Difficulty)
        {
            case 1:
                Common_Classes.Common_Elements.High_score HSD1_window = new Common_Classes.Common_Elements.High_score(GlobalVars.highScore_Total.Difficalty_1);
                    HSD1_window.ShowDialog();
                break;
            case 2:
                Common_Classes.Common_Elements.High_score HSD2_window = new Common_Classes.Common_Elements.High_score(GlobalVars.highScore_Total.Difficalty_2);
                    HSD2_window.ShowDialog();
                break;
            case 3:
                Common_Classes.Common_Elements.High_score HSD3_window = new Common_Classes.Common_Elements.High_score(GlobalVars.highScore_Total.Difficalty_3);
                    HSD3_window.ShowDialog();
                break;
            case 4:
                Common_Classes.Common_Elements.High_score HSD4_window = new Common_Classes.Common_Elements.High_score(GlobalVars.highScore_Total.Difficalty_4);
                    HSD4_window.ShowDialog();
                break;
            case 5:
                Common_Classes.Common_Elements.High_score HSD5_window = new Common_Classes.Common_Elements.High_score(GlobalVars.highScore_Total.Difficalty_5);
                    HSD5_window.ShowDialog();
                break;
                case 6:
                    Common_Classes.Common_Elements.High_score HSD6_window = new Common_Classes.Common_Elements.High_score(GlobalVars.highScore_Total.Difficalty_6);
                    HSD6_window.ShowDialog();
                    break;
                case 7:
                    Common_Classes.Common_Elements.High_score HSD7_window = new Common_Classes.Common_Elements.High_score(GlobalVars.highScore_Total.Difficalty_7);
                    HSD7_window.ShowDialog();
                    break;
                default:
                break;
        }

    }

    public int Get_Difficulty()
    {
        ComboBoxItem selectedItem = Difficulty_level.SelectedItem as ComboBoxItem;
        int Difficulty;
        int.TryParse((string?)selectedItem.Tag, out Difficulty);
        return Difficulty;
    }
        private void Close_button(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
    }

