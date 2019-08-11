using System;
using System.Collections;
using System.Collections.Generic;

namespace CommonProblems
{
    public static class NumberHelper
    {
        /// <summary>
        /// Checks if number is prime by using 6k ± 1 optimization
        /// </summary>
        /// <param name="n">Number to be tested.</param>
        public static bool IsPrime(int n)
        {
            if (n < 3)
                return n > 1;
            else if (n % 2 == 0 || n % 3 == 0)
                return false;
            int i = 5;
            while (i * i <= n)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
                i += 6;
            }
            return true;
        }

        public static IEnumerable<int> Primes(int upperLimit = int.MaxValue)
        {
            yield return 2;
            // Check odd numbers for primality
            const int offset = 3;
            int ToNumber(int index) => 2 * index + offset;
            int ToIndex(int number) => (number - offset) / 2;
            var bits = new BitArray(ToIndex(upperLimit) + 1, defaultValue: true);
            var upperSqrtIndex = ToIndex((int)Math.Sqrt(upperLimit));
            for (var i = 0; i <= upperSqrtIndex; i++)
            {
                // If this bit has already been turned off, then its associated number is composite. 
                if (!bits[i]) continue;
                var number = ToNumber(i);
                // The instant we have a known prime, immediately yield its value.
                yield return number;
                // Any multiples of number are composite and their respective bits should be turned off.
                for (var j = ToIndex(number * number); (j > i) && (j < bits.Length); j += number)
                    bits[j] = false;
            }
            // Output remaining primes once bit array is fully resolved:
            for (var i = upperSqrtIndex + 1; i < bits.Length; i++)
            {
                if (bits[i])
                    yield return ToNumber(i);
            }
        }
    }
}
