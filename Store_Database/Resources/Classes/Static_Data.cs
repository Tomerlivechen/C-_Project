using Common_Classes.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
namespace Store_Database.Resources.Classes
{
    public class Static_Data
    {
        public static List<Categories> MainCatagories { get; set; } 
        public static List<Categories> SeconderyCatagories { get; set; }
      public static List<DB_Item>? DB_Items { get; set; } = new List<DB_Item>();
        public static List<Users>? ShopWorkors { get; set; } = new List<Users>();
        public static DB_Item? BDItem { get; set; } = new DB_Item();
        public static Users? tempUser { get; set; } = new Users();
        public static Users? tempUser2 { get; set; } = new Users();
        public static string ManagerPassward { get; set; } = "0000";
        public static string ManagerEditPassward { get; set; } = "0101";
        public static string filePath { get; set; } = "Resources/Store_Database_Passcode.json";
  //      public static void LoadStoredDataBase()
    //    {
    //        string RawJSON = File.ReadAllText(filePath);
    //        BDItems = JsonSerializer.Deserialize<List<DB_Item>>(RawJSON);
    //    }
        public static void LoadManagerPassward()
        {
            if (!File.Exists(filePath))
            {
                ManagerPassward = "0000";
                SavePasscode();
                return;
            }
            try
            {
                var rawData = File.ReadAllText(filePath);
                var result = JsonSerializer.Deserialize<string>(rawData);
                if (result == null)
                {
                    ManagerPassward = "0000";
                    SavePasscode();
                    return;
                }
                ManagerPassward = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File reading error {ex.Message}");
            }
        }
        public static void SavePasscode()
        {
            var export = JsonSerializer.Serialize(ManagerPassward);
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
            LoadManagerPassward();
        }
    }
}
