using System;
using System.Linq;
using System.Numerics;

namespace Problem016
{
    class Program
    {
        /// <summary>
        /// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

        /// What is the sum of the digits of the number 2^1000?
        /// </summary>
        static void Main()
        {
            var result = BigInteger.Pow(2, 1000);
            var digitSum = result.ToString().Select(x => int.Parse(x.ToString())).Sum();
            Console.WriteLine(digitSum);
        }
    }
}
