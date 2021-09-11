using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

        public static IEnumerable<int> GetDigits(this int n)
        {
            while (n != 0)
            {
                n = Math.DivRem(n, 10, out var remainder);
                yield return remainder;
            }
        }

        /// <summary>
        /// Reverse decimal number by its digits. 123 becomes 321. 200 becomes 2
        /// </summary>
        public static int Reverse(this int value)
        {
            int reversed = 0;
            while (value > 0)
            {
                value = Math.DivRem(value, 10, out var remainder);
                reversed = (reversed * 10) + remainder;
            }
            return reversed;
        }
    }
}
