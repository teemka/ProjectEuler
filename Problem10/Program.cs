using System;
using System.Linq;
using static CommonProblems.NumberHelper;

namespace Problem10
{
    class Program
    {
        /// <summary>
        /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
        /// Find the sum of all the primes below two million.
        /// </summary>
        static void Main()
        {
            long sum = Primes(2_000_000).Select(x => (long)x).Sum();
            Console.WriteLine(sum);
        }
    }
}
