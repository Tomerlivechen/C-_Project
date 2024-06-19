using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace API_Animal_Pics.Classes
{
    public class AnimalPic
    {
        public string? id { get; set; } = null;
        public string? url { get; set; } = null;
        public int width { get; set; }
        public int height { get; set; }
        public string? image { get; set; } = null;
        public string? link { get; set; } = null;
    }
}
