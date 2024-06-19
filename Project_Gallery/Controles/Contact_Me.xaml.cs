using Project_Gallery.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace Project_Gallery.Controles
{
    /// <summary>
    /// Interaction logic for Contact_Me.xaml
    /// </summary>
    public partial class Contact_Me : UserControl
    {
        public Contact_Me()
        {
            InitializeComponent();
        }
        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            Contact_Me_Window contact_Me_Window = new Contact_Me_Window();
            contact_Me_Window.ShowDialog();
        }
    }
}
