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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Common_Classes;
using Common_Classes.Classes;
using API_Animal_Pics.Classes;
using static System.Net.Mime.MediaTypeNames;
namespace API_Animal_Pics.Resources
{
    /// <summary>
    /// Interaction logic for PicInFavList.xaml
    /// </summary>
    public partial class PicInFavList : UserControl
    {
        public string listName;
        public PicInFavList(AnimalPic pic, Animallist animallist)
        {
            InitializeComponent();
            InitializeImages();
            listName = animallist.Name;
            DataContext = pic;
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(pic.url);
                    bitmap.EndInit();
                main_image.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            FillScreen_Button.Click += (sender, e) =>
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = pic.url,
                    UseShellExecute = true
                };
                Process.Start(psi);
            };
            Trash_Button.Click += (sender, e) =>
            {
                int respons = Message_Box_Classes.DisplayMessageBox("Are you sure you want to delete image?", "Delete image");
                if (respons == 1)
                {
                    GlobalVars.RemovePic(listName, pic);
                    removePic(this);
                }
                else { return; }
            };
        }
        public void removePic(PicInFavList pic)
        {
            pic.Visibility = Visibility.Collapsed;
        }
        public void InitializeImages()
        {
            FillScreen.Source = GlobalVars.SetImageForSource("fullscreen.png");
            Trash.Source = GlobalVars.SetImageForSource("trash.png");
        }
    }
}
