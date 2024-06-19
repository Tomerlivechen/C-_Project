using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Taki_Game.Resources.Controls;
using static System.Net.Mime.MediaTypeNames;
using Taki_Game.Resources.Classes;
using System;
namespace Taki_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer1 = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        public int setPlayer;
        bool buttonClickChange = false;
        bool buttonClickChangeCheck = false;
        public MainWindow(int players)
        {
            InitializeComponent();
            InitializeImages();
            GlobalVars.InitilizeAllParameters();
            GlobalVars.setNumOfPlayers(players);
            Game.StartGame(players);
            timer1.Start();
            timer1.Tick += visualUpdates;
            Closed += Close_Window;
        }

        private void Close_Window(object? sender, EventArgs e)
        {
            GlobalVars.InitilizeAllParameters();
            Game.players_list.Clear();
            GlobalVars.Win=true;

        }



        public void InitializeImages()
        {
            Table.Source = GlobalVars.LoadImageFromResource("Table_Top.png");
            Deck_image.Source = GlobalVars.LoadImageFromResource("CardImageBack.png");
        }
        
        private void visualUpdates(object? sender, EventArgs e)
        {
            Game.checkWin(GlobalVars.NumOfPlayers);
            ClosingTaki();
            updatePlayer();
            updateStackSet();
            updatePlus2();
            if (Panel.GetZIndex(Table) != 0){
                Panel.SetZIndex(Table, 0); }
            if (GlobalVars.Win)
            {
                timer1.Stop();
            }
        }
        public void updatePlayer()
        {
            if (Game.players_list.Count > 0)
            {
                player_num.Content = $"Player {GlobalVars.player.ToString()}: ";
                setPlayer = GlobalVars.player;
                UpdateCardSet(Game.players_list[GlobalVars.player - 1]);
                player_num.Content += Game.players_list[GlobalVars.player - 1].name;
                player_num.Content += $" {Game.players_list[GlobalVars.player - 1].DeckInHand.Count()} Cards";
                
            }
        }
        public void updatePlus2() { 
        if (GlobalVars.Plus2Active)
            {
                penalty.Visibility = Visibility.Visible;
                penalty.Content = $"+2 Penalty {GlobalVars.Plus2Accumulation.ToString()}";
            }
            else
            {
                penalty.Visibility = Visibility.Collapsed;
            }
        }
        public void updateStackSet()
        {
            card_stack.Children.Clear();
            Taki_Card T_card = new Taki_Card(GlobalVars.lastCardInStack)
            {
                Margin = new Thickness(3),
                Height = 250,
                Width = 180,
            };
            card_stack.Children.Add(T_card);
        }
        public void ClosingTaki()
        {
                        if (GlobalVars.TakiActive == true)
            {
                Close_Taki.Visibility = Visibility.Visible;
                End_turn.Visibility = Visibility.Visible;
            }
            if(GlobalVars.TakiActive == false)
            {
                Close_Taki.Visibility = Visibility.Collapsed;
                End_turn.Visibility = Visibility.Collapsed;
            }
        }
        public void UpdateCardSet(Player_class player)
        {
                player_wrap.Children.Clear();
                foreach (TakiCard card in player.DeckInHand)
                {
                    Taki_Card T_card = new Taki_Card(card)
                    {
                        Margin = new Thickness(3),
                        Height = 125,
                        Width = 90,
                    };
                    player_wrap.Children.Add(T_card);
                }
        }
        private void Deck_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalVars.TakiActive)
            {
                MessageBox.Show("Impossible move", "Impossible move");
                return;
            }
            if (GlobalVars.Plus2Active == true)
            {
                GlobalVars.Plus2Active = false;
                Game.PeneltyDraw(Game.players_list[GlobalVars.player - 1]);
                return;
            }
            Game.DrawCard(Game.players_list[GlobalVars.player - 1], true);
        }
        private void Close_Taki_Click(object sender, RoutedEventArgs e)
        {
            GlobalVars.closeTaki();
            GlobalVars.nextPlayer();
        }
        private void Close_End_turn(object sender, RoutedEventArgs e)
        {
            GlobalVars.nextPlayer();
        }

        private void Sort_Color(object sender, RoutedEventArgs e)
        {
            Game.players_list[GlobalVars.player - 1].DeckInHand = Game.players_list[GlobalVars.player - 1].DeckInHand.OrderBy(p => p.color).ToList();
            

        }

        private void Sort_Both(object sender, RoutedEventArgs e)
        {
            Game.players_list[GlobalVars.player - 1].DeckInHand = Game.players_list[GlobalVars.player - 1].DeckInHand.OrderBy(p => p.color).ThenBy(p => p.val).ToList();
        }

        private void Sort_value(object sender, RoutedEventArgs e)
        {
            Game.players_list[GlobalVars.player - 1].DeckInHand = Game.players_list[GlobalVars.player - 1].DeckInHand.OrderBy(p => p.val).ToList();
        }
    }
}