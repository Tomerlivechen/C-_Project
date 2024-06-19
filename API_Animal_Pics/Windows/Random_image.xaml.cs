using Common_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using API_Animal_Pics.Classes;
using Common_Classes.Classes;
using WpfAnimatedGif;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media.Animation;
namespace API_Animal_Pics.Windows;
/// <summary>
/// Interaction logic for Random_image.xaml
/// </summary>
public partial class Random_image : Window
{
    DispatcherTimer timer3 = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(3) };
    public HttpClient client = new HttpClient();
    public string animallistname;
    public AnimalPic currentPic = new AnimalPic();
    public Random_image(Animallist animallist)
    {
        animallistname = animallist.Name;
        InitializeComponent();
        InitializeImages();
        Closed += Window_Closed;
        timer3.Tick += Timed_03_Actions;
        List_Lable.Content = $"Add images to list: {animallistname}";
        timer3.Start();
    }
    public void InitializeImages()
    {
        Loading_pic.Source = GlobalVars.SetImageForSource("Loading.png");
    }
    private void Timed_03_Actions(object sender, EventArgs e)
    {
        Status_Bar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FBFBFB"));
        Status_Bar.Text= string.Empty;
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
    private async void Button_ClickAsync(object sender, RoutedEventArgs e)
    {
        Loading_pic.Visibility = Visibility.Visible;
        try
        {
            Button button = (Button)sender;
            string Animalimage = await GetPicAPI(button.Tag.ToString());
            if (!string.IsNullOrEmpty(Animalimage))
            {
                BitmapImage bitmap = SetImageSource(Animalimage);
                Animal_pic.Source = bitmap;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading image: {ex.Message}");
        
    }
        finally
        {
            Loading_pic.Visibility = Visibility.Hidden;
        }
    }
    private async Task<string> GetPicAPI(string type)
    {
        string response = "";
        if (type == "Dog") { response = await client.GetStringAsync($"https://api.thedogapi.com/v1/images/search"); }
        if (type == "Cat") { response = await client.GetStringAsync($"https://api.thecatapi.com/v1/images/search"); }
        if (type == "Fox")
        {
            response = await client.GetStringAsync($"https://randomfox.ca/floof/?ref=apilist.fun");
            AnimalPic? Foxjson = JsonSerializer.Deserialize<AnimalPic>(response);
            Uri uri = new Uri(Foxjson.link);
            string query = uri.Query;
            currentPic.id = $"Fox_{query}";
            currentPic.url = Foxjson.image;
            return Foxjson.image;
        }
        if (type == "Bear")
        {
            Random random = new Random();
            int width = random.Next(100, 8000);
            int hight = random.Next(100, 8000);
            currentPic.width = width;
            currentPic.height = hight;
            currentPic.url= $"https://placebear.com/{width}/{hight}.jpg";
            currentPic.id = $"{width}x{hight}";
            return $"https://placebear.com/{width}/{hight}.jpg";
        }
        try
        {
            List<AnimalPic>? json = JsonSerializer.Deserialize<List<AnimalPic>>(response);
            currentPic = json[0];
            return (json[0].url);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"API Error: {ex.Message}");
            return null;
        }
    }

    private BitmapImage SetImageSource(string imageUrl)
    {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imageUrl);
            bitmap.EndInit();
            return bitmap;
    }
    private void Save_image_Click(object sender, RoutedEventArgs e)
    {
        if (currentPic.url != null)
        {
            GlobalVars.changes++;
            Status_Bar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#74b8FC"));
            Status_Bar.Text = "Image saved To list";
            GlobalVars.AddPic(animallistname, currentPic);
            GlobalVars.SavePiclists();
        }
    }
    private void Close_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
    private void Save_image_list_Click(object sender, RoutedEventArgs e)
    {
        GlobalVars.changes++;
        Status_Bar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#74b8FC"));
        Status_Bar.Text = "List saved";
        GlobalVars.SavePiclists();
        GlobalVars.CheckDuplicate();
    }
}
