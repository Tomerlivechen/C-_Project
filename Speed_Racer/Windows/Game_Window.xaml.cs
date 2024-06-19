using Common_Classes.Classes;
using Speed_Racer.Resources.Classes;
using Speed_Racer.Resources.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using static System.Formats.Asn1.AsnWriter;
namespace Speed_Racer.Windows
{
    /// <summary>
    /// Interaction logic for Game_Window.xaml
    /// </summary>
    public partial class Game_Window : Window
    {
        public double speed_Holder = 0.1;
        public double Speed = 0.11;
        public int difficalty = 0;
        public bool sidecrash = false;
        public bool start = false;
        public int countDown = 0;
        public string name = "TEST";
        DispatcherTimer timer1 = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(10) };
        DispatcherTimer timer1s = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        DispatcherTimer timer4s = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
        Colectable fule_Tank = new Colectable("Fule.png");
        Colectable Repairkit = new Colectable("RepairKit.png");
        Colectable Chocolate = new Colectable("Chocolate.png");
        List<Image> enimyCars;
        List<Colectable> colectables;
        Race_Game NewGame;
        Speedometer speedometer;
        DistanceView distanceView = new DistanceView();
        public Game_Window(int _difficalty, string _name)
        {
            difficalty = _difficalty;
            name = _name;
            if (difficalty == 3) {
                sidecrash = true;
            }
            NewGame = new Race_Game(name, difficalty);
            InitializeComponent();
            timer4s.Start();
            timer1.Tick += timedReaction;
            timer1s.Tick += secondTimedReaction;
            timer4s.Tick += FourSecondtimer;
            NewGame.WinEvent += win_fuction;
            NewGame.LoseEvent += Lose_fuction;
            insertColectables(fule_Tank, "Fule");
            insertColectables(Repairkit, "Fix");
            insertColectables(Chocolate, "Chocolate");
            colectables = new List<Colectable>() { fule_Tank, Repairkit, Chocolate };
            enimyCars = new List<Image>() { Car2, Car3, Car5, Car6, Car8 };
            FuleGauge fuleGauge = new FuleGauge(NewGame);
            FuleGaugebox.Children.Add(fuleGauge);
            Repair_item repair_Item = new Repair_item(NewGame);
            Toolbox.Children.Add(repair_Item);
            speedometer = new Speedometer();
            SpeedGaugebox.Children.Add(speedometer);
            Distance_layout.Child = distanceView;
            distanceView.Height = Distance_layout.Height;
            distanceView.Width = Distance_layout.Width;
            distanceView.HorizontalAlignment = HorizontalAlignment.Stretch;
            distanceView.VerticalAlignment = VerticalAlignment.Stretch;
            Closed += Window_Closed;
        }
        public void insertColectables(Colectable colectable, string tag)
        {
            Track_Canvas.Children.Add(colectable);
            Canvas.SetZIndex(colectable, 4);
            Canvas.SetTop(colectable, 800);
            Canvas.SetLeft(colectable, 0);
            colectable.Tag = tag;
        }
        public void Window_Closed(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1s.Stop();
            timer4s.Stop();

        }
            public void FourSecondtimer(object sender, EventArgs e)
        {
            if (countDown == 0)
            {
                setCarsFordifficalty(difficalty);
                Light.Source = Image_Import.LoadImageFromResource("Radio1.png");
                Light.Visibility = Visibility.Visible;
                countDown++;
                return;
            }
            if (countDown == 1)
            {
                Light.Source = Image_Import.LoadImageFromResource("Radio2.png");
                countDown++;
                return;
            }
            if (countDown == 2)
            {
                Light.Source = Image_Import.LoadImageFromResource("Radio3.png");
                countDown = 0;
                timer1.Start();
                timer1s.Start();
                start = true;
                if (pause_screen.Visibility == Visibility.Visible)
                {
                    pause_screen.Visibility = Visibility.Collapsed;
                }
                return;
            }
        }
        public void setCarsFordifficalty(int difficalty)
        {
            List<UIElement> enimyCars = new List<UIElement>() { Car2, Car3, Car5, Car6, Car8 };
            switch (difficalty)
            {
                case 0:
                    Car5.Visibility = Visibility.Collapsed;
                    Car6.Visibility = Visibility.Collapsed;
                    Car8.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    Car6.Visibility = Visibility.Collapsed;
                    Car8.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    Car8.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }
        public void moveLines()
        {
            List<UIElement> lines = new List<UIElement>();
            lines.Add(Track_line1);
            lines.Add(Track_line2);
            lines.Add(Track_line3);
            foreach (UIElement item in lines)
            {
                double[] position = Getposition(item);
                if (position[1] >= 28 - (difficalty + 1) * Speed) { Canvas.SetTop(item, -20); }
                else
                {
                    Canvas.SetTop(item, position[1] + (difficalty + 1) * Speed);
                }
            }
        }
        private void Lose_fuction(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1s.Stop();
            MessageBox.Show("Out of repair kits You Lose","Game Over");
            start = false;
            GameOver(sender, e);
        }
        private void win_fuction(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1s.Stop();
            MessageBox.Show("You Win","Game Over");
            start = false;
            MessageBox.Show("You Have been added to the high score list", "High Score");
            int newScore = NewGame.GetScore();
            HighScores.AddHighScore(name, newScore);
            GameOver(sender, e);
        }
        private void timedReaction(object sender, EventArgs e)
        {
            Collisions.CheckEnemyCollision(enimyCars);
            Move_objects.MoveAllObjects(Track_Canvas, difficalty, Speed);
            Collisions.CheckCollision(enimyCars, player, this);
            Collisions.CheckGoodCollision(colectables, player, NewGame);
            speedometer.GenerateGage((int)(Speed * 0.8)+1);
            moveLines();
        }
        private void secondTimedReaction(object sender, EventArgs e)
        {
            Light.Visibility = Visibility.Collapsed;
            timer4s.Stop();
            NewGame.timePass();
            NewGame.moveForward(Speed);
            distanceView.moveCar(NewGame.distance, NewGame.fullDistance);
            Time_Count.Text = NewGame.time.ToString();
            Score_Value.Text = NewGame.score.ToString();
            
            NewGame.UseFule(Speed);
        }
        public double[] Getposition(UIElement element)
        {
            double currentX = Canvas.GetLeft(element);
            double currentY = Canvas.GetTop(element);
            double[] respons = new double[] { currentX, currentY };
            return respons;
        }
        private void Game_Window_KeyDown(object sender, KeyEventArgs e)
        {
            double[] position = Getposition(player);
            if (start)
            {
                if (e.Key == Key.W)
                {
                    Speed += 0.05;
                }
                else if (e.Key == Key.S)
                {
                    if (Speed > 0.1)
                    {
                        Speed -= 0.05;
                    }
                }
            }
            if (e.Key == Key.P)
            {
                if (start)
                {
                    forcedPause();
                    return;
                }
                if (!start)
                {
                    forcedUnpause();
                    return;
                }
            }
        }

        public void forcedPause()
        {
                timer1.Stop();
                timer1s.Stop();
                start = false;
                pause_screen.Visibility = Visibility.Visible;
        }

        public void forcedUnpause()
        {
            timer1.Start();
            timer1s.Start();
            start = true;
            pause_screen.Visibility = Visibility.Collapsed;
            return; ;
        }
        public void moveAllCars(double moveto)
        {
            Random rnd = new Random();
            List<UIElement> enimyCars = new List<UIElement>() { Car2, Car3, Car5, Car6, Car8 };
            foreach (UIElement item in enimyCars)
            {
                Canvas.SetTop(item, rnd.Next((int)moveto, (int)moveto + 200));
            }
        }
        public void explosion()
        {
            player.Source = Image_Import.LoadImageFromResource("Explosion.png");
        }
        public void Fix()
        {
            player.Source = Image_Import.LoadImageFromResource("MaxCar.png");
        }
        public void GameOver(object sender, EventArgs e)
        {
            int response = Message_Box_Classes.DisplayMessageBox("Game over, Do you Want to play again?", "GAME OVER");
            if (response == 2)
            {
                Close();
            }
            if (response == 1)
            {
                InitializeComponent();
                NewGame.initilize(difficalty);
                moveAllCars(700);
                timer4s.Start();
            }
        }
        public void Death()
        {
            explosion();
            timer1.Stop();
            timer1s.Stop();
            if (NewGame.repair < 0)
            {
                object sender = new object();
                EventArgs e = new EventArgs();
                GameOver(sender, e);
            }
            MessageBox.Show("Repair kit used");
            timer1.Start();
            timer1s.Start();
            Fix();
            Canvas.SetLeft(player, 100);
            if (sidecrash)
            {
                forcedPause();
            }
            Speed = speed_Holder;
            NewGame.Car_death();
            moveAllCars(700);
        }
        private void Mouse_move(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(Track_Canvas);
            if (sidecrash && position.X < 315 && position.X > 0 && start)
            {
                if (position.X < 290 && position.X > 15 && start)
                {
                    Canvas.SetLeft(player, position.X);
                }
                if (position.X > 290 || position.X < 15)
                {
                    Death();
                }
            }
            if (position.X < 290 && position.X > 15 && start)
            {
                Canvas.SetLeft(player, position.X);
            }
        }
    }
}
