using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace API_Animal_Pics.Classes
{
    public class Animallist
    {
        public string? Name { get; set; }
        public List<AnimalPic> animalPics { get; set; } = new List<AnimalPic>();
    }
}
