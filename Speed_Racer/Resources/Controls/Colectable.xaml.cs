using Speed_Racer.Resources.Classes;
using System.Windows.Controls;
using System.Windows.Threading;
namespace Speed_Racer.Resources.Controls
{
    /// <summary>
    /// Interaction logic for Fule_Tank.xaml
    /// </summary>
    public partial class Colectable : UserControl
    {
        DispatcherTimer timer1 = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(10) };
        public int direction = -1;
        public Colectable(string goody)
        {
            
            InitializeComponent();
            timer1.Start();
            timer1.Tick += moveTank;
            goody_image.Source = Image_Import.LoadImageFromResource(goody);
        }
        public void moveTank(object sender, EventArgs e)
        {
            double topPos = Canvas.GetTop(goody_image);
            if (topPos >= 16)
            {
                direction = -1;
            }
            if (topPos <= 0)
            {
                direction = 1;
            }
            Canvas.SetTop(goody_image, topPos + 0.3 * direction);
        }
    }
}