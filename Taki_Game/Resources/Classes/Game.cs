using Common_Classes.Common_Elements;
using Common_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Common_Classes.Classes;
namespace Taki_Game.Resources.Classes
{
    public static class Game
    {
        public static void checkWin(int players)
        {
            if (!GlobalVars.Win && players_list.Count > 0)
            {
                try
                {
                    foreach (Player_class player in players_list)
                    {
                        if (player.DeckInHand.Count == 0)
                        {
                            playerWin(player);
                            GlobalVars.Win = true;
                        }
                    }
                }
                catch (Exception e) { return; }
            }
        }
            
        
        public static void playerWin(Player_class player)
        {
            GlobalVars.InitilizeAllParameters();
            MessageBox.Show($"{player.name} Wins", "Winner");
            MessageBox.Show("Play again Soon","Game Over");
            players_list.Clear();
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Name == "Color_Window" || window.Name == "GameWindow")
                {
                    window.Close();
                }
            }
        }
        public static List<Player_class> players_list = new List<Player_class>();
        public static void SetPlayerName(Player_class player, bool initilize) {

            if (initilize) {
                var number_of_field = 1;
                var title = $"Insert name of player {player.index}";
                var Input_field = new Input_box_field();
                Input_field.Input_label = "Enter name:";
                Input_box input_Box;
                UniversalVars.inputBoxReturn = null;
                do
                {
                    input_Box = new Input_box(number_of_field, title, Input_field);
                    input_Box.ShowDialog();
                    if (UniversalVars.inputBoxReturn == null)
                    {
                        MessageBox.Show($"What is the name of player {player.index}?", "Name your player");
                    }
                    if (UniversalVars.inputBoxReturn != null && players_list.Count>0)
                    {
                        foreach (Player_class setplayer in players_list)
                        {
                            if(setplayer.name == UniversalVars.inputBoxReturn[0].ToString())
                            {
                                MessageBox.Show("Name alredy in use?", "Name alredy in use");
                                UniversalVars.inputBoxReturn = null;
                                break;
                            }

                        }
                    }
                }
                while (UniversalVars.inputBoxReturn == null);
                player.name = UniversalVars.inputBoxReturn[0].ToString();
                UniversalVars.inputBoxReturn = null;
            }
        }

        public static void StartGame(int players, bool initilaize = true)
        {
            players_list.Clear();
            GlobalVars.Win = false;
            GlobalVars.player = 1;
            GlobalVars.setDeck();
            if (players > 0)
            {
                for (int i = 0; i < players; i++)
                {
                    players_list.Add(new Player_class() { index = i + 1, DeckInHand = new List<TakiCard>() });
                }
                foreach (Player_class player in players_list)
                {
                    SetPlayerName(player, initilaize);
                    GetCards(player);
                }
            }
            GlobalVars.nextCardOutStack(GlobalVars.activeDeck[0]);
            GlobalVars.activeDeck.Remove(GlobalVars.activeDeck[0]);
            GlobalVars.closeTaki();
            GlobalVars.Plus2Active = false;
            GlobalVars.Plus2Accumulation = 0;
        }
        public static void GetCards(Player_class player)
        {
            for (int i = 0; i < 8; i++)
            {
                DrawCard(player);
            }
        }
        public static void DrawCard(Player_class player, bool inTurn = false)
        {
            if (GlobalVars.activeDeck.Count <= 1)
            {
                reShuffleStack();
            }
            GlobalVars.activeDeck[0].GiveCard(player.index);
            player.DeckInHand.Add(GlobalVars.activeDeck[0]);
            GlobalVars.activeDeck.Remove(GlobalVars.activeDeck[0]);
            if (inTurn)
            {
                GlobalVars.nextPlayer();
            }
        }
        public static void PeneltyDraw(Player_class player)
        {
            MessageBox.Show($" {player.name} takes {GlobalVars.Plus2Accumulation} Cards", "+2 Penelty");
            if (GlobalVars.activeDeck.Count > GlobalVars.Plus2Accumulation)
            {
                for (int i = 0; i < GlobalVars.Plus2Accumulation; i++)
                {
                    DrawCard(player);
                }
            }
            else
            {
                reShuffleStack();
                for (int i = 0; i < GlobalVars.Plus2Accumulation; i++)
                {
                    DrawCard(player);
                }
            }
            GlobalVars.Plus2Accumulation = 0;
            GlobalVars.nextPlayer();
        }
        public static void reShuffleStack()
        {
            GlobalVars.setDeck();
            foreach (Player_class player in players_list)
            {
              foreach (TakiCard takiCard in player.DeckInHand)
            {
                RemoveCardFromDeck(takiCard);
            } 
            }
            RemoveCardFromDeck(GlobalVars.lastCardInStack);
        }
        public static void RemoveCardFromDeck(TakiCard takiCard)
        {
            TakiCard cardToRemove = GlobalVars.activeDeck.Find(card => card.Pic == takiCard.Pic);
            if (cardToRemove != null)
            {
                GlobalVars.activeDeck.Remove(cardToRemove);
            }
        }
    }
}
