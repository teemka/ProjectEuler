using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._71_80
{
    /// <summary>
    /// https://projecteuler.net/problem=76
    /// </summary>
    public class Problem076 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            var count = NumberHelper.AllPossibleSummationsOf(100);
            return Task.FromResult(count.ToString());
        }
    }
}
