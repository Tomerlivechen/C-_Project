using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TickTackTow_WPF.Classes
{
    public class WPF_adaptation
    {
        public static void makemove(Gameboard gameboard, int position)
        {
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    counter++;
                    if (counter == position && gameboard.positions[i, j] == 0)
                    {
                        gameboard.positions[i, j] = gameboard.player;
                        return;
                    }
                }
            }
        }
    }
}