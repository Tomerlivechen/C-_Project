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
namespace Memory_game.Classes
{
    public static class GlobalVars
    {
        public static Memory_Card first_Card { get; set; } = null;
        public static void SetFirstCard(Memory_Card value) => first_Card = value;
        public static Memory_Card second_Card { get; set; } = null;
        public static void SetSecondCard(Memory_Card value) => second_Card = value;
        public static int Timer_count { get; set; } = 0;
        public static void SetTimerCount() => Timer_count++;
        public static void ResetTimerCount() => Timer_count = 0;
        const string filePath = (@"Resources\Memory_game_HighScore.json");
        public static HighScore_Total highScore_Total { get; set; }
        public static void AddHighScore(int cardNum, int score)
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
            switch (cardNum)
            {
                case 12:
                    highScore_Total.High_Score_12.AddPlayer(highScore_Player);
                    break;
                case 18:
                    highScore_Total.High_Score_18.AddPlayer(highScore_Player);
                    break;
                case 24:
                    highScore_Total.High_Score_24.AddPlayer(highScore_Player);
                    break;
                case 30:
                    highScore_Total.High_Score_30.AddPlayer(highScore_Player);
                    break;
                case 36:
                    highScore_Total.High_Score_36.AddPlayer(highScore_Player);
                    break;
                case 48:
                    highScore_Total.High_Score_48.AddPlayer(highScore_Player);
                    break;
                default:
                    break;
            }
        }
        public static void LoadHighscores()
        {
            if (!File.Exists(filePath))
            {
                HighScore_Total NewHighScored = new HighScore_Total();
                highScore_Total = NewHighScored;
                SaveHighscores();
                return;
            }
            try
            {
                var rawData = File.ReadAllText(filePath);
                var result = JsonSerializer.Deserialize<HighScore_Total>(rawData);
                if (result == null)
                {
                    HighScore_Total NewHighScored = new HighScore_Total();
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
