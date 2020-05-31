﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._1_10
{
    /// <summary>
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    /// What is the largest prime factor of the number 600851475143 ?
    /// Answer: 6857
    /// </summary>
    public class Problem003 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            long largestFactor = NumberHelper.PrimeFactors(600851475143).Last();
            return Task.FromResult(largestFactor.ToString());
        }
    }
}
