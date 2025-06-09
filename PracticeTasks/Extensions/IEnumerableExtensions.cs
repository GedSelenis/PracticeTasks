using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTasks.Extensions
{
    public static class IEnumerableExtensionsOverride
    {
        
        public static int CustomMin(this IEnumerable<int> source)
        {
            if (source == null || !source.Any())
            {
                throw new ArgumentException("Source collection cannot be null or empty.", nameof(source));
            }
            int minValue = int.MaxValue;
            foreach (var item in source)
            {
                if (item < minValue)
                {
                    minValue = item;
                }
            }
            return minValue;
        }
        public static List<int> CustomMin(this IEnumerable<int> source, int n)
        {
            if (source == null || !source.Any())
            {
                throw new ArgumentException("Source collection cannot be null or empty.", nameof(source));
            }
            List<int> minValues = new List<int>();
            for (int i = 0; i < n; i++)
            {
                minValues.Add(int.MaxValue);
            }
            foreach (var item in source)
            {
                minValues = compareMin(item, minValues, 0);
            }

            return minValues;
        }
        public static List<int> CustomMin2(this IEnumerable<int> source, int n) // Read about materiliaztion
        {
            if (source == null || !source.Any())
            {
                throw new ArgumentException("Source collection cannot be null or empty.", nameof(source));
            }
            List<int> minValues = new List<int>();
            List<int> ExcludedIndexes = new List<int>();
            for ( int i = 0; i < n; i++)
            {
                ExcludedIndexes.Add(-1);
                int CurrentMin = int.MaxValue;
                minValues.Add(CurrentMin);
                for (int j = 0; j < source.Count(); j++)
                {   
                    if ( !ExcludedIndexes.Contains(j) && source.ElementAt(j) < minValues[i] && minValues[i]  >= CurrentMin)
                    {
                        CurrentMin = source.ElementAt(j);
                        minValues[i] = CurrentMin;
                        ExcludedIndexes[i] = j;
                    }
                }
            }

            return minValues;
        }

        private static List<int> compareMin(int nextMin, List<int> minValues, int startIndex) // m n Log n
        {
            for (int i = startIndex; i < minValues.Count; i++)
            {
                if (nextMin < minValues[i])
                {
                    int currentMin = minValues[i];
                    minValues[i] = nextMin;
                    compareMin(currentMin, minValues, i + 1);
                    break;
                }
            }
            return minValues;
        }
    }
}
