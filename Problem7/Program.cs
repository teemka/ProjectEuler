using System;
using System.Linq;
using static CommonProblems.NumberHelper;

namespace Problem7
{
    class Program
    {
        /// <summary>
        /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
        /// What is the 10 001st prime number?
        /// </summary>
        static void Main()
        {
            int primeNo10001 = Primes().Take(10001).Last();
            Console.WriteLine(primeNo10001);
        }
    }
}
