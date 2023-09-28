using System;

namespace ProjectEuler.Problems._701_800._711_720;

/// <summary>
/// https://projecteuler.net/problem=719
/// </summary>
public class Problem719 : IProblem
{
    public static bool TrySplit(long target, long number)
    {
        if (target > number)
        {
            return false;
        }

        if (target == number)
        {
            return true;
        }

        var divisor = 10L;

        while (divisor < number)
        {
            var (left, right) = Math.DivRem(number, divisor);
            if (right < target && TrySplit(target - right, left))
            {
                return true;
            }

            divisor *= 10;
        }

        return false;
    }

    public Task<string> CalculateAsync(string[] args)
    {
        var limit = 1_000_000_000_000; // 10^12

        if (args.Any())
        {
            limit = long.Parse(args[0]);
        }

        var n = 1L;
        var sum = 0L;
        for (var i = 2L; n <= limit; i++)
        {
            n = i * i;

            // digit sum mod 9 optimization
            if (n % 9 <= 1 && TrySplit(i, n))
            {
                sum += n;
            }
        }

        return Task.FromResult(sum.ToString());
    }
}
