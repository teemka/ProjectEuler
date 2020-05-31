﻿using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._1_10
{
    /// <summary>
    /// Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:

    ///     1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

    /// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
    /// Answer: 4613732
    /// </summary>
    public class Problem002 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            var sum = NumberHelper.FibonacciSequence().TakeWhile(x => x <= 4_000_000).Where(x => x % 2 == 0).Sum();
            return Task.FromResult(sum.ToString());
        }
    }
}
