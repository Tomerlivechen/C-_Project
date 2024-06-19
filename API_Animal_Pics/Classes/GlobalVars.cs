using Common_Classes.Common_Elements;
using Common_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Common_Classes.Classes;
using System.Windows.Media.Imaging;
using System.Reflection;
namespace API_Animal_Pics.Classes
{
    public static class GlobalVars
    {
        const string filePath = (@"Resources\API_Animal_Pics_Piclists.json");
        public static Animallists animalPiclists = new Animallists();
        public static int changes = 0;
        public static void LoadPicLists()
        {
            if (!File.Exists(filePath))
            {
                Animallists NewAnimallists = new Animallists();
                animalPiclists = NewAnimallists;
                return;
            }
            try
            {
                var rawData = File.ReadAllText(filePath);
                var result = JsonSerializer.Deserialize<Animallists>(rawData);
                animalPiclists = result;
                if (result == null)
                {
                    Animallists NewAnimallists = new Animallists();
                    animalPiclists = NewAnimallists;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No pic lists available");
            }
        }
        public static void SavePiclists()
        {
            var export = JsonSerializer.Serialize(animalPiclists);
            try
            {
                string directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.Write(export);
                }
                changes = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving: {ex.Message}");
            }
            LoadPicLists();
        }
        public static void AddPicList()
        {
            {
                GlobalVars.changes++;
                bool checkName = false;
                Animallist animallist = new Animallist();
                do
                {
                    var number_of_field = 1;
                    var title = "Insert Name Of Picture list";
                    var Input_field = new Common_Classes.Classes.Input_box_field();
                    Input_field.Input_label = "Enter name:";
                    Input_box input_Box;
                    UniversalVars.inputBoxReturn = null;
                    do
                    {
                        input_Box = new Input_box(number_of_field, title, Input_field);
                        input_Box.ShowDialog();
                        if (UniversalVars.inputBoxReturn == null)
                        {
                            MessageBox.Show("You must Name the list", "List Cannot Be Nameless");
                        }
                    }
                    while (UniversalVars.inputBoxReturn == null);
                    animallist.Name = UniversalVars.inputBoxReturn[0].ToString();


                    checkName = false;
                    foreach (Animallist pic_list in animalPiclists.animalPiclists)
                    {
                        if (pic_list.Name == animallist.Name)
                        {
                            checkName = true;
                            MessageBox.Show("List Name alredy in use", "Name in use");
                        }
                    }
                } while (checkName);
                animalPiclists.animalPiclists.Add(animallist);
            }
        }
        public static void AddPic(string animallist, AnimalPic pic)
        {
            GlobalVars.changes++;
            Animallist selectedanimallist = animalPiclists.animalPiclists.Find(list => list.Name == animallist);
            if (selectedanimallist != null)
            {
                selectedanimallist.animalPics.Add(pic);
            }
        }
        public static void RemovePic(string animallist, AnimalPic pic)
        {
            GlobalVars.changes++;
            Animallist selectedanimallist = animalPiclists.animalPiclists.Find(list => list.Name == animallist);
            if (selectedanimallist != null)
            {
                selectedanimallist.animalPics.Remove(pic);
            }
        }
        public static void CheckDuplicate()
        {
            foreach (Animallist list in animalPiclists.animalPiclists)
            {
                List<AnimalPic> imagesToRemove = new List<AnimalPic>();
                foreach (AnimalPic test_image in list.animalPics)
                {
                    int index = 0;
                    foreach (AnimalPic image in list.animalPics)
                    {
                        if (image.id == test_image.id)
                        {
                            index++;
                        }
                        if (index >= 2)
                        {
                            imagesToRemove.Add(image);
                            index--;
                        }
                    }
                }
                foreach (AnimalPic image in imagesToRemove)
                {
                    list.animalPics.Remove(image);
                }
            }
        }
        public static BitmapImage SetImageForSource(string resourceName)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var uri = new Uri(
                $"pack://application:,,,/{assemblyName};component/Resources/Images/{resourceName}"
            );
            return new BitmapImage(uri);
        }
    }
}
