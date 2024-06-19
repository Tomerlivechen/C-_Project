using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace TickTackTow_WPF.Classes
{
    public class Gameboard
    {
        public int[,] positions = new int[3, 3]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };
        public int player = 1;
        public int tempPlayer;
        Random rand = new Random();
        public void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    positions[i, j] = 0;
                }
            }
            player = 1;
        }
        public bool IsValidMove(int space, int player)
        {
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    counter++;
                    if (counter == space && positions[i, j] == 0)
                    {
                        positions[i, j] = player;
                        return true;
                    }
                    if (counter == space && positions[i, j] > 0)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        public bool CheckWin(string playername = "")
        {
            for (int i = 0; i < 3; i++)
            {
                if (positions[i, 0] == positions[i, 1] && positions[i, 1] == positions[i, 2] && positions[i, 2] > 0)
                {
                   
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (positions[0, i] == positions[1, i] && positions[1, i] == positions[2, i] && positions[2, i] > 0)
                {
                    
                    return true;
                }
            }
            if (positions[0, 0] == positions[1, 1] && positions[1, 1] == positions[2, 2] && positions[2, 2] > 0)
            {
                
                return true;
            }
            if (positions[0, 2] == positions[1, 1] && positions[1, 1] == positions[2, 0] && positions[2, 0] > 0)
            {
                
                return true;
            }
            return false;
        }
        public bool IsBoardFull()
        {
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (positions[i, j] > 0)
                    {
                        counter++;
                    };
                }
            }
            if (counter == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void switchplayer()
        {
            if (player == 1)
            {
                player = 2;
            }
            else
            {
                player = 1;
            }
        }
    }
}