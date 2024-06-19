using Common_Classes.Common_Elements;
using Common_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Common_Classes.Classes;
namespace Frogger.Classes
{
    public static class GlobalVars
    {
        public static int Timer_count { get; set; } = 0;
        public static void SetTimerCount() => Timer_count++;
        public static void ResetTimerCount() => Timer_count = 0;
        const string filePath = (@"Resources\Frogger_HighScore.json");
        public static HighScore_Total_Frogger highScore_Total { get; set; }
        public static void AddHighScore(int difficalty, int score)
        {
            var highScore_Player = new HighScore_Player();
            highScore_Player.time_complete = score;
            var number_of_field = 1;
            var title = "Insert Name for high score";
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
                    MessageBox.Show("What is your name?", "Score Cannot Be Nameless");
                }
            }
            while (UniversalVars.inputBoxReturn == null);
            highScore_Player.player_Name = UniversalVars.inputBoxReturn[0].ToString();

            switch (difficalty)
            {
                case 1:
                    highScore_Total.Difficalty_1.AddPlayer(highScore_Player);
                    break;
                case 2:
                    highScore_Total.Difficalty_2.AddPlayer(highScore_Player);
                    break;
                case 3:
                    highScore_Total.Difficalty_3.AddPlayer(highScore_Player);
                    break;
                case 4:
                    highScore_Total.Difficalty_4.AddPlayer(highScore_Player);
                    break;
                case 5:
                    highScore_Total.Difficalty_5.AddPlayer(highScore_Player);
                    break;
                case 6:
                    highScore_Total.Difficalty_6.AddPlayer(highScore_Player);
                    break;
                case 7:
                    highScore_Total.Difficalty_7.AddPlayer(highScore_Player);
                    break;
                default:
                    break;
            }
        }
        public static void LoadHighscores()
        {
            if (!File.Exists(filePath))
            {
                HighScore_Total_Frogger NewHighScored = new HighScore_Total_Frogger();
                highScore_Total = NewHighScored;
                SaveHighscores();
                return;
            }
            try
            {
                var rawData = File.ReadAllText(filePath);
                var result = JsonSerializer.Deserialize<HighScore_Total_Frogger>(rawData);
                if (result == null)
                {
                    HighScore_Total_Frogger NewHighScored = new HighScore_Total_Frogger();
                    highScore_Total = NewHighScored;
                    return;
                }
                highScore_Total = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No High scores available");
            }
        }
        public static void SaveHighscores()
        {
            var export = JsonSerializer.Serialize(highScore_Total);
            try
            {
                string directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.Write(export);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving high scores: {ex.Message}");
            }
            LoadHighscores();
        }
    }
}
