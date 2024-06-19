using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Common_Classes.Classes
{
    public class MYMessageBoxobject
    {
        static Uri imageDefault = new Uri(
            $"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/Resources/Error.png"
        );
        public string message { get; set; } = "Defalt message";
        public string caption { get; set; } = "Defalt message";
        public string[] buttontext { get; set; } = { "OK" };
        public bool[] buttonRespons { get; set; } = { false };
        public BitmapImage image { get; set; } = new BitmapImage(imageDefault);

        public MYMessageBoxobject(string _caption, string _message)
        {
            message = _message;
            caption = _caption;
        }

        public MYMessageBoxobject() { }

        public MYMessageBoxobject(
            string _caption,
            string _message,
            string[] _buttonText,
            bool[] _buttonRespons,
            Delegate[] delegates
        )
        {
            message = _message;
            caption = _caption;
            buttontext = _buttonText;
            buttonRespons = _buttonRespons;
        }
    }
}
