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
                minValues.Sort();
                minValues.Reverse();
                for (int i = 0; i < n; i++)
                {
                    if (item < minValues[i])
                    {
                        minValues[i] = item;
                        break;
                    }
                }
            }

            return minValues;
        }
    }
}
