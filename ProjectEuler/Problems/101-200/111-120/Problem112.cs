using System.Globalization;

namespace ProjectEuler.Problems._101_200._111_120;

/// <summary>
/// https://projecteuler.net/problem=112
/// Answer: 1587000
/// </summary>
public class Problem112 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!double.TryParse(args.FirstOrDefault(), out var target))
        {
            target = 0.99;
        }

        var bouncyCount = 0;
        var i = 1;
        while (true)
        {
            var result = IsBouncy(i);
            if (result)
            {
                bouncyCount++;
            }

            var percentage = bouncyCount / (double)i;

            if (percentage >= target)
            {
                break;
            }

            i++;
        }

        return Task.FromResult(i.ToString());
    }

    internal static bool IsBouncy(int number)
    {
        var n = number.ToString(CultureInfo.InvariantCulture);

        var isIncreasing = true;
        var isDecreasing = true;

        for (var i = 0; i < n.Length - 1; i++)
        {
            var (first, second) = (n[i], n[i + 1]);
            if (isIncreasing && first > second)
            {
                isIncreasing = false;
            }

            if (isDecreasing && first < second)
            {
                isDecreasing = false;
            }

            if (!isIncreasing && !isDecreasing)
            {
                return true;
            }
        }

        return false;
    }
}
