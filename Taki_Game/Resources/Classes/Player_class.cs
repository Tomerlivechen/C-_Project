using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Taki_Game.Resources.Classes
{
        public class Player_class
        {
            public int index { get; set; }
            public string name { get; set; }
            public List<TakiCard> DeckInHand = new List<TakiCard>();
            public int Wins { get; set; } = 0;
        }
    
}
