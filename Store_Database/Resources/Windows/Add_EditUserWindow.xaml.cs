using Common_Classes.Classes;
using Store_Database.Resources.Classes;
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
namespace Store_Database.Resources.Windows
{
    /// <summary>
    /// Interaction logic for Add_EditUserWindow.xaml
    /// </summary>
    public partial class Add_EditUserWindow : Window
    {
        Users? Import_user = new Users();
        string AddorEdit;
        bool validateed = false;
        public Add_EditUserWindow(string addOrEdit, Users? user=null ) {
            Import_user = user;
            AddorEdit = addOrEdit;
            InitializeComponent();
            InitilizeFiealds();
            Closed += Add_EditUserWindow_Closed;
        }

        private void Add_EditUserWindow_Closed(object? sender, EventArgs e)
        {
            if (!validateed)
            {
                Static_Data.tempUser = null;
            }
        }

        private void InitilizeFiealds()
        {
            if (AddorEdit == "Edit")
            {
                Title.Content = "Edit Worker";
                ID_text.Text = Import_user.ID.ToString();
                Name_text.Text = Import_user.Name.ToString();
                Start_text.Text = Import_user.StartDate;
                Start_text.IsReadOnly = true;
                if (Import_user.EndDate != null)
                {
                    End_text.Text = Import_user.EndDate;

                }
                End_text.IsReadOnly = true;
                Manager_Check.IsChecked = Import_user.Manager;
                Still_Check.IsChecked = Import_user.StillEmployed;
            }
            if (AddorEdit == "Add")
            {
                Title.Content = "Add New Worker";
                Start_text.Text = DateTime.Now.ToShortDateString();
                Start_text.IsReadOnly = true;
                Still_Check.IsChecked = true;
                Still_Check.IsEnabled = false;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Security.checkManagerCode())
            {
                if (string.IsNullOrWhiteSpace(ID_text.Text) || string.IsNullOrEmpty(ID_text.Text))
                {
                    MessageBox.Show("Worker must have ID");
                    return;
                }
                if (string.IsNullOrWhiteSpace(Name_text.Text) || string.IsNullOrEmpty(Name_text.Text))
                {
                    MessageBox.Show("Worker must have a name");
                    return;
                }
                validateed = true;
                if (AddorEdit == "Edit" && ID_text.Text != Import_user.ID.ToString())
                {
                    Static_Data.tempUser = Import_user;
                    Static_Data.tempUser2 = new Users() { Index = Import_user.Index, ID = ID_text.Text, Name = Name_text.Text.FirstCapitalMulti(), StartDate = Start_text.Text, StillEmployed = Still_Check.IsChecked ?? false, Manager = Manager_Check.IsChecked ?? false, EndDate = End_text.Text };
                    Close();
                    return;
                }
                if (AddorEdit == "Edit" && ID_text.Text == Import_user.ID.ToString())
                {
                    Static_Data.tempUser = new Users() { Index = Import_user.Index, ID = ID_text.Text, Name = Name_text.Text.FirstCapitalMulti(), StartDate = Start_text.Text, StillEmployed = Still_Check.IsChecked ?? false, Manager = Manager_Check.IsChecked ?? false, EndDate = End_text.Text };
                    Close();
                    return;
                }
                if (AddorEdit == "Add")
                {
                    bool isRepeatID = false;
                    foreach (Users user in Static_Data.ShopWorkors)
                    {
                        if (user.ID == ID_text.Text)
                        {
                            isRepeatID = true;
                            MessageBox.Show("The ID is alredy in use");
                            break;
                        }
                    }
                    if (isRepeatID == false)
                    {
                        Static_Data.tempUser = new Users(Name_text.Text.FirstCapitalMulti(), ID_text.Text, true, Manager_Check.IsChecked ?? false, Static_Data.ShopWorkors.Count());
                        Close();
                        return;
                    }
                }
            }
        }
    }
}
