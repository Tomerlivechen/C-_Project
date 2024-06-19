using Common_Classes.Classes;
using Common_Classes.Common_Elements;
using Store_Database.Resources.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using System.Windows.Xps.Packaging;
namespace Store_Database.Resources.Windows
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        HttpClient client = new HttpClient();
        Uri apiadress = new Uri("https://662006073bf790e070aec029.mockapi.io/Tlc/");
        string apiUsers = "Users";
        public UsersWindow()
        {
            InitializeComponent();
            client.BaseAddress = apiadress;
            UserGrid.ItemsSource = Static_Data.ShopWorkors;
        }
        async void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (UserGrid.SelectedItem != null)
            {
                Static_Data.tempUser = null;
                Static_Data.tempUser2 = null;
                Users user = UserGrid.SelectedItem as Users;
                Add_EditUserWindow add_EditUserWindow = new Add_EditUserWindow("Edit",user );
                add_EditUserWindow.ShowDialog();
                if (Static_Data.tempUser2 != null)
                {
                    await client.DeleteAsync($"{apiUsers}/{Static_Data.tempUser.Index}");
                    await client.PostAsJsonAsync(apiUsers, Static_Data.tempUser2);
                    Log.addToLog($"{Static_Data.tempUser2.ToString()} ,Worker ,Edited");
                    MessageBox.Show("Worker edited", "Success");
                    Static_Data.tempUser = null;
                    Static_Data.tempUser2 = null;
                    LoadUsers();
                    return;
                }
                if (Static_Data.tempUser2 == null && Static_Data.tempUser != null)
                {
                    await client.PutAsJsonAsync($"{apiUsers}/{Static_Data.tempUser.Index}", Static_Data.tempUser);
                    Log.addToLog($"{Static_Data.tempUser.ToString()} ,Worker ,Edited");
                    MessageBox.Show("Worker edited", "Success");
                    Static_Data.tempUser = null ;
                    Static_Data.tempUser2 = null;
                    LoadUsers();
                    return;
                }
                else
                {
                    MessageBox.Show("Worker not edited", "Error");
                    Static_Data.tempUser = null;
                    Static_Data.tempUser2 = null;
                    return;
                }
            }
        }
        async void LoadUsers()
        {
            var response = await client.GetAsync(apiUsers);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<List<Users>>();
            Static_Data.ShopWorkors = data;
            UserGrid.ItemsSource = Static_Data.ShopWorkors;
        }
        async void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Static_Data.tempUser = null;
            Add_EditUserWindow add_EditUserWindow = new Add_EditUserWindow("Add");
            add_EditUserWindow.ShowDialog();
            if (Static_Data.tempUser != null)
            {
                await client.PostAsJsonAsync(apiUsers, Static_Data.tempUser);
                Log.addToLog($"{Static_Data.tempUser.ToString()} ,Worker ,Added");
                Static_Data.tempUser = null;
                MessageBox.Show("Worker added", "Success");
                LoadUsers();
            }
            else
            {
                MessageBox.Show("No worker added", "Error");
            }
        }
        async void LetGo_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Security.checkManagerCode())
            {
                if (UserGrid.SelectedItem != null)
                {
                    Users user = UserGrid.SelectedItem as Users;
                    user.LetGo();
                    await client.PutAsJsonAsync($"{apiUsers}/{user.Index}", user);
                    Log.addToLog($"{user.ToString()} ,Worker , Let Go");
                    LoadUsers();
                }
            }
        }
        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            var result = from users in Static_Data.ShopWorkors where users.Name.ToUpper().Contains(Filter_Text.Text.ToUpper().ToString()) select users;
            UserGrid.ItemsSource = result;
        }
        private void Only_Managers_Click(object sender, RoutedEventArgs e)
        {
                var result = from users in Static_Data.ShopWorkors where users.Manager == true select users;
                UserGrid.ItemsSource = result;
        }
        private void Only_Workers_Click(object sender, RoutedEventArgs e)
        {
            var result = from users in Static_Data.ShopWorkors where users.Manager == false select users;
            UserGrid.ItemsSource = result;
        }
        private void Only_Employed_Click(object sender, RoutedEventArgs e)
        {
            var result = from users in Static_Data.ShopWorkors where users.StillEmployed == true select users;
            UserGrid.ItemsSource = result;
        }
        private void Report_Button_Click(object sender, RoutedEventArgs e)
        {
            List<Users> report_list = new List<Users>();
            report_list = UserGrid.Items.Cast<Users>().ToList();
            bool hasInput = false;
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
            foreach (Users item in report_list)
            {
                File.AppendAllText($"Reports/{UniversalVars.inputBoxReturn[0].ToString()}.txt", $"{item.ToString()}\n");
            }
            Log.addToLog($"Report {UniversalVars.inputBoxReturn[0].ToString()} , Generated");
            UniversalVars.inputBoxReturn = null;
        }
    }
    
}
