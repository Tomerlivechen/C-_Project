using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Common_Classes.Classes;
namespace Project_Gallery.Controles
{
    /// <summary>
    /// Interaction logic for CustomeMessagebox.xaml
    /// </summary>
    public partial class CustomeMessagebox : Window
    {
        public int SelectedButtonIndex { get; private set; }
        public CustomeMessagebox(MYMessageBoxobject messageBoxData)
        {
            InitializeComponent();
            DataContext = messageBoxData;
            int index = -1;
            foreach (string button in messageBoxData.buttontext)
            {
                index++;
                Button setButton = new Button{ Content = button };
                setButton.Click += (sender, e) => {
                    {
                        SelectedButtonIndex = index;
                        this.Close();
                    };
                };
                setButton.Height = 30;
                setButton.Width = 60;
                setButton.Margin = new Thickness(10);
                buttonPanel.Children.Add(setButton);
            }
        }
    }
}