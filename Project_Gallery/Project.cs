using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Common_Classes;
using Project_Gallery.Controles;
using Common_Classes.Classes;
namespace Project_Gallery;

public class Project : IProjectMeta
{
    public string Name { get; set; } = "Default";

    public BitmapImage Image
    {
        get
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Uri uri = new Uri($"pack://application:,,,/{assemblyName};component/Resources/IndexImage.png");
            return new BitmapImage(uri);

        }
    }

    //public BitmapImage Image =>
    //    new BitmapImage(
    //        new Uri(
    //            $"{AppDomain.CurrentDomain.BaseDirectory}/Resources/IndexImage2.png",
    //            UriKind.Absolute
    //        )
    //    );



    // Define delegates with the desired method signatures
    Func<object, object> act1 = (obj) => { MessageBox.Show("this is action1"); return null; };
    Func<object, object> act2 = (obj) => { MessageBox.Show("this is action2"); return null; };
    Func<object, object> act3 = (obj) => { MessageBox.Show("this is action3"); return null; };

    // Assign the delegates to buttonCommands



    public void Run()
    {
        string[] buttontext = new string[] { "yes", "no", "maybe" };

        bool[] buttonRespons = new bool[] { true, false, false };
        Delegate[] buttonCommands = new Delegate[] { act1, act2, act3 };
        string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        BitmapImage Image = new BitmapImage(
            new Uri(($"pack://application:,,,/{assemblyName};component/Resources/IndexImage.png")));
        //        MainWindow window = new MainWindow();
        //        window.ShowDialog();

        MYMessageBoxobject messageBox = new MYMessageBoxobject();

        messageBox.message = "testsing message";
        messageBox.caption = "Testing caption";
        messageBox.buttontext = buttontext;
        messageBox.buttonRespons = buttonRespons;
 //       messageBox.buttonCommands = buttonCommands;
        messageBox.image = Image;

        CustomeMessagebox window = new CustomeMessagebox(messageBox);

        window.ShowDialog();




    }
}
