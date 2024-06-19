using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TickTackTow_WPF.Classes
{
    public class Player
    {
        public int _id;
        public int wins = 0;
        public int draws = 0;
        public Player(int id)
        {
            _id = id;
        }
        public void Playerwins()
        {
            wins++;
        }
        public void PlayerdRAWS()
        {
            draws++;
        }
    }
}