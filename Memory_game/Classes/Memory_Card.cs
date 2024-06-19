using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
namespace Memory_game.Classes
{
    public class Memory_Card : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Memory_Card() => VisibleImage = Back;
        BitmapImage _visibleImage;
        public BitmapImage VisibleImage
        {
            get { return _visibleImage; }
            set
            {
                _visibleImage = value;
                OnPropertyChanged(nameof(VisibleImage));
            }
        }
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int Posotion { get; set; }
        public string Pic { get; set; }
        public void setPic(string value) => Pic = value;
        public BitmapImage Image => Initialization_Of_Game.LoadImageFromResource($"CardImage{Pic}.png");
        public static BitmapImage Back => Initialization_Of_Game.LoadImageFromResource("CardImageBack.png");
        public bool Face { get; set; } = false;
        public bool Viable { get; set; } = true;
        public void InternalDeflip()
        {
            if (!Viable)
            {
                Face = true;
                return;
            }
            if (Viable)
            {
                Face = !Face;
                if (Face)
                {
                    VisibleImage = Image;
                }
                else
                {
                    VisibleImage = Back;
                }
            }
        }
        public void Flip(object sender, RoutedEventArgs e)
        {
            Initialization_Of_Game.Checkstatus(this);
            InternalDeflip();
        }
    }
}
