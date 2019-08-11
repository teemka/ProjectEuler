using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        /// <summary>
        /// The prime factors of 13195 are 5, 7, 13 and 29.
        ///What is the largest prime factor of the number 600851475143 ?
        /// </summary>
        static void Main()
        {
            long largestFactor = PrimeFactors(600851475143).Last();
            Console.WriteLine(largestFactor);
        }

        public static IEnumerable<long> PrimeFactors(long n)
        {
            int prev = 1;
            while (n % 2 == 0)
            {
                if (prev != 2)
                {
                    yield return 2;
                    prev = 2;
                }
                n /= 2;
            }

            // n must be odd at this point. So we can 
            // skip one element (Note i = i +2) 
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                // While i divides n, print i and divide n 
                while (n % i == 0)
                {
                    if (prev != i)
                    {
                        yield return i;
                        prev = i;
                    }
                    n /= i;
                }
            }

            // This condition is to handle the case whien 
            // n is a prime number greater than 2 
            if (n > 2)
                yield return n;
        }
    }
}
