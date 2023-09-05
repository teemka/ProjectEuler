namespace ProjectEuler.Problems._101_200._141_150;

/// <summary>
/// https://projecteuler.net/problem=145
/// </summary>
public class Problem145 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out int limit))
        {
            limit = 1_000_000_000 / 2; // only need to check to halfway
        }

        int count = 0;
        for (int i = 1; i < limit; i++)
        {
            if (IsReversibleIfReverseIsGreater(i))
            {
                count++;
            }
        }

        count *= 2;

        return Task.FromResult(count.ToString());
    }

    private static bool IsReversibleIfReverseIsGreater(int value)
    {
        var reverse = value.Reverse();
        if (reverse < value)
        {
            return false;
        }

        var sum = reverse + value;
        return AllDigitsOdd(sum);
    }

    private static bool AllDigitsOdd(int n)
    {
        bool allOdd = true;
        while (n != 0)
        {
            n = Math.DivRem(n, 10, out var remainder);
            allOdd &= remainder % 2 == 1;
        }

        return allOdd;
    }
}
