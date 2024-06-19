using Common_Classes;
using Project_Gallery.Controles;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrioratyDefiner;
using System.Drawing;
using ColorConverter = System.Drawing.ColorConverter;
namespace Project_Gallery;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private IProjectMeta[] Projects = new IProjectMeta[]
    {
        new API_Animal_Pics.Project(),
        new API_hub.Project(),
        new Frogger.Project(),
        new Memory_game.Project(),
        new Taki_Game.Project(),
        new TickTackTow_WPF.Project(),
        new PrioratyDefiner.Project(),
        new Speed_Racer.Project(),
        new Store_Database.Project(),
    };
    public MainWindow()
    {
        InitializeComponent();
        InitializProjectbuttons();
        Contact_Me control = new Contact_Me();
        control.Height = 80;
        Contact_stack.Children.Add(control);
    }
    private void InitializProjectbuttons()
    {
        foreach (var project in Projects)
        {
            int i = 0;
            System.Windows.Media.Color color = new System.Windows.Media.Color() { A = 255, R = 149, G = 242, B = 217 };
            SolidColorBrush Buttoncolor = new SolidColorBrush(color);
            ProjectButton button = new ProjectButton(project, Buttoncolor)
            {
                Margin = new Thickness(10),
                Height = 150,
                Width = 150,
            };
            ProjectButtons.Children.Add(button);
        }
    }
}
