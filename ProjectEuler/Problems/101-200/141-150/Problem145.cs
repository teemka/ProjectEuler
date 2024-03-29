﻿namespace ProjectEuler.Problems._101_200._141_150;

/// <summary>
/// https://projecteuler.net/problem=145
/// </summary>
public class Problem145 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out int limit))
        {
            limit = 100_000_000; // there are no 9-digit solutions
        }

        int count = 0;
        for (int i = 1; i < limit; i += 2)
        {
            if (IsReversible(i))
            {
                count++;
            }
        }

        count *= 2;

        return Task.FromResult(count.ToString());
    }

    private static bool IsReversible(int value)
    {
        var reverse = value.Reverse();

        var sum = reverse + value;
        return sum.GetDigits().All(x => x % 2 == 1);
    }
}
