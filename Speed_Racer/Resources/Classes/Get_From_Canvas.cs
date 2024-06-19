using System.Windows;
using System.Windows.Controls;
namespace Speed_Racer.Resources.Classes
{
    public static class Get_From_Canvas
    {
        public static double[] Getposition(UIElement element)
        {
            double currentX = Canvas.GetLeft(element);
            double currentY = Canvas.GetTop(element);
            double[] respons = new double[] { currentX, currentY };
            return respons;
        }
    }
}
