using Speed_Racer.Resources.Controls;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace Speed_Racer.Resources.Classes
{
    public static class Move_objects
    {
        public static void MoveAllObjects(Canvas Track_Canvas, int difficalty, double Speed)
        {
            foreach (var obj in Track_Canvas.Children)
            {
                if (obj is Image movable)
                {
                    if (movable.Tag != null)
                    {
                        string[] parts = movable.Tag.ToString().Split(' ');
                        int.TryParse(parts[1], out int speed);
                        moveObject(movable, speed, difficalty, Speed);
                    }
                }
                if (obj is Colectable goody)
                {
                    
                    moveObject(goody, 1, difficalty, Speed);
                }
            }
        }
        public static void moveObject(UIElement element, int speed, int difficalty, double Speed)
        {
            Random rnd = new Random();
            string designation;
            double[] position = Get_From_Canvas.Getposition(element);
            Canvas.SetTop(element, position[1] + speed * (difficalty + 1) * Speed);
            if (position[1] > 800 )
            {
                if (element is Image image)
                {
                    int newSpeed = rnd.Next(1, 6);
                    if (newSpeed == 1)
                    {
                        designation = "terrane";
                    }
                    else
                    {
                        designation = "Car";
                    }
                    image.Tag = $"{designation} {newSpeed}";
                    image.Source = Image_Import.LoadImageFromResource($"{changeCarImageBySpeed(newSpeed)}.png");
                    Canvas.SetLeft(element, rnd.Next(0, 300));
                }
                if (element is Colectable goody)
                {
                    int seperator = 1;
                    goody.Visibility = Visibility.Visible;
                    if (goody.Tag.ToString() == "Fix") { seperator = 3; }
                    Canvas.SetLeft(goody, rnd.Next(0, 300));
                    Canvas.SetTop(goody, -1 * (500 + 150 * rnd.Next(seperator*3, seperator*8)));
                    return;
                }
                Canvas.SetTop(element, -1 * (500 + 150 * rnd.Next(2, 5)));
            }
        }
        public static string changeCarImageBySpeed(int newspeed)
        {
            Random rnd = new Random();
            switch (newspeed)
            {
                case 1:
                    int random = rnd.Next(0, 2);
                    if (random == 0)
                    {
                        return "Debris";
                    }
                    else
                    {
                        return "FlippedCar";
                    }
                    break;
                case 2:
                    return "HunterCar";
                    break;
                case 3:
                    return "VanCar";
                    break;
                case 4:
                    return "ArmoredCar";
                    break;
                case 5:
                    return "BattleCar";
                    break;
                default:
                    return "Debris";
            }
        }
    }
}
