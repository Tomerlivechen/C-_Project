using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace API_hub.Classes
{
    public static class Extensions
    {
        public static string FirstLetterToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
        public static string RemoveUnderlines(this string input)
        {
            return input.Replace('_', ' ');
        }
        public static string Makelable(this string input)
        {
            return input.RemoveUnderlines().FirstLetterToUpper();
        }
    }
}
