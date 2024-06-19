using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
namespace Common_Classes.Classes
{
    public class My_Message_Box_Classes
    {
        public static MessageBoxResult Show(MYMessageBoxobject messagebox)
        {
            Window window = new Window
            {
                Title = messagebox.caption,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize,
                SizeToContent = SizeToContent.WidthAndHeight,
                Content = messagebox.message
            };
            StackPanel buttonPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0)
            };
            int index = -1;
            foreach (string button in messagebox.buttontext)
            {
                index++;
                Button setButton = new Button { Content = button };
                setButton.Click += (sender, e) =>
                {
                    //                messagebox.buttonCommands[index]?.DynamicInvoke();
                    window.DialogResult = messagebox.buttonRespons[index];
                    window.Close();
                };
                buttonPanel.Children.Add(setButton);
            }
            window.Content = new StackPanel
            {
                Children =
            {
                new TextBlock { Text = messagebox.message, Margin = new Thickness(10) },
                buttonPanel
            }
            };
            window.Icon = messagebox.image;
            window.ShowDialog();
            return (bool)window.DialogResult.HasValue ? MessageBoxResult.OK : MessageBoxResult.None;
        }
    }
}
