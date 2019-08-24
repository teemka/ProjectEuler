using System;
using System.Linq;
using CommonProblems;

namespace Problem024
{
    class Program
    {
        /// <summary>
        /// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4.
        /// If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
        ///     012   021   102   120   201   210
        /// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
        /// </summary>
        static void Main()
        {
            var perms = "0123456789".GetPermutations().AsParallel().Select(x => string.Concat(x)).OrderBy(x => x).ToArray();
            var milionth = perms.Skip(999_999).First();
            Console.WriteLine(milionth);
        }
    }
}
