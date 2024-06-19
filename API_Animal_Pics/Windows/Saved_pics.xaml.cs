using API_Animal_Pics.Resources;
using Common_Classes;
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
using API_Animal_Pics.Classes;
using Common_Classes.Classes;
using System.Security.Cryptography.X509Certificates;
namespace API_Animal_Pics.Windows
{
    /// <summary>
    /// Interaction logic for Saved_pics.xaml
    /// </summary>
    public partial class Saved_pics : Window
    {
        public string listName;
        public Saved_pics(Animallist animallist)
        {

            listName = $"List name: {animallist.Name}";
            InitializeComponent();
            InitializeImages();
            Initializeboard(animallist);
            Closed += Window_Closed;
            List_Name.Text = listName;
        }
        void Initializeboard(Animallist animallist)
        { 
            foreach (AnimalPic pic in animallist.animalPics)
            {
                PicInFavList New_Pic = new PicInFavList(pic, animallist)
                {
                    Margin = new Thickness(3),
                    Height = 234,
                    Width = 193,
                };
                ImageSet.Children.Add(New_Pic);
            }
        }
        public void Window_Closed(object sender, EventArgs e)
        {
            if (GlobalVars.changes > 0)
            {
                int respons = Message_Box_Classes.DisplayMessageBox("Save before closeing?", "Close");
                if (respons == 1)
                {
                    GlobalVars.SavePiclists();
                    GlobalVars.CheckDuplicate();
                }
                else { return; }
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            GlobalVars.SavePiclists();
            GlobalVars.CheckDuplicate();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void InitializeImages()
        {
            Table.Source = GlobalVars.SetImageForSource("Table_Top.png");
        }
        
    }
}
