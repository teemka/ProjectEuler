namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// Digit Factorial Chains
/// https://projecteuler.net/problem=74
/// </summary>
internal sealed class Problem074 : IProblem
{
    private readonly Dictionary<long, long> cache = [];

    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var limit))
        {
            limit = 1_000_000;
        }

        var count = 0;
        for (var i = 0L; i < limit; i++)
        {
            var l = this.ChainLength(i);

            if (l == 60)
            {
                count++;
            }
        }

        return Task.FromResult(count.ToString());
    }

    public long ChainLength(long n)
    {
        if (this.cache.TryGetValue(n, out var cached))
        {
            return cached;
        }

        var knownLoops = n switch
        {
            169 => 3, // 169 -> 363601 -> 1454 -> 169
            871 => 2, // 871 -> 45361 -> 871
            872 => 2, // 872 -> 45362 -> 872
            1454 => 3, // 1454 -> 169 -> 363601 -> 1454
            _ => 0,
        };

        if (knownLoops != 0)
        {
            return knownLoops;
        }

        var next = DigitFactorial(n);

        if (next == n)
        {
            this.cache[n] = n;
            return 1;
        }

        cached = this.ChainLength(next) + 1;

        this.cache[n] = cached;
        return cached;
    }

    public static long DigitFactorial(long n) =>
        n.GetDigits().Sum(Factorial);

    private static long Factorial(long n) => n switch
    {
        0 => 1,
        1 => 1,
        2 => 2,
        3 => 6,
        4 => 24,
        5 => 120,
        6 => 720,
        7 => 5040,
        8 => 40320,
        9 => 362880,
        _ => throw new ArgumentException("Expected a digit"),
    };
}
