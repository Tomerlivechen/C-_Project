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
    /// Interaction logic for Cocktail_recipes.xaml
    /// </summary>
    public partial class Cocktail_recipes : Window
    {
        Cocktail cocktail_Data = new Cocktail();
        public Cocktail_recipes(Cocktail cocktail)
        {
            InitializeComponent();
            
            cocktail_Data = cocktail;
            Title.Content = (string)cocktail_Data.Name.FirstLetterToUpper() ;
            Ingredients.Text = "";
            foreach (string item in cocktail_Data.Ingredients)
            {
                Ingredients.Text += item + "\n";
            }
            Instructions.Text = cocktail_Data.Instructions;
        }
    }
}