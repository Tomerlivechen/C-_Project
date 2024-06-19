using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Common_Classes.Classes
{
    public static class UniversalVars
    {
        public static List<string>? inputBoxReturn { get; set; } = new List<string>();
        public static void SetInputBoxReturn(List<string> inputReturn) { inputBoxReturn = inputReturn; }
    }
}
