﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._41_50
{
    /// <summary>
    /// The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways:
    ///     (i) each of the three terms are prime, and,
    ///     (ii) each of the 4-digit numbers are permutations of one another.
    /// There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.
    /// What 12-digit number do you form by concatenating the three terms in this sequence?
    /// </summary>
    public class Problem049 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            var fourDigitPrimes = NumberHelper.Primes(10000).SkipWhile(x => x < 1000).ToArray();

            var groups = fourDigitPrimes
                .GroupBy(x => string.Concat(x.ToString().OrderBy(c => c)))
                .Where(g => g.Count() > 2);

            var output = new List<List<int>>();
            foreach (var group in groups)
            {
                var perms = GetPerms(group.ToArray(), 3);
                foreach (var perm in perms)
                {
                    if (IsArithmeticProgression(perm))
                        output.Add(perm.ToList());
                }
            }

            var result = string.Concat(output.Where(x => x[0] != 1487).First().Select(x => x.ToString()));

            return Task.FromResult(result);
        }

        static bool IsArithmeticProgression(IEnumerable<int> sequence)
        {
            var arr = sequence.ToArray();
            int d = arr[1] - arr[0];
            for (int i = 2; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] != d)
                {
                    return false;
                }
            }

            return true;
        }

        private static IEnumerable<IEnumerable<T>> GetPerms<T>(IList<T> list, int count)
        {
            if (count == 0)
            {
                yield return new T[0];
            }
            else
            {
                for (int i = 0; i < list.Count - count + 1; i++)
                {
                    var perms = GetPerms(list.Skip(i + 1).ToArray(), count - 1);
                    foreach (var perm in perms)
                    {
                        yield return new[] { list[i] }.Concat(perm);
                    }
                }
            }
        }
    }
}
