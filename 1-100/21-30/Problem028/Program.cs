using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem028
{
    class Program
    {
        /// <summary>
        /// Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:
        /// 
        ///     21 22 23 24 25
        ///     20  7  8  9 10
        ///     19  6  1  2 11
        ///     18  5  4  3 12
        ///     17 16 15 14 13
        /// 
        /// It can be verified that the sum of the numbers on the diagonals is 101.
        /// 
        /// What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
        /// </summary>
        static void Main()
        {
            var seq = Sequence().Take(1001 * 2 - 1).ToArray();
            var sum = seq.Sum();
            Console.WriteLine(sum);
        }

        static IEnumerable<int> Sequence()
        {
            int current = 1;
            int diff = 2;
            yield return current;
            while (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    current += diff;
                    yield return current;
                }
                diff += 2;
            }
        }
    }
}
