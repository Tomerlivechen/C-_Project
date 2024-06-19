using Speed_Racer.Resources.Controls;
using Speed_Racer.Windows;
using System.Windows;
using System.Windows.Controls;
namespace Speed_Racer.Resources.Classes
{
    public static class Collisions
    {
        public static void CheckEnemyCollision(List<Image> enimyCars)
        {
            foreach (Image car in enimyCars)
            {
                foreach (Image car2 in enimyCars)
                {
                    if (car != car2)
                    {
                        int verticalTolerance = (((int)car.ActualWidth + (int)car2.ActualWidth) / 2);
                        int horizontalTolerance = (((int)car.ActualHeight + (int)car2.ActualHeight) / 2);
                        double[] carPosition = Get_From_Canvas.Getposition(car);
                        double[] car2Position = Get_From_Canvas.Getposition(car2);
                        if (carPosition[1] > car2Position[1] - horizontalTolerance && carPosition[1] < car2Position[1] + horizontalTolerance && carPosition[0] > car2Position[0] - verticalTolerance && carPosition[0] < car2Position[0] + verticalTolerance)
                        {
                        if (car.Visibility == Visibility.Visible && car2.Visibility == Visibility.Visible)
                        {
                            if (car.Tag.ToString() != "terrane 1")
                            {
                            car.Tag = $"terrane 1";
                            car.Source = Image_Import.LoadImageFromResource($"FlippedCar.png");
                            }
                            if (car2.Tag.ToString() != "terrane 1")
                            {
                            car2.Tag = $"terrane 1";
                            car2.Source = Image_Import.LoadImageFromResource($"FlippedCar.png");
                            }
                        }
                        }
                    }
                }
            }
        }
        public static void CheckCollision(List<Image> enimyCars, Image player, Game_Window Game_Window)
        {
            double[] carPosition = Get_From_Canvas.Getposition(player);
            foreach (Image movable in enimyCars)
            {
                int verticalTolerance = (((int)movable.ActualWidth + (int)player.ActualWidth) / 2)-5;
                int horizontalTolerance = (((int)movable.ActualHeight + (int)player.ActualHeight) / 2)-5;
                double[] ElementPosition = Get_From_Canvas.Getposition(movable);
                if (carPosition[1] > ElementPosition[1] - horizontalTolerance && carPosition[1] < ElementPosition[1] + horizontalTolerance)
                {
                    if (carPosition[0] > ElementPosition[0] - verticalTolerance && carPosition[0] < ElementPosition[0] + verticalTolerance)
                    {
                        if (movable.Visibility == Visibility.Visible && (movable.Tag.ToString().Contains("Car") || movable.Tag.ToString().Contains("terrane")))
                        {
                         Game_Window.Death();
                         return;
                        }
                    }
                }
            }
        }
        public static void CheckGoodCollision(List<Colectable> colectables, Image player, Race_Game NewGame)
        {
            double[] carPosition = Get_From_Canvas.Getposition(player);
            foreach (Colectable goody in colectables)
            {
                int verticalTolerance = (((int)goody.ActualWidth + (int)player.ActualWidth)/2)+5;
                int horizontalTolerance = (((int)goody.ActualHeight + (int)player.ActualHeight) / 2)+5;
                double[] ElementPosition = Get_From_Canvas.Getposition(goody);
                if (carPosition[1] > ElementPosition[1] - horizontalTolerance && carPosition[1] < ElementPosition[1] + horizontalTolerance &&
                    carPosition[0] > ElementPosition[0] - verticalTolerance && carPosition[0] < ElementPosition[0] + verticalTolerance)
                {
                    if (goody.Visibility == Visibility.Visible)
                    {
                        goody.Visibility = Visibility.Collapsed;
                        switch (goody.Tag.ToString())
                        {
                            case "Fule":
                                NewGame.AddFule();
                                break;
                            case "Fix":
                                NewGame.AddRepair();
                                break;
                            case "Chocolate":
                                NewGame.addToScore(100);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
