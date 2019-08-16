using System;
using System.Linq;

namespace Problem005
{
    class Program
    {
        /// <summary>
        /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
        /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
        /// </summary>
        static void Main()
        {
            var divisors = Enumerable.Range(1, 20).ToArray();

            int value = 20;
            while (!IsEvenlyDivisible(value, divisors))
                value++;

            Console.WriteLine(value);
        }

        public static bool IsEvenlyDivisible(int value, int[] divisors)
        {
            return divisors.All(divisor => value % divisor == 0);
        }
    }
}
