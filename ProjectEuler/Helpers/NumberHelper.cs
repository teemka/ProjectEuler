using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    public static class NumberHelper
    {
        public static IEnumerable<int> Primes(int upperLimit = int.MaxValue)
        {
            yield return 2;
            // Check odd numbers for primality
            const int offset = 3;
            static int ToNumber(int index) => (2 * index) + offset;
            static int ToIndex(int number) => (number - offset) / 2;
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

        public static ICollection<long> Divisors(long number)
        {
            long sqrt = (long)Math.Sqrt(number);
            var beginning = new List<long>();
            var end = new List<long>();

            for (int i = 1; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    beginning.Add(i);
                    end.Add(number / i);
                }
            }
            end.Reverse();
            return beginning.Concat(end).Distinct().ToArray();
        }

        public static ICollection<long> ProperDivisors(long number)
        {
            var divisors = Divisors(number);
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

        public static int DigitSum(BigInteger n)
        {
            BigInteger sum = 0;
            while (n != 0)
            {
                sum += n % new BigInteger(10);
                n /= 10;
            }
            return (int)sum;
        }

        public static long GCD(long a, long b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        public static long TriangleNumber(int n)
        {
            // We can safely assume the triangle number is an integer because one of n or n+1 is even
            return (long)(0.5 * n * (n + 1));
        }

        /// <summary>
        /// Checks if number is prime by using 6k ± 1 optimization
        /// </summary>
        /// <param name="n">Number to be tested.</param>
        public static bool IsPrime(long n)
        {
            if (n <= 3)
                return n > 1;
            else if (n % 2 == 0 || n % 3 == 0)
                return false;
            long i = 5;
            while (i * i <= n)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
                i += 6;
            }
            return true;
        }


        /// <summary>
        /// Returns non distinc prime factors of a number. If number is a prime - returns itself.
        /// </summary>
        /// <param name="n">Number to be factorized</param>
        /// <returns>Lazy executed prime factors</returns>
        public static IEnumerable<long> PrimeFactors(long n)
        {
            while (n % 2 == 0)
            {
                yield return 2;
                n /= 2;
            }

            // n must be odd at this point. So we can
            // skip one element (Note i = i+2)
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                // While i divides n, return i and divide n
                while (n % i == 0)
                {
                    yield return i;
                    n /= i;
                }
            }

            // This condition is to handle the case when
            // n is a prime number greater than 2
            if (n > 2)
                yield return n;
        }

        public static long BinomialCoefficient(long n, long k)
        {
            k = Math.Min(k, n - k);
            double result = 1;
            for (int i = 1; i < k + 1; i++)
                result *= (n + 1 - i) / (double)i;

            return (long)result;
        }

        public static long AllPossibleSummationsOf(int n)
        {
            var arr = Enumerable.Range(1, n - 1).ToArray();
            var table = new long[n + 1];
            table[0] = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr[i]; j <= n; j++)
                    table[j] += table[j - arr[i]];
            }

            return table[n];
        }
    }
}
