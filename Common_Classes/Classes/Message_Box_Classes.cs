using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Common_Classes.Classes
{
    public static class Message_Box_Classes
    {
        public static int DisplayMessageBox(string message, string caption)
        {
            CustumMessageBox messageBox = new CustumMessageBox();
            MessageBoxResult result = messageBox.Show(
                message,
                caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );
            if (result == MessageBoxResult.Yes)
            {
                return 1;
            }
            else if (result == MessageBoxResult.No)
            {
                return 2;
            }
            return 0;
        }
        public static string PiorityMesageBox(string Object1, string Object2)
        {
            CustumMessageBox messageBox = new CustumMessageBox();
            string message = $"Is {Object1} of higher priority than {Object2} ?";
            string caption = "Priority Qestion";
            MessageBoxResult result = messageBox.Show(
                message,
                caption,
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );
            if (result == MessageBoxResult.Yes)
            {
                return Object1;
            }
            else if (result == MessageBoxResult.No)
            {
                return Object2;
            }
            return null;
        }
    }
    public class CustumMessageBox
    {
        public MessageBoxResult Show(
            string messageBoxText,
            string caption,
            MessageBoxButton button,
            MessageBoxImage icon
        )
        {
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            return result;
        }
    }
}