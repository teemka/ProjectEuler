using System;
using System.Linq;
using CommonProblems;

namespace Problem041
{
    class Program
    {
        /// <summary>
        /// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime.
        /// 
        /// What is the largest n-digit pandigital prime that exists?
        /// </summary>
        static void Main()
        {
            var primes = NumberHelper.Primes(999_999_999).ToArray();
            int max = 0;
            foreach (var prime in primes)
            {
                if (prime.IsPandigital() && prime > max)
                    max = prime;
            }
            Console.WriteLine(max);
        }
    }

    public static class Extensions
    {
        public static bool IsPandigital(this int number)
        {
            var num = number.ToString();
            int n = num.Length;
            return num.Distinct().Count() == num.Length && num.All(x => x >= '1' && x <= (n + '0'));
        }
    }
}
