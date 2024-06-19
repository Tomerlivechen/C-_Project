using Store_Database.Resources.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Common_Classes.Classes;
using Common_Classes.Common_Elements;
using Store_Database.Resources.Windows;
using System.IO;
using System.Text.Json;
namespace Store_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class IndexWindow : Window
    {
        HttpClient client = new HttpClient();
        public List<DB_Item> RawProductList;
        Uri apiadress = new Uri("https://662006073bf790e070aec029.mockapi.io/Tlc/");
        string apiResource = "Store_items";
        string apiUsers = "Users";
        public DB_Item tempDbItem;
        public List<Button> buttonList = new List<Button>();
        public IndexWindow()
        {
            InitializeComponent();
            client.BaseAddress = apiadress;
            LoadUsers();
            API_Static.InitializeAPI();
            Static_Data.LoadManagerPassward();
            Initializebuttons();
        }
        public void Initializebuttons()
        {
            buttonList.Add(Add_Button);
            buttonList.Add(Delete_Button);
            buttonList.Add(Filter_Button);
            buttonList.Add(Edit_Button);
            buttonList.Add(Undermin_Button);
            buttonList.Add(Report_Button);
            foreach (Button button in buttonList)
            {
                buttonPhaseChange(button, false);
            }
            
        }
        async void LoadUsers()
        {
            var response = await client.GetAsync(apiUsers);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<Users>>();
            Static_Data.ShopWorkors = data;
        }

        public async Task<List<DB_Item>> GetItemsAsync()
        {
            var response = await client.GetAsync(apiResource);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<DB_Item>>();
            return data;
        }
        public async void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            var apiReponse = await GetItemsAsync();
            RawProductList = apiReponse;
            resultsDataGrid.ItemsSource = RawProductList;
            Static_Data.DB_Items = RawProductList;
            getComboBoxes(apiReponse);
            foreach (Button button in buttonList)
            {
                buttonPhaseChange(button, true);
            }
        }
        public void getComboBoxes(List<DB_Item> dB_Items)
        {
            var resultMainCategory = (from item in dB_Items
                                      select new Categories
                         {
                             Name = item.MainCategory.Trim()
                         });
            var tempListcat1 = resultMainCategory.Distinct().ToList();
            var DistinctCat1 = tempListcat1.GroupBy(cat => cat.Name).Select(g => g.First()).ToList();
            Static_Data.MainCatagories = DistinctCat1;
            var resultSeconderyCatagories = (from item in dB_Items
                                             select new Categories
                                             {
                                                 Name = item.SeconderyCategory.Trim()
                                             }).Distinct().ToList();
            var tempListcat2 = resultSeconderyCatagories.Distinct().ToList();
            var DistinctCat2 = tempListcat2.GroupBy( cat => cat.Name).Select( g => g.First() ).ToList();
            Static_Data.SeconderyCatagories = DistinctCat2;
            addToComboBox(Catagories1, Static_Data.MainCatagories);
            addToComboBox(Catagories2, Static_Data.SeconderyCatagories);
        }
        public void addToComboBox(ComboBox comboBox , List<Categories> categories )
        {
            comboBox.Items.Clear();
            foreach (Categories title in categories)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem() { Content= title.Name.ToString().Trim(), Tag= title.Name.ToString().Trim() };
                comboBox.Items.Add( comboBoxItem );
            }
        }
        async void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Add_EditWindow add_EditWindow = new Add_EditWindow(tempDbItem, "Add");
            add_EditWindow.ShowDialog();
            if (Static_Data.BDItem != null)
            {
                await client.PostAsJsonAsync(apiResource, Static_Data.BDItem);
                Log.addToLog($"{Static_Data.BDItem.ToString()} ,Added");
                Static_Data.BDItem = null;
                Load_Button_Click(sender, e);
                MessageBox.Show("Item Added", "Success");
            }
            else
            {
                MessageBox.Show("No Item Added","Error");
            }
        }
        async void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            int respons = Message_Box_Classes.DisplayMessageBox("Deleted items cannot be retreved are you sure", "Deleting an item");
            if (respons == 1)
            {
                if (resultsDataGrid.SelectedItem is DB_Item itemToDelete)
                {
                    if (Security.checkManagerCode())
                    {
                        await client.DeleteAsync($"{apiResource}/{itemToDelete.Index}");
                        Log.addToLog($"{itemToDelete.ToString()} ,Deleted");
                        Load_Button_Click(sender, e);
                        MessageBox.Show("Item deleted", "Success");
                    }
                }
                return;
            }
            if (respons == 2)
            {
            return;
            }
        }
        async void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (resultsDataGrid.SelectedItem != null)
            {
                Static_Data.BDItem = null;
                DB_Item dB_Item = resultsDataGrid.SelectedItem as DB_Item;
                Add_EditWindow add_EditWindow = new Add_EditWindow(dB_Item, "Edit");
                add_EditWindow.ShowDialog();
                if (Static_Data.BDItem != null)
                {
                    await client.PutAsJsonAsync($"{apiResource}/{Static_Data.BDItem.Index}", Static_Data.BDItem);
                    Log.addToLog($"{Static_Data.BDItem.ToString()} ,Edited");
                    Static_Data.BDItem = null;
                    Load_Button_Click(sender, e);
                    MessageBox.Show("Item Edited", "Success");
                    

                }
                else
                {
                    MessageBox.Show("Item Edit Error", "Error");
                }
            }
        }
        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Search.Text.ToString()))
            {
                var result = from items in RawProductList where items.ItemName.ToUpper().Contains(Search.Text.ToUpper().ToString()) select items;
                resultsDataGrid.ItemsSource = result;
                return;
            }
        }
        private void Undermin_Button_Click(object sender, RoutedEventArgs e)
        {
            var result = from items in RawProductList where items.MinAmount> items.Amount select items;
            resultsDataGrid.ItemsSource = result;
            return;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void buttonPhaseChange( Button button, bool type)
        {
            button.IsEnabled = type;
        }
        private void Catagories2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox) {
                ComboBoxItem comboBoxmain = (ComboBoxItem)Catagories1.SelectedItem;
                ComboBoxItem comboBoxsender = (ComboBoxItem)comboBox.SelectedItem;
                if (comboBoxmain == null)
                {
                    if (comboBox.SelectedItem != null)
                    {
                        if (comboBoxsender.Tag != null)
                        {
                            if (!string.IsNullOrEmpty(comboBoxsender.Tag.ToString()))
                            {
                                var result = from items in RawProductList where items.SeconderyCategory == comboBoxsender.Tag.ToString() select items;
                                resultsDataGrid.ItemsSource = result;
                                return;
                            }
                        }
                    }
                }
                else
                {
                    if (comboBox.SelectedItem != null)
                    {
                        if (comboBoxsender.Tag != null && comboBoxmain != null)
                        {
                            var result = from items in RawProductList where items.SeconderyCategory == comboBoxsender.Tag.ToString() && items.MainCategory == comboBoxmain.Tag.ToString() select items;
                            resultsDataGrid.ItemsSource = result;
                            if (result.Count() < 1)
                            {
                                result = from items in RawProductList where items.SeconderyCategory == comboBoxsender.Tag.ToString() select items;
                                resultsDataGrid.ItemsSource = result;
                                return;
                            }
                        }
                    }
                }
            }
        }
        private void Catagories1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem != null)
            {
                if (comboBox.SelectedItem is ComboBoxItem comboBoxsender && comboBoxsender.Tag != null) { 
                if (!string.IsNullOrEmpty(comboBoxsender.Tag.ToString()))
                {
                    var result = from items in RawProductList where items.MainCategory == comboBoxsender.Tag.ToString() select items;
                    resultsDataGrid.ItemsSource = result;
                }
            }
            }
        }
        private void ChangeAPIAddress_Click(object sender, RoutedEventArgs e)
        {
            if (Security.checkManagerCode())
            {
                API_Static.ChangeAPIAddress_Click();
                apiadress = API_Static.apiadress;
                apiResource = API_Static.apiResource;
            }
        }
        private void ChangePasscode_Click(object sender, RoutedEventArgs e)
        {
            Security.changeManagerCode();
        }
        private void VeiwWorkers_Click(object sender, RoutedEventArgs e)
        {
            if (Security.checkManagerCode())
            {
                UsersWindow usersWindow = new UsersWindow();
                usersWindow.ShowDialog();
            }
        }
        private void Report_Button_Click(object sender, RoutedEventArgs e)
        {
            List<DB_Item> report_list = new List<DB_Item>();
            report_list = resultsDataGrid.Items.Cast<DB_Item>().ToList();
            var number_of_field = 1;
            var title = "Name the report";
            var Input_field1 = new Input_box_field();
            Input_field1.Input_label = "Report Name";
            Input_box input_Box;
            UniversalVars.inputBoxReturn = null;
            do
            {
                input_Box = new Input_box(number_of_field, title, Input_field1);

                input_Box.ShowDialog();
                if (UniversalVars.inputBoxReturn == null)
                {
                    MessageBox.Show("Name the report", "Report is Nameless");
                }
                if (UniversalVars.inputBoxReturn != null)
                {
                    if (File.Exists($"Reports/{UniversalVars.inputBoxReturn[0].ToString()}.txt"))
                    {
                        MessageBox.Show("A report by that name already exists", "Report Exists");
                        UniversalVars.inputBoxReturn = null;
                    }
                }

            } while (UniversalVars.inputBoxReturn == null);
            if (!Directory.Exists("Reports/"))
            {
                Directory.CreateDirectory("Reports/");
            }
            File.AppendAllText($"Reports/{UniversalVars.inputBoxReturn[0].ToString()}.txt", $"{UniversalVars.inputBoxReturn[0].ToString()}____{DateTime.Now}\n");
            foreach (DB_Item item in report_list)
            {
                File.AppendAllText($"Reports/{UniversalVars.inputBoxReturn[0].ToString()}.txt", $"{item.ToString()}\n");
            }
            Log.addToLog($"Report {UniversalVars.inputBoxReturn[0].ToString()} ,Generated");
            UniversalVars.inputBoxReturn = null;
        }
    }
}