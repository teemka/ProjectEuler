using System;

namespace ProjectEuler.Problems._701_800._711_720;

/// <summary>
/// https://projecteuler.net/problem=719
/// </summary>
public class Problem719 : IProblem
{
    public static bool TrySplit(long target, long number)
    {
        if (target < 0)
        {
            return false;
        }

        var n = number.ToString().AsSpan();

        if (n.Length == 1)
        {
            return false;
        }

        for (int i = 1; i < n.Length; i++)
        {
            var left = n[..i];
            var right = n[i..];

            var leftN = long.Parse(left);
            var rightN = long.Parse(right);

            var sum = leftN + rightN;
            if (sum == target)
            {
                return true;
            }

            if (sum < target)
            {
                continue;
            }

            if (TrySplit(target - leftN, rightN) ||
                TrySplit(target - rightN, leftN))
            {
                return true;
            }
        }

        return false;
    }

    public Task<string> CalculateAsync(string[] args)
    {
        long limit = 1_000_000_000_000; // 10^12

        if (args.Any())
        {
            limit = long.Parse(args[0]);
        }

        var i = 1;
        var n = 1L;
        var sum = 0L;
        while (n <= limit)
        {
            n = (long)Math.Pow(i, 2);

            if (n % 9 <= 1 && TrySplit(i, n))
            {
                sum += n;
            }

            i++;
        }

        return Task.FromResult(sum.ToString());
    }
}
