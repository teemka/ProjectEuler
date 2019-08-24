using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem030
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        static void Main()
        {
            var numbers = SumOfPowers(5).ToArray();
            Console.WriteLine(numbers.Sum());
        }

        static IEnumerable<int> SumOfPowers(int length)
        {
            int start = 2;
            int end = (int)Math.Pow(10, length + 1);
            var range = Enumerable.Range(start, end - start);
            foreach (var number in range)
            {
                int sum = 0;
                foreach (var digitChar in number.ToString())
                {
                    var digit = int.Parse(digitChar.ToString());
                    sum += (int)Math.Pow(digit, length);
                }
                if (sum == number)
                    yield return number;
            }
        }
    }
}
