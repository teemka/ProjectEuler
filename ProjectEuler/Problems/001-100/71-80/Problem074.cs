namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// Digit Factorial Chains
/// https://projecteuler.net/problem=74
/// </summary>
internal sealed class Problem074 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var limit))
        {
            limit = 1_000_000;
        }

        var count = 0;
        var chain = new List<long>();

        for (var i = 0L; i < limit; i++)
        {
            FillChain(chain, i);

            if (chain.Count == 60)
            {
                count++;
            }

            chain.Clear();
        }

        return Task.FromResult(count.ToString());
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
