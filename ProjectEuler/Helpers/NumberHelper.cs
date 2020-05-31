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

        public static ICollection<int> Divisors(this int number)
        {
            int sqrt = (int)Math.Sqrt(number);
            var beginning = new List<int>();
            var end = new List<int>();

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

        public static ICollection<int> ProperDivisors(this int number)
        {
            var divisors = number.Divisors();
            return divisors.Take(divisors.Count - 1).ToArray();
        }

        public static IEnumerable<int> PrimeFactors(this int number)
        {
            if (number < 2)
                throw new ArgumentException("Number must be greater or equal 2");

            foreach (var prime in Primes(number / 2))
            {
                while (number % prime == 0)
                {
                    number /= prime;
                    yield return prime;
                    if (number == 1)
                        yield break; // all factors found
                }
            }
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
    }
}
