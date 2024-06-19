using System.IO;
using System.Text.Json;
using System.Windows;
using Common_Classes.Classes;
namespace Speed_Racer.Resources.Classes
{
    public static class HighScores
    {
        public const string High_Score_file = (@"Resources\Speed_Racer_HighScore.json");
        public static List<High_score_player> HighScoreList { get; set; } = new List<High_score_player>();
        public static void AddHighScore(string name, int score)
        {
            if (string.IsNullOrEmpty(name)) 
            {
                name = "Anonymous";
            }
            High_score_player highScore_Player = new High_score_player(name, score);
            HighScoreList.Add(highScore_Player);
            SaveHighscores();
        }
        public static void LoadHighscores()
        {
            if (!File.Exists(High_Score_file))
            {
                List<High_score_player> TempHighScoreList = new List<High_score_player>();
                HighScoreList = TempHighScoreList;
                SaveHighscores();
                return;
            }
            try
            {
                var rawData = File.ReadAllText(High_Score_file);
                var result = JsonSerializer.Deserialize<List<High_score_player>>(rawData);
                if (result == null)
                {
                    List<High_score_player> TempHighScoreList = new List<High_score_player>();
                    HighScoreList = TempHighScoreList;
                    SaveHighscores();
                    return;
                }
                HighScoreList = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No High scores available");
            }
        }
        public static void SaveHighscores()
        {
            var export = JsonSerializer.Serialize(HighScoreList);
            try
            {
                string directoryPath = Path.GetDirectoryName(High_Score_file);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                using (StreamWriter writer = new StreamWriter(High_Score_file, false))
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
