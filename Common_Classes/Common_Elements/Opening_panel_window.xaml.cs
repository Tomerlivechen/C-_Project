using Common_Classes.Classes;
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

namespace Common_Classes.Common_Elements
{
    /// <summary>
    /// Interaction logic for Opening_panel_window.xaml
    /// </summary>
    public partial class Opening_panel_window : Window
    {
        public Opening_panel_window(IOpening_Panel Open_panal_data)
        {
            InitializeComponent();
            ProjectName.Text = Open_panal_data.Name.ToString();

            foreach (string tag in Open_panal_data.Tags)
            {

                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                Uri uri = new Uri($"pack://application:,,,/{assemblyName};component/Resources/Tech_images/{tag}.png");
                BitmapImage tagImage = new BitmapImage(uri);
                Image image = new Image();
                image.Source = tagImage;
                image.Height = 50;
                image.Width = 50;
                image.Margin = new Thickness(5);
                Tech_panel.Children.Add(image);

            }

            TextBlock textBlock = new TextBlock();
            textBlock.Text = Open_panal_data.Description;
            textBlock.FontSize = 20;
            textBlock.TextWrapping = TextWrapping.Wrap;
            help_panel.Children.Add(textBlock);

            ButtonImage.Source = Open_panal_data.buttonImage;

            Run_project.Click += (sender, e) => Open_panal_data.Run();

        }

        private void Back_click(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
