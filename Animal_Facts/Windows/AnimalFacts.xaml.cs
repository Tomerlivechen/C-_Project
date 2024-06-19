using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Xml.Linq;
using API_hub.Classes;
namespace API_hub.Windows
{
    /// <summary>
    /// Interaction logic for Animal.xaml
    /// </summary>
    
    public partial class AnimalFacts : Window
    {
        Animal animal = new Animal();
        public AnimalFacts(Animal animal)
        {
            InitializeComponent();
            this.animal = animal;
            Name.Content = animal.name.FirstLetterToUpper(); ;
            if (animal.locations != null)
            {
                location.Text = "";
                foreach (string place in animal.locations)
                {
                    location.Text += $"{place} ";
                }
                
            }
            else
            {
                location.Text = "";
                Habitat.Content = "";
            }
            Type type = typeof(Taxonomy);
            string index = "  ";
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.GetValue(animal.taxonomy) != null)
                {
                    TextBlock textBlock = new TextBlock();
                    Run title = new Run($"{index}{prop.Name.Makelable()}: ")
                    {
                        FontWeight = FontWeights.Bold
                    };
                    Run data = new Run($"{prop.GetValue(animal.taxonomy)}");
                    textBlock.Inlines.Add(title);
                    textBlock.Inlines.Add(data);
                    textBlock.FontSize = 20;
                    Taxomony_Stack.Children.Add(textBlock);
                    index += "  ";
                }
            }
            Type type1 = typeof(Characteristics);
            
            foreach (PropertyInfo prop in type1.GetProperties())
            {
                if (prop.GetValue(animal.characteristics) != null)
                {
                    TextBlock textBlock = new TextBlock();
                    Run title = new Run($"{prop.Name.Makelable()}: ")
                    {
                        FontWeight = FontWeights.Bold
                    };
                    Run data = new Run($"{prop.GetValue(animal.characteristics)}");
                    textBlock.Inlines.Add( title );
                    textBlock.Inlines.Add(data);
                    textBlock.FontSize = 20;
                    textBlock.TextWrapping = TextWrapping.Wrap;
                    textBlock.Width = 600;
                    Characteristics_Stack.Children.Add(textBlock);
                }
            }
        }
    }
}
