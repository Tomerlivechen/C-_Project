using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
namespace Frogger.Classes
{
    public static class Frogger_Classes
    {
        public static BitmapImage LoadImageFromResource(string resourceName)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var uri = new Uri(
                $"pack://application:,,,/{assemblyName};component/Resources/{resourceName}"
            );
            return new BitmapImage(uri);
        }
    }
}
