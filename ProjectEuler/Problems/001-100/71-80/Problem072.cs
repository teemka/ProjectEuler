using System.Collections.Concurrent;

namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// Counting Fractions
/// https://projecteuler.net/problem=72
/// </summary>
public class Problem072 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var size))
        {
            size = 1_000_000;
        }

        // Use Farey Sequence
        var count = Partitioner.Create(Enumerable
            .Range(3, size - 2), EnumerablePartitionerOptions.NoBuffering)
            .AsParallel()
            .Sum(denominator =>
            {
                var count = 1L; // 1 / denominator

                var half = denominator / 2;
                var numerators = Enumerable.Range(2, half);

                foreach (var numerator in numerators)
                {
                    if (numerator > half)
                    {
                        break;
                    }

                    if (NumberHelper.GCD(numerator, denominator) == 1)
                    {
                        count++;
                    }
                }

                return count;
            });

        count *= 2;
        count++;

        return Task.FromResult(count.ToString());
    }
}
