﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Common_Classes;
using Common_Classes.Common_Elements;
namespace Memory_game
{
    public class Project : IProjectMeta
    {
        public string Name { get; set; } = "Memory Game";
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