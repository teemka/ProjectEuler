using System;
using System.Collections.Generic;
using System.Linq;
using CommonProblems;

namespace Problem037
{
    class Program
    {
        /// <summary>
        /// The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.

        /// Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

        /// NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
        /// </summary>
        static void Main()
        {
            var primesSet = NumberHelper.Primes(1_000_000)
                .Select(x => x.ToString())
                .ToHashSet();

            var output = new HashSet<string>();
            foreach (var prime in primesSet.Where(p => p.Length > 1))
            {
                if (Enumerable.Range(0, prime.Length - 1)
                    .All(i =>
                    {
                        var trunactedFromLeft = prime[(i + 1)..];
                        var truncatedFromRight = prime[..^(i + 1)];

                        return primesSet.Contains(trunactedFromLeft) &&
                               primesSet.Contains(truncatedFromRight);
                    }))
                {
                    output.Add(prime);
                }
            }
            var sum = output.Select(x => Convert.ToInt32(x)).Sum();
            Console.WriteLine(sum);
        }
    }
}
