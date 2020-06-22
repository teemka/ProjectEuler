using System.Collections.Generic;

namespace ProjectEuler.Extensions
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Checks if number is prime by using 6k ± 1 optimization
        /// </summary>
        /// <param name="n">Number to be tested.</param>
        public static bool IsPrime(this long n)
        {
            return NumberHelper.IsPrime(n);
        }

        /// <summary>
        /// Returns non distinc prime factors of a number. If number is a prime - returns itself.
        /// </summary>
        /// <param name="n">Number to be factorized</param>
        /// <returns>Lazy executed prime factors</returns>
        public static IEnumerable<long> PrimeFactors(this long n)
        {
            return NumberHelper.PrimeFactors(n);
        }

        public static ICollection<long> ProperDivisors(this long number)
        {
            return NumberHelper.ProperDivisors(number);
        }

        public static ICollection<long> Divisors(this long number)
        {
            return NumberHelper.Divisors(number);
        }
    }
}
