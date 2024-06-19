
using System.Net.Http;
using System.Net.Http.Json;
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
using System.Xml.Linq;
using API_hub.Classes;
using API_hub.Windows;
namespace API_hub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        HttpClient client1 = new HttpClient();
        string Recipe_api_url = "https://api.api-ninjas.com/v1/recipe?query=";
        string Animal_api_url = "https://api.api-ninjas.com/v1/animals?name=";
        string Cocktail_api_url = "https://api.api-ninjas.com/v1/cocktail?name=";
        string Drinks_api_url = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=";
        string API_KEY = "jlgJxa5rGHkjm6u8o+QUBQ==h7fZtkxmcM0KrikM";
        public MainWindow()
        {
            InitializeComponent();
            client.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
        }
        async void Button_Click(object sender, RoutedEventArgs e)
        {
            ListDataGrid.ItemsSource = null;
            string name = TB_Name.Text.ToString();
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
            {
                int API_Type = Get_Api();
                if (API_Type == 1)
                {
                    string api_url = Animal_api_url + name;
                    var usersReponse = await GetAnimalsAsync(api_url);
                    ListDataGrid.ItemsSource = usersReponse;
                    Binding_Column.Binding = new System.Windows.Data.Binding("name");
                }
                if (API_Type == 2)
                {
                    string api_url = Recipe_api_url + name;
                    var usersReponse = await GetRecipesAsync(api_url);
                    ListDataGrid.ItemsSource = usersReponse;
                    Binding_Column.Binding = new System.Windows.Data.Binding("title");
                }
                if (API_Type == 3)
                {
                    string api_url = Cocktail_api_url + name;
                    var usersReponse = await GetCocktailAsync(api_url);
                    ListDataGrid.ItemsSource = usersReponse;
                    Binding_Column.Binding = new System.Windows.Data.Binding("Name");
                }
                if (API_Type == 4)
                {
                    string api_url = Drinks_api_url + name;
                    var usersReponse = await GetDrinksAsync(api_url);
                    ListDataGrid.ItemsSource = usersReponse;
                    Binding_Column.Binding = new System.Windows.Data.Binding("Name");
                }
            }
            if (ListDataGrid.ItemsSource == null)
            {
                MessageBox.Show("Nothing found", "Nothing found");
            }
        }
        async Task<List<Animal>> GetAnimalsAsync(string api_url)
        {
            HttpResponseMessage response = await client.GetAsync(api_url);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<Animal>>();
            return data;
        }
        async Task<List<Recipe>> GetRecipesAsync(string api_url)
        {
            HttpResponseMessage response = await client.GetAsync(api_url);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<Recipe>>();
            return data;
        }
        async Task<List<Cocktail>> GetCocktailAsync(string api_url)
        {
            HttpResponseMessage response = await client.GetAsync(api_url);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<Cocktail>>();
            return data;
        }
        async Task<List<Drink>> GetDrinksAsync(string api_url)
        {
            HttpResponseMessage response = await client1.GetAsync(api_url);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<Drinks>();
            return data.drinks;
        }
        public int Get_Api()
        {
            ComboBoxItem selectedItem = API_Selection.SelectedItem as ComboBoxItem;
            int API_Num;
            int.TryParse((string?)selectedItem.Tag, out API_Num);
            return API_Num;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListDataGrid.SelectedItem is Animal)
            {
                Animal animal = (Animal)ListDataGrid.SelectedItem;
                AnimalFacts window = new AnimalFacts(animal);
                window.ShowDialog();
            }
            if (ListDataGrid.SelectedItem is Recipe)
            {
                Recipe recipe = (Recipe)ListDataGrid.SelectedItem;
                Receipt window = new Receipt(recipe);
                window.ShowDialog();
            }
            if (ListDataGrid.SelectedItem is Cocktail)
            {
                Cocktail cocktail = (Cocktail)ListDataGrid.SelectedItem;
                Cocktail_recipes window = new Cocktail_recipes(cocktail);
                window.ShowDialog();
            }
            if (ListDataGrid.SelectedItem is Drink)
            {
                Drink drink = (Drink)ListDataGrid.SelectedItem;
                Drinks_Window window = new Drinks_Window(drink);
                window.ShowDialog();
            }
        }
    }
}
