using Common_Classes.Classes;
using Common_Classes.Common_Elements;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows;
namespace Store_Database.Resources.Classes
{
    public static class API_Static
    {
        public static Uri? apiadress = new Uri("https://662006073bf790e070aec029.mockapi.io/Tlc/");
        public static string apiResource = "Store_items";
        public static string apiFilePath = "Resources/Store_Database_APIAdress.json";
        public static string apiResourceFilePath = "Resources/Store_Database_APIResource.json";
        private static HttpClient client = new HttpClient();
        public static async void ChangeAPIAddress_Click()
        {
            var number_of_field = 2;
            var title = "Insert your API info";
            var Input_field1 = new Input_box_field();
            var Input_field2 = new Input_box_field();
            Input_field1.Input_label = "Enter API Uri:";
            Input_field2.Input_label = "Enter API Resource:";
            Input_box input_Box;
            UniversalVars.inputBoxReturn = null;
            Uri? uriAPI;
            do
            {
                input_Box = new Input_box(number_of_field, title, Input_field1, Input_field2);
                input_Box.ShowDialog();


                if (UniversalVars.inputBoxReturn == null)
                {
                    MessageBox.Show("Enter API and resource", "Input Erroir");
                    continue;
                }
                if (UniversalVars.inputBoxReturn != null)
                {
                    if (UniversalVars.inputBoxReturn.Count != 2)
                    {
                        MessageBox.Show("Insert API and resourse", "Invalid resource");
                        Log.addToLog($"API changed atempted");
                        UniversalVars.inputBoxReturn = null;
                        continue;
                    }
                    bool isUri = Uri.TryCreate(UniversalVars.inputBoxReturn[0], UriKind.Absolute, out uriAPI);
                    if (!isUri)
                    {
                        MessageBox.Show("API address invalid", "Invalid API");
                        Log.addToLog($"API changed atempted");
                        UniversalVars.inputBoxReturn = null;
                        continue;
                    }
  
                }
            } while (UniversalVars.inputBoxReturn == null) ;
            apiResource = UniversalVars.inputBoxReturn[1].ToString();
            Uri.TryCreate(UniversalVars.inputBoxReturn[0], UriKind.Absolute, out uriAPI);
            apiadress = uriAPI;
            if (await TryNewAPI())
            {
                MessageBox.Show($"API address changed to {uriAPI}{apiResource}", "API Changed sucessfully");
                Log.addToLog($"API changed to {uriAPI}{apiResource}");
                SaveAPIStats();
                return;
            }
            else
            {
                InitializeAPI();
                MessageBox.Show("API address invalid", "Invalid API");
                Log.addToLog($"API changed atempted");
                return;
            }
        }

        public static async Task<bool> TryNewAPI()
        {
                try
            {
                client = new HttpClient();
                client.BaseAddress = apiadress;
                var response = await client.GetAsync(apiResource);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadFromJsonAsync<List<DB_Item>>();
                return validateDB_Item(data[0]);
            } catch (Exception ex)
            {
                return false;
            }
            
        }

        public static bool validateDB_Item(DB_Item item)
        {
            if (item == null) { return false; }
            if (string.IsNullOrEmpty(item.ItemName)) { return false; }
            if (string.IsNullOrEmpty(item.MainCategory)) { return false; }
            if (string.IsNullOrEmpty(item.SeconderyCategory)) { return false; }
            if (string.IsNullOrEmpty(item.AddedDate)) { return false; }
            return true;
        }



        public static void InitializeAPI()
        {
            LoadAPI();
            LoadAPIResource();
        }
        public static void SaveAPIStats()
        {
            SaveAPI();
            SaveAPIResource();
        }
        public static void LoadAPI()
        {
            if (!File.Exists(apiFilePath))
            {
                Uri APIAdress = new Uri("https://662006073bf790e070aec029.mockapi.io/Tlc/");
                apiadress = APIAdress;
                SaveAPI();
                return;
            }
            try
            {
                var rawData = File.ReadAllText(apiFilePath);
                var result = JsonSerializer.Deserialize<Uri>(rawData);
                if (result == null)
                {
                    Uri APIAdress = new Uri("https://662006073bf790e070aec029.mockapi.io/Tlc/");
                    apiadress = APIAdress;
                    SaveAPI();
                    return;
                }
                apiadress = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File reading error {ex.Message}");
            }
        }
        public static void SaveAPI()
        {
            var export = JsonSerializer.Serialize(apiadress);
            try
            {
                string directoryPath = Path.GetDirectoryName(apiFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                using (StreamWriter writer = new StreamWriter(apiFilePath, false))
                {
                    writer.Write(export);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving high scores: {ex.Message}");
            }
            LoadAPI();
        }
        public static void LoadAPIResource()
        {
            if (!File.Exists(apiResourceFilePath))
            {
                string APIResource = "Store_items";
                apiResource = APIResource;
                SaveAPIResource();
                return;
            }
            try
            {
                var rawData = File.ReadAllText(apiResourceFilePath);
                var result = JsonSerializer.Deserialize<string>(rawData);
                if (result == null)
                {
                    string APIResource = "Store_items";
                    apiResource = APIResource;
                    SaveAPIResource();
                    return;
                }
                apiResource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File reading error {ex.Message}");
            }
        }
        public static void SaveAPIResource()
        {
            var export = JsonSerializer.Serialize(apiResource);
            try
            {
                string directoryPath = Path.GetDirectoryName(apiResourceFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                using (StreamWriter writer = new StreamWriter(apiResourceFilePath, false))
                {
                    writer.Write(export);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving high scores: {ex.Message}");
            }
            LoadAPIResource();
        }
    }
}
