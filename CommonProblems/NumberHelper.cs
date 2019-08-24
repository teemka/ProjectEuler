using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CommonProblems
{
    public static class NumberHelper
    {
        /// <summary>
        /// Checks if number is prime by using 6k ± 1 optimization
        /// </summary>
        /// <param name="n">Number to be tested.</param>
        public static bool IsPrime(this int n)
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

        public static ICollection<int> Divisors(this int number)
        {
            int sqrt = (int)Math.Sqrt(number);
            var beggining = new List<int>();
            var end = new List<int>();

            for (int i = 1; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    beggining.Add(i);
                    end.Add(number / i);
                }
            }
            end.Reverse();
            return beggining.Concat(end).Distinct().ToArray();
        }

        public static ICollection<int> ProperDivisors(this int number)
        {
            var divisors = number.Divisors();
            return divisors.Take(divisors.Count - 1).ToArray();
        }

        public static IEnumerable<long> FibonacciSequence()
        {
            long prev = 1;
            long current = 1;
            long temp;
            yield return prev;
            yield return current;
            while (true)
            {
                temp = current;
                current += prev;
                yield return current;
                prev = temp;
            }
        }

        public static IEnumerable<BigInteger> FibonacciSequenceBigInt()
        {
            BigInteger prev = 1;
            BigInteger current = 1;
            BigInteger temp;
            yield return prev;
            yield return current;
            while (true)
            {
                temp = current;
                current += prev;
                yield return current;
                prev = temp;
            }
        }

        public static int DigitSum(int n)
        {
            int sum = 0;
            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
    }
}
