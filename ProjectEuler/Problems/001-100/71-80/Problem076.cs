using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._71_80
{
    public class Problem076 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            var count = AllPossibleSummationsOf(100);
            return Task.FromResult(count.ToString());
        }
        static long AllPossibleSummationsOf(int n)
        {
            var arr = Enumerable.Range(1, n - 1).ToArray();
            var table = new long[n + 1];
            table[0] = 1;
            for (int i = 0; i < arr.Length; i++)
                for (int j = arr[i]; j <= n; j++)
                    table[j] += table[j - arr[i]];
            return table[n];
        }
    }
}
