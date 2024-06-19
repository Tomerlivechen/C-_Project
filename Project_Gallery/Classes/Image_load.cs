using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
namespace Project_Gallery.Classes
{
    public static class Image_load
    {
        public static BitmapImage LoadImageFromResource(string resourceName)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var uri = new Uri(
                $"pack://application:,,,/{assemblyName};component/Resources/Contact_me_images/{resourceName}"
            );
            try
            {
                return new BitmapImage(uri);
            }
            catch
            {
                return new BitmapImage();
            }
        }
    }
}
