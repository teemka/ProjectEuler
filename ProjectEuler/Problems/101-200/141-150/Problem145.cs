using System.Runtime.InteropServices;

namespace ProjectEuler.Problems._101_200._141_150;

/// <summary>
/// https://projecteuler.net/problem=145
/// </summary>
public class Problem145 : IProblem
{
    private readonly Dictionary<int, bool> cache = [];

    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var limit))
        {
            limit = 100_000_000; // there are no 9-digit solutions
        }

        var count = 0;
        for (var i = 1; i < limit; i += 2) // skip even numbers
        {
            if (this.IsReversible(i))
            {
                count++;
            }
        }

        count *= 2;

        return Task.FromResult(count.ToString());
    }

    private bool IsReversible(int value)
    {
        var reverse = value.Reverse();

        var sum = reverse + value;

        ref var cachedValue = ref CollectionsMarshal.GetValueRefOrAddDefault(this.cache, sum, out var exists);

        if (!exists)
        {
            cachedValue = sum.GetDigits().All(int.IsOddInteger);
        }

        return cachedValue;
    }
}
