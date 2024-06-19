using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PriorityDefiner.Classes
{
    internal static class Priority_Classes
    {
        public static SortedDictionary<string, int> CountValues(string[,] matrix)
        {
            SortedDictionary<string, int> counts = new SortedDictionary<string, int>();
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    string value = matrix[i, j];
                    if (value != null)
                    {
                        if (counts.ContainsKey(value))
                        {
                            counts[value]++;
                        }
                        else
                        {
                            counts[value] = 1;
                        }
                    }
                }
            }
            return counts;
        }
    }
}