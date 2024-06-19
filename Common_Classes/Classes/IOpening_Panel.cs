using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
namespace Common_Classes.Classes
{
    public interface IOpening_Panel
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public BitmapImage buttonImage { get; set; }
        public void Run();
    }
}
