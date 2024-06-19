using Common_Classes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Speed_Racer.Windows;
namespace Speed_Racer
{
    internal class Opening_Panel : IOpening_Panel
    {
        public string Name { get; set; } = "Fury Road";
        public string Description { get; set; } = "This game was initially made to be a street racer game, but I decided to give it a more post-apocalyptic flavor using game images from the internet.\r\nThe goal is to reach the end of the route; your relative position is displayed in the top panel.\r\nYou control the car using the mouse to move left and right, W to accelerate, and S to decelerate. P pauses the game.\r\nYou need to collect fuel to keep your fuel tank topped off, repair kits to repair your car in case of collisions, and chocolate for points.\r\nYou must avoid obstacles on the road such as flipped cars and debris and avoid cars driving at you. (Collision means you lose a repair kit, and eventually game over).\r\nChoose a difficulty; the harder it is the more cars and obstacles you will face, and the longer the route.\r\nNote: Hard difficulty has no roadside protection – collide with the side of the road and lose a repair kit (or lose the game).";
        public List<string> Tags { get; set; } = new List<string>() { "CSharp", "WPF", "OOP", "JSON" };
        public BitmapImage buttonImage
        {
            get
            {
                string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                Uri uri = new Uri($"pack://application:,,,/{assemblyName};component/Resources/IndexImage.png");
                return new BitmapImage(uri);
            }
            set { }
        }
        public void Run()
        {
            IndexWindow window = new IndexWindow();
            window.ShowDialog();
        }
    }
}
