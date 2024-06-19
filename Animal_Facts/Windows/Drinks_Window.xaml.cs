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
using API_hub.Classes;
namespace API_hub.Windows
{
    /// <summary>
    /// Interaction logic for Drinks_Window.xaml
    /// </summary>
    
    public partial class Drinks_Window : Window
    {
        Drink drink = new Drink();
        public Drinks_Window(Drink passed_drink)
        {
            InitializeComponent();
            drink = passed_drink;
            Title.Content = drink.Name.FirstLetterToUpper(); ;
            Ingredients.Text = "";
            for (int i = 1; i <= 15; i++)
            {
                string ingredient = (string)drink.GetType().GetProperty("Ingredient_" + i).GetValue(drink);
                string measurement = (string)drink.GetType().GetProperty("Measurement_" + i).GetValue(drink);
                if (ingredient != null)
                {
                    Ingredients.Text += measurement + " " + ingredient + "\n";
                }
            }
            glass.Content += drink.Glass_Type;
            Instructions.Text = drink.Instructions;
            picture.Source = setImagetoObject(drink.Picture_link);
        }
        public BitmapImage setImagetoObject(string imageUrl)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imageUrl);
                bitmap.EndInit();
                return bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
                return null;
            }
        }
    }
}