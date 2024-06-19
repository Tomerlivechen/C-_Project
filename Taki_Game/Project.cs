using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Reflection;
using Taki_Game.Resources.Controls;
using System.Numerics;
using System.Collections;
using System.Windows.Controls;
using Common_Classes;
using Common_Classes.Common_Elements;
using static System.Formats.Asn1.AsnWriter;
using Taki_Game.Resources.Classes;
using Taki_Game.Resources.Windows;
namespace Taki_Game
{
    public class Project : IProjectMeta
    {
        public string Name { get; set; } = "TAKI Game";
        public BitmapImage Image
        {
            get
            {
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                Uri uri = new Uri($"pack://application:,,,/{assemblyName};component/Resources/IndexImage.png");
                return new BitmapImage(uri);
            }
        }
        public void Run()
        {
            Opening_Panel OpeningPanel = new Opening_Panel();
            OpeningPanel.buttonImage = Image;
            Opening_panel_window window = new Opening_panel_window(OpeningPanel);
            window.ShowDialog();
        }
    }
}