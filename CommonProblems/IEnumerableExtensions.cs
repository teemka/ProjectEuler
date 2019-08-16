using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonProblems
{
    public static class IEnumerableExtensions
    {
        public static long LargestProductOfConsecutiveNumbers(this IEnumerable<int> sequence, int count)
        {
            var length = sequence.Count();
            long largest = long.MinValue;
            for (int i = 0; i < length - count; i++)
            {
                var digits = sequence.Skip(i).Take(count).ToArray();
                long product = digits.Aggregate((long)1, (a, b) => a * b);
                if (product > largest)
                    largest = product;
            }

            return largest;
        }
    }
}
