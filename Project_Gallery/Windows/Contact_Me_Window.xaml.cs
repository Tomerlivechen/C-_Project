using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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
using Microsoft.VisualBasic;
using Project_Gallery.Classes;
namespace Project_Gallery.Windows
{
    /// <summary>
    /// Interaction logic for Contact_Me_Window.xaml
    /// </summary>
    public partial class Contact_Me_Window : Window
    {
        public Contact_Me_Window()
        {
            InitializeComponent();
            foreach (Contact_referances item in Static_Data.ContactReferances)
            {
                generatStackPanels(item);
            }
        }
        public void  generatStackPanels(Contact_referances Contact)
        {
            if (Contact.image != string.Empty)
            {
                Contact_Info.Children.Add(generate_contat_button(Contact));
            }
            else
            {
                Contact_Info.Children.Add(gelerateLable(Contact.title));
            }
        }
        public Label gelerateLable(string text)
        {
            Label label = new Label();
            label.Padding = new Thickness(5, 5, 0, 0);
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            label.VerticalContentAlignment = VerticalAlignment.Center;
            label.Background = Brushes.Transparent;
            label.BorderThickness = new Thickness(0);
            label.FontSize = 25;
            label.FontWeight = FontWeights.ExtraBold;
            label.Content = text;
            return label;
        }
        public Button generate_contat_button(Contact_referances Contact)
        {
            Button button = new Button();
            StackPanel stackPanel = new StackPanel();
            button.Padding = new Thickness(5, 5, 0, 0);
            button.HorizontalAlignment = HorizontalAlignment.Left;
            button.HorizontalContentAlignment = HorizontalAlignment.Center;
            button.VerticalContentAlignment = VerticalAlignment.Center;
            button.Background = Brushes.Transparent;
            button.BorderThickness = new Thickness(0);
            button.Click += (sender, e) => Contact.Run();
            stackPanel.Orientation = Orientation.Horizontal;
            Image imageObject = new Image();
            imageObject.Height = 40;
            imageObject.Margin = new Thickness(5);
            imageObject.Source = Image_load.LoadImageFromResource(Contact.image);
            imageObject.HorizontalAlignment = HorizontalAlignment.Center;
            imageObject.VerticalAlignment = VerticalAlignment.Center;
            TextBlock textBlock = new TextBlock();
            textBlock.Text = Contact.title;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.Margin = new Thickness(5);
            textBlock.FontWeight = FontWeights.Regular;
            textBlock.FontSize = 25;
            textBlock.FontFamily = new FontFamily("Times New Roman");
            stackPanel.Children.Add(imageObject);
            stackPanel.Children.Add(textBlock);
            button.Content = stackPanel;
            return button;
        }
    }
}
