using Common_Classes.Classes;
using Common_Classes.Common_Elements;
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
using Speed_Racer.Resources.Classes;
namespace Speed_Racer.Windows
{
    /// <summary>
    /// Interaction logic for IndexWindow.xaml
    /// </summary>
    public partial class IndexWindow : Window
    {
        public IndexWindow()
        {
            InitializeComponent();
            HighScores.LoadHighscores();
        }
        private void Start_Game_Click(object sender, RoutedEventArgs e)
        {
            int difficulty = Get_Difficulty();
            string playerName = SetPlayerName();
            Game_Window game_Window = new Game_Window(difficulty, playerName);
            game_Window.ShowDialog();
        }
        private void Hight_Scores_Click(object sender, RoutedEventArgs e)
        {
            High_score HS_window = new High_score(HighScores.HighScoreList);
            HS_window.ShowDialog();
        }
        public string SetPlayerName()
        {
            string name;
                var number_of_field = 1;
                var title = $"Insert Name of player";
                var Input_field = new Input_box_field();
                Input_field.Input_label = "Enter name:";
            Input_box input_Box;
            UniversalVars.inputBoxReturn = null;
            do
            {
                input_Box = new Input_box(number_of_field, title, Input_field);
                input_Box.ShowDialog();
                if (UniversalVars.inputBoxReturn == null)
                {
                    MessageBox.Show("What is your name?", "Name your player");
                }
            }
            while (UniversalVars.inputBoxReturn == null);
            name = UniversalVars.inputBoxReturn[0].ToString();
            UniversalVars.inputBoxReturn = null;
            return name;
            
        }
        public int Get_Difficulty()
        {
            ComboBoxItem selectedItem = Difficulty_level.SelectedItem as ComboBoxItem;
            int Difficulty;
            int.TryParse((string?)selectedItem.Tag, out Difficulty);
            return Difficulty;
        }
    }
}
