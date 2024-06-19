namespace Speed_Racer.Resources.Classes
{
    public class Race_Game
    {
        public delegate void WinEventHandeler(object sender, EventArgs e);
        public event WinEventHandeler WinEvent;
        protected virtual void OnWinEvent(EventArgs e)
        {
            WinEventHandeler handler = WinEvent;
            if (handler != null)
            {
                handler?.Invoke(this, e);
            }
        }
        public delegate void GameOverEventHandeler(object sender, EventArgs e);
        public event GameOverEventHandeler LoseEvent;
        protected virtual void OnLoseEvent(EventArgs e)
        {
            GameOverEventHandeler handler = LoseEvent;
            if (handler != null)
            {
                handler?.Invoke(this, e);
            }
        }
        public string Name { get; set; }
        public int time { get; set; }
        public int difficulty { get; set; }
        public int score { get; set; }
        public int repair { get; set; }
        public double Fule { get; set; }
        public double distance { get; set; }
        public double fullDistance { get; set; }
        public void addToScore(int points)
        {
            score += points* (difficulty + 1)/2;
        }
        public void moveForward(double dis)
        {
            distance -= dis;
            if (distance < 0)
            {
                distance = 0;
                OnWinEvent(EventArgs.Empty);
            }
        }
        public void AddFule()
        {
            Fule += 25;
            if (Fule > 100)
            {
                Fule = 100;
            }
        }
        public void UseFule(double speed)
        {
            Fule -= (5 - speed) / 2;
            if (Fule < 0 && repair > 0)
            {
                Car_death();
                Fule = 100;
            }
            if (Fule < 0 && repair <= 0)
            {
                Car_death();
            }
        }
        public void AddRepair()
        {
            repair++;
        }
        public void initilize(int difficulty)
        {
            repair = 5 - difficulty;
            score = 0;
            time = 0;
            Fule = 100;
            distance = 250 + 250 * difficulty;
            fullDistance= distance;
        }
        public int GetScore()
        {
            score += 500;
            score += repair * (difficulty + 1) * 500;
            score -= time;
            return score;
        }
        public void Car_death()
        {
            repair--;
            if (repair < 0)
            {
                OnLoseEvent(EventArgs.Empty);
            }
        }
        public void timePass()
        {
            time++;
        }
        public Race_Game(string _name, int _difficulty)
        {
            Name = _name;
            difficulty = _difficulty;
            initilize(difficulty);
        }
    }
}
