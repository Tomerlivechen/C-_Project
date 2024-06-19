using System.Reflection;
using System.Windows.Media.Imaging;
namespace Speed_Racer.Resources.Classes
{
    public static class Image_Import
    {
        public static BitmapImage LoadImageFromResource(string resourceName)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var uri = new Uri(
                $"pack://application:,,,/{assemblyName};component/Resources/Images/{resourceName}"
            );
            return new BitmapImage(uri);
        }
    }
}
