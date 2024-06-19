using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Common_Classes.Classes
{
    public class HighScore_Set
    {
        public int card_Number { get; set; }
        public List<HighScore_Player> player_list { get; set; }
        public HighScore_Set()
        {
            player_list = new List<HighScore_Player>();
        }
        public void AddPlayer(HighScore_Player player)
        {
            player_list.Add(player);
            SortPlayers();
        }
        private void SortPlayers()
        {
            player_list = player_list.OrderBy(player => player.time_complete).ToList();
        }
    }
}
