using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Text.Json;
using System.Windows;
using Common_Classes;
using Common_Classes.Common_Elements;
using Frogger.Windows;
namespace Frogger
{
    public class Project : IProjectMeta
    {

        public string Name { get; set; } = "Frogger";


        public BitmapImage Image
        {
            get
            {
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                Uri uri = new Uri($"pack://application:,,,/{assemblyName};component/Resources/IndexImage.png");
                return new BitmapImage(uri);

            }
        }
        //   public BitmapImage Image => new BitmapImage(new Uri($"{AppDomain.CurrentDomain.BaseDirectory}/Resources/IndexImage1.png", UriKind.Absolute));

        public void Run()
        {
            Opening_Panel OpeningPanel = new Opening_Panel();
            OpeningPanel.buttonImage = Image;
            Opening_panel_window window = new Opening_panel_window(OpeningPanel);
            window.ShowDialog();
        }
    }
}
