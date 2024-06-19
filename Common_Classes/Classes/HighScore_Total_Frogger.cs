using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Common_Classes.Classes
{
    public class HighScore_Total_Frogger
    {
        public HighScore_Set_Frogger Difficalty_1 { get; set; }
        public HighScore_Set_Frogger Difficalty_2 { get; set; }
        public HighScore_Set_Frogger Difficalty_3 { get; set; }
        public HighScore_Set_Frogger Difficalty_4 { get; set; }
        public HighScore_Set_Frogger Difficalty_5 { get; set; }
        public HighScore_Set_Frogger Difficalty_6 { get; set; }
        public HighScore_Set_Frogger Difficalty_7 { get; set; }
        public HighScore_Total_Frogger()
        {
            Difficalty_1 = new HighScore_Set_Frogger { Difficalty = "Piece of Cake" };
            Difficalty_2 = new HighScore_Set_Frogger { Difficalty = "Very Easy" };
            Difficalty_3 = new HighScore_Set_Frogger { Difficalty = "Easy" };
            Difficalty_4 = new HighScore_Set_Frogger { Difficalty = "Moderate" };
            Difficalty_5 = new HighScore_Set_Frogger { Difficalty = "Hard" };
            Difficalty_6 = new HighScore_Set_Frogger { Difficalty = "Very Hard" };
            Difficalty_7 = new HighScore_Set_Frogger { Difficalty = "Near Impossible" };
        }
    }
}
