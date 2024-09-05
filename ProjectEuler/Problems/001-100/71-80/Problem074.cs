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
            var l = this.Rec(i);

            if (l == 60)
            {
                count++;
            }
        }

        return Task.FromResult(count.ToString());
    }

    public long Rec(long n)
    {
        if (this.cache.TryGetValue(n, out var v))
        {
            return v;
        }

        var known = n switch
        {
            169 => 3,
            871 => 2,
            872 => 2,
            1454 => 3,
            _ => 0,
        };

        if (known != 0)
        {
            return known;
        }

        var next = DigitFactorial(n);

        if (next == n)
        {
            this.cache[n] = v;
            return 1;
        }

        v = this.Rec(next) + 1;

        this.cache[n] = v;
        return v;
    }

    public static void FillChain(List<long> chain, long n)
    {
        while (true)
        {
            chain.Add(n);
            n = DigitFactorial(n);

            if (chain.Contains(n))
            {
                break;
            }
        }
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
