using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Common_Classes.Classes
{
    public class HighScore_Total
    {
        public HighScore_Set High_Score_12 { get; set; }
        public HighScore_Set High_Score_18 { get; set; }
        public HighScore_Set High_Score_24 { get; set; }
        public HighScore_Set High_Score_30 { get; set; }
        public HighScore_Set High_Score_36 { get; set; }
        public HighScore_Set High_Score_48 { get; set; }
        public HighScore_Total()
        {
            High_Score_12 = new HighScore_Set { card_Number = 12 };
            High_Score_18 = new HighScore_Set { card_Number = 18 };
            High_Score_24 = new HighScore_Set { card_Number = 24 };
            High_Score_30 = new HighScore_Set { card_Number = 30 };
            High_Score_36 = new HighScore_Set { card_Number = 36 };
            High_Score_48 = new HighScore_Set { card_Number = 48 };
        }
    }
}
