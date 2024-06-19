using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Common_Classes
{
    public static class Foolproofing
    {
        public static bool ValueVarification(int min, int max, string value, string message="")
        {
            bool isnumeric = int.TryParse(value, out int verifiedNume);
            if (
                verifiedNume >= min
                && verifiedNume <= max
                && !String.IsNullOrEmpty(value)
                && isnumeric
            )
            {
                return true;
            }
            else
            {
                if (message != "") { MessageBox.Show(message); }
                return false;
            }
        }
    }
}