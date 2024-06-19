using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TickTackTow_WPF.Classes
{
    internal static class Smart_Move
    {
        public static int MakeSmarMove(int[,] positions, int player, bool randomposition = false)
        {
            Random random = new Random();
            if (randomposition)
            {
                return random.Next(1, 10);
            }
            int enemy = player == 2 ? 1 : 2;
            int attack = Checkwinline(positions, player);
            int defence = Checkwinline(positions, enemy);
            if (positions[1,1] != player && positions[1, 1] != enemy)
            {
                return sapceConverstion(1, 1);
            }
            if (attack != 10)
            {
                return attack;
            }
            else if (defence != 10)
            {
                return defence;
            }
            if (attack == 10 && defence == 10)
            {
                return random.Next(1, 10);
            }
            return random.Next(1, 10);
        }
        static int Checkwinline(int[,] positions, int player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (positions[i, 0] == player && positions[i, 1] == player && positions[i, 2] == 0)
                {
                    return sapceConverstion(i, 2);
                }
                if (positions[i, 0] == player && positions[i, 2] == player && positions[i, 1] == 0)
                {
                    return sapceConverstion(i, 1);
                }
                if (positions[i, 1] == player && positions[i, 2] == player && positions[i, 0] == 0)
                {
                    return sapceConverstion(i, 0);
                }
                if (positions[0, i] == player && positions[1, i] == player && positions[2, i] == 0)
                {
                    return sapceConverstion(2, i);
                }
                if (positions[0, i] == player && positions[2, i] == player && positions[1, i] == 0)
                {
                    return sapceConverstion(1, i);
                }
                if (positions[1, i] == player && positions[2, i] == player && positions[0, i] == 0)
                {
                    return sapceConverstion(0, i);
                }
            }
            if (positions[0, 0] == player && positions[1, 1] == player && positions[2, 2] == 0)
            {
                return sapceConverstion(2, 2);
            }
            if (positions[0, 0] == player && positions[1, 1] == 0 && positions[2, 2] == player)
            {
                return sapceConverstion(1, 1);
            }
            if (positions[0, 0] == 0 && positions[1, 1] == player && positions[2, 2] == player)
            {
                return sapceConverstion(0, 0);
            }
            if (positions[0, 2] == player && positions[1, 1] == player && positions[2, 0] == 0)
            {
                return sapceConverstion(2, 0);
            }
            if (positions[0, 2] == player && positions[1, 1] == 0 && positions[2, 0] == player)
            {
                return sapceConverstion(1, 1);
            }
            if (positions[0, 2] == 0 && positions[1, 1] == player && positions[2, 0] == player)
            {
                return sapceConverstion(0, 2);
            }
            return 10;
        }
        static int sapceConverstion(int pos2, int pos1)
        {
            switch (pos1)
            {
                case 0:
                    switch (pos2)
                    {
                        case 0:
                            return 1;
                            break;
                        case 1:
                            return 4;
                            break;
                        case 2:
                            return 7;
                            break;
                    }
                    break;
                case 1:
                    switch (pos2)
                    {
                        case 0:
                            return 2;
                            break;
                        case 1:
                            return 5;
                            break;
                        case 2:
                            return 8;
                            break;
                    }
                    break;
                case 2:
                    switch (pos2)
                    {
                        case 0:
                            return 3;
                            break;
                        case 1:
                            return 6;
                            break;
                        case 2:
                            return 9;
                            break;
                    }
                    break;
                default:
                    return 0;
                    break;
            }
            return 0;
        }
    }
}