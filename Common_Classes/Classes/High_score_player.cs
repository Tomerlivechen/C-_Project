using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Common_Classes.Classes
{
    public class High_score_player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public High_score_player(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}
