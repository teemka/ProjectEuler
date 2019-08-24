﻿using System;
using System.Linq;
using CommonProblems;

namespace Problem035
{
    class Program
    {
        /// <summary>
        /// The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.

        /// There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.

        /// How many circular primes are there below one million?
        /// </summary>
        static void Main()
        {
            var primes = NumberHelper.Primes(1_000_000).ToHashSet();

            var circuralPrimes = primes.Where(x => IsCircuralPrime(x)).ToArray();

            bool IsCircuralPrime(int n)
            {
                var number = n.ToString();
                string src = number + number;
                return Enumerable
                    .Range(0, number.Length)
                    .Select(x => src.Substring(x, number.Length))
                    .Select(int.Parse)
                    .All(x => primes.Contains(x));
            }

            Console.WriteLine(circuralPrimes.Count());
        }
    }
}
