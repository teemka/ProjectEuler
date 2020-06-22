using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._21_30
{
    /// <summary>
    /// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4.
    /// If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
    ///     012   021   102   120   201   210
    /// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
    /// </summary>
    public class Problem024 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            var perms = "0123456789".GetPermutations().AsParallel().Select(x => string.Concat(x)).OrderBy(x => x).ToArray();
            var milionth = perms.Skip(999_999).First();
            return Task.FromResult(milionth.ToString());
        }
    }
}
