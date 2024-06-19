using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Frogger.Classes
{
    public class scoreKeeping
    {
        public int Difficalty;
        public int Lives = 5;
        public int Wins = 0;
        public void initialze()
        {
            Lives = 5;
            Wins = 0;
        }
    }
}
