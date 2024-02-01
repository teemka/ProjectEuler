namespace ProjectEuler.Problems._601_700._681_690;

public class Problem684 : IProblem
{
    private static readonly Dictionary<long, long> SCache = [];

    public static long S(long k)
    {
        if (SCache.TryGetValue(k, out long value))
        {
            return value;
        }

        var sum = 0L;
        for (int n = 1; n <= k; n++)
        {
            sum += SmallestNumberWithDigitSumOf(n);
        }

        SCache.Add(k, sum);

        return sum;
    }

    public static long SmallestNumberWithDigitSumOf(long n)
    {
        var minNumberOfDigits = Math.Ceiling(n / 9d);

        var rest = n - ((minNumberOfDigits - 1) * 9);

        var output = (long)rest;
        for (int i = 0; i < minNumberOfDigits - 1; i++)
        {
            output *= 10;
            output += 9;
        }

        return output;
    }

    public Task<string> CalculateAsync(string[] args)
    {
        var result = Sequences
            .Fibonacci<int>()
            .Skip(2)
            .Take(88)
            .Select(x => S(x))
            .Aggregate(0L, (x, y) => (x + y) % 1_000_000_007);

        return Task.FromResult(result.ToString());
    }
}
