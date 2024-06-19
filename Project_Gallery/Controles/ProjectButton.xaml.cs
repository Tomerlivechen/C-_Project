using Common_Classes;
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
    /// Interaction logic for ProjectButton.xaml
    /// </summary>
    public partial class ProjectButton : UserControl
    {
        public ProjectButton(IProjectMeta project , SolidColorBrush buttonColor)
        {
            InitializeComponent();
            DataContext = project;
            MainButton.Background = buttonColor;
            MainButton.Click += (sender, e) => project.Run();
        }
    }
}
