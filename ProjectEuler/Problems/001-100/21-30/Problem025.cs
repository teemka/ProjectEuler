﻿using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._21_30
{
    /// <summary>
    /// What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
    /// </summary>
    public class Problem025 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            var thousandDigits = NumberHelper.FibonacciSequenceBigInt()
                .Select((x, i) => (digits: (int)Math.Floor(BigInteger.Log10(x) + 1), index: i + 1))
                .SkipWhile(x => x.digits < 1000)
                .First();
            return Task.FromResult(thousandDigits.index.ToString());
        }
    }
}
