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
    /// Interaction logic for Receipt.xaml
    /// </summary>
    
    public partial class Receipt : Window
    {
        public string _title;
        public string _serving;
        public string _ingredients;
        public string[] ingredientsList;
        public string ingredients_List="";
        public string _instructions;
        public Receipt(Recipe recipe)
        {
            InitializeComponent();
            _title = recipe.title.FirstLetterToUpper();
            _serving = recipe.servings;
            _ingredients = recipe.ingredients;
            _instructions = recipe.instructions;
            ingredientsList = _ingredients.Split('|');
            foreach (var item in ingredientsList)
            {
                ingredients_List += item.ToString();
                ingredients_List += "\n";
            }
            Title.Content = _title;
            Serving_size.Text = "Serving size: " + _serving;
            Ingredients.Text = ingredients_List;
            Instructions.Text = _instructions;
        }
    }
}