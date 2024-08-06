using System.Diagnostics;

namespace ProjectEuler.Problems._001_100._41_50;

/// <summary>
/// https://projecteuler.net/problem=47
/// Answer: 134043
/// </summary>
public class Problem047 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var result = ConsecutiveNumbersToHaveDistinctPrimeFactors(1000, 1000000, 4, 4);

        return Task.FromResult(result.First().ToString());
    }

    private static int[] ConsecutiveNumbersToHaveDistinctPrimeFactors(int start, int end, int consecutiveCount, int primeFactorsCount)
    {
        var output = new List<int>(consecutiveCount);

        var numbers = Enumerable.Range(start, end - start + 1);
        foreach (var number in numbers)
        {
            var factors = ((long)number).PrimeFactors();
            if (factors.Count() == primeFactorsCount)
            {
                output.Add(number);
            }
            else
            {
                output.Clear();
            }

            if (output.Count == consecutiveCount)
            {
                return [.. output];
            }
        }

        return [];
    }
}
