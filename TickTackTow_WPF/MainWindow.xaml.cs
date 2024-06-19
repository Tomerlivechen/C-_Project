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
using TickTackTow_WPF.Classes;
namespace TickTackTow_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Gameboard gameboard;
        public Player player1;
        public Player player2;
        public int gametype = 3;
        bool algorithem_off = false;
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            gameboard = new Gameboard();
            Updateboard(gameboard);
            player1 = new Player(1);
            player2 = new Player(2);
            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.Tick += Timer_Tick;
            Closed += Window_Closed;
        }
        public void Window_Closed(object sender, EventArgs e)
        {
            timer.Stop();
        }
        private async void Timer_Tick(object sender, EventArgs e)
        {
            int smartposition = makeSmartMove();
            WPF_adaptation.makemove(gameboard, smartposition);
            Updateboard(gameboard);
            if (CheckCompleation()) { return; };
            gameboard.switchplayer();
        }
        public int makeSmartMove()
        {
            bool validmove;
            int smartposition;
            do
            {
                smartposition = Smart_Move.MakeSmarMove(
                    gameboard.positions,
                    gameboard.player,
                    algorithem_off
                );
                validmove = gameboard.IsValidMove(smartposition, gameboard.player);
            } while (!validmove);
            return smartposition;
        }
        public string PositionValue(int positionValue)
        {
            if (positionValue == 1)
            {
                return "X";
            }
            if (positionValue == 2)
            {
                return "O";
            }
            else
            {
                return "";
            }
        }
        public bool PositionEmpty(int positionValue)
        {
            if (positionValue > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void updatePlayer(Gameboard gameboard)
        {
            if (gametype < 3)
            {
                if (gameboard.player == 1)
                {
                    player_Mark.Text = "X";
                }
                else
                {
                    player_Mark.Text = "O";
                }
            }
        }
        public void updatePlayerWinsandDraws(Gameboard gameboard)
        {
            player2_wins.Text = player2.wins.ToString();
            player1_wins.Text = player1.wins.ToString();
            if (player1.draws == player2.draws)
            {
                Draws.Text = player1.draws.ToString();
            }
        }
        public void Updateboard(Gameboard gameboard)
        {
            updatePlayer(gameboard);
            Square_1.Content = PositionValue(gameboard.positions[0, 0]);
            Square_2.Content = PositionValue(gameboard.positions[0, 1]);
            Square_3.Content = PositionValue(gameboard.positions[0, 2]);
            Square_4.Content = PositionValue(gameboard.positions[1, 0]);
            Square_5.Content = PositionValue(gameboard.positions[1, 1]);
            Square_6.Content = PositionValue(gameboard.positions[1, 2]);
            Square_7.Content = PositionValue(gameboard.positions[2, 0]);
            Square_8.Content = PositionValue(gameboard.positions[2, 1]);
            Square_9.Content = PositionValue(gameboard.positions[2, 2]);
            Square_1.IsEnabled = PositionEmpty(gameboard.positions[0, 0]);
            Square_2.IsEnabled = PositionEmpty(gameboard.positions[0, 1]);
            Square_3.IsEnabled = PositionEmpty(gameboard.positions[0, 2]);
            Square_4.IsEnabled = PositionEmpty(gameboard.positions[1, 0]);
            Square_5.IsEnabled = PositionEmpty(gameboard.positions[1, 1]);
            Square_6.IsEnabled = PositionEmpty(gameboard.positions[1, 2]);
            Square_7.IsEnabled = PositionEmpty(gameboard.positions[2, 0]);
            Square_8.IsEnabled = PositionEmpty(gameboard.positions[2, 1]);
            Square_9.IsEnabled = PositionEmpty(gameboard.positions[2, 2]);
        }
        public bool CheckCompleation()
        {
            if (gameboard.CheckWin())
            {
                MessageBox.Show($"Congradulations player {gameboard.player} you have won \nPress OK to play again");
                if (player1._id == gameboard.player)
                {
                    player1.wins++;
                }
                if (player2._id == gameboard.player)
                {
                    player2.wins++;
                }
                gameboard.ResetBoard();
                Updateboard(gameboard);
                updatePlayerWinsandDraws(gameboard);
                return true;
            }
            if (gameboard.IsBoardFull())
            {
                MessageBox.Show($"Game is at a draw\nPress OK to play again");
                player1.draws++;
                player2.draws++;
                gameboard.ResetBoard();
                updatePlayerWinsandDraws(gameboard);
                Updateboard(gameboard);
                return true;
            }
            return false;
        }
        public void Square_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            int position = int.Parse(clickedButton.Tag.ToString());
            if (gametype == 2)
            {
                WPF_adaptation.makemove(gameboard, position);
                Updateboard(gameboard);
                if (CheckCompleation()) { return; };
                gameboard.switchplayer();
                updatePlayer(gameboard);
                Updateboard(gameboard);
            }
            if (gametype == 1)
            {
                if (gameboard.player == 1)
                {
                    WPF_adaptation.makemove(gameboard, position);
                    Updateboard(gameboard);
                    if(CheckCompleation()) { return; };
                    gameboard.switchplayer();
                    int smartposition = makeSmartMove();
                    WPF_adaptation.makemove(gameboard, smartposition);
                    Updateboard(gameboard);
                    if (CheckCompleation()) { return; };
                    gameboard.switchplayer();
                    updatePlayer(gameboard);
                }
            }
        }
        private void Start_Game_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            int type = int.Parse(clickedButton.Tag.ToString());
            gametype = type;
            One_Player.Visibility = Visibility.Hidden;
            Two_Player.Visibility = Visibility.Hidden;
            No_Player.Visibility = Visibility.Hidden;
            Game_type_lable.Text = TypeOfGame();
            Reset_board.Visibility = Visibility.Visible;
            Restart.Visibility = Visibility.Visible;
            if (type == 1 || type == 0)
            {
                difficulty_lable.Visibility = Visibility.Visible;
                difficulty.Visibility = Visibility.Visible;
                difficulty_Click(sender, e);
            }
            gameboard.ResetBoard();
            Updateboard(gameboard);
            if (type == 0)
            {
                if (!timer.IsEnabled)
                {
                    timer.Start();
                }
            }
        }
        public string TypeOfGame()
        {
            switch (gametype)
            {
                case 0:
                    return "CvC";
                    break;
                case 1:
                    return "PvC";
                    break;
                case 2:
                    return "PvP";
                    break;
                default:
                    return "";
                    break;
            }
        }
        private void Reset_board_Click(object sender, RoutedEventArgs e)
        {
            gameboard.ResetBoard();
            Updateboard(gameboard);
        }
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            gametype = 3;
            One_Player.Visibility = Visibility.Visible;
            Two_Player.Visibility = Visibility.Visible;
            No_Player.Visibility = Visibility.Visible;
            Game_type_lable.Text = "Choose type of game";
            Reset_board.Visibility = Visibility.Hidden;
            Restart.Visibility = Visibility.Hidden;
            difficulty.Visibility = Visibility.Hidden;
            difficulty_lable.Visibility = Visibility.Hidden;
            timer.Stop();
        }
        private void Reset_Score_Click(object sender, RoutedEventArgs e)
        {
            player1.wins = 0;
            player2.wins = 0;
            player1.draws = 0;
            player2.draws = 0;
            updatePlayerWinsandDraws(gameboard);
        }
        private void difficulty_Click(object sender, RoutedEventArgs e)
        {
            if (!algorithem_off)
            {
                algorithem_off = true;
                difficulty.Content = "Easy";
            }
            else
            {
                algorithem_off = false;
                difficulty.Content = "Hard";
            }
        }
    }
}