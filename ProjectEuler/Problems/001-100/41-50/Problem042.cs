using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._41_50
{
    /// <summary>
    /// https://projecteuler.net/problem=42
    /// </summary>
    public class Problem042 : IProblem
    {
        public async Task<string> CalculateAsync(string[] args)
        {
            var textFile = await File.ReadAllTextAsync("Problems/001-100/41-50/Problem042_words.txt");
            var words = textFile.Split(',').Select(x => x[1..^1]);

            var triangleNumbers = Enumerable.Range(1, 100).Select(x => NumberHelper.TriangleNumber(x)).ToHashSet();

            var count = words.Select(CalculateAlphabeticalSumUppercase).Where(x => triangleNumbers.Contains(x)).Count();

            return count.ToString();
        }

        public int CalculateAlphabeticalSumUppercase(string word)
        {
            return word.Select(c => c.ToAlphabeticalPositionUppercase()).Sum();
        }
    }
}
