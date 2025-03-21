﻿namespace ProjectEuler.Problems._001_100._51_60;

/// <summary>
/// https://projecteuler.net/problem=53
/// </summary>
public class Problem053 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var count = 0;
        for (var n = 23; n < 101; n++)
        {
            for (var r = 1; r < n / 2; r++)
            {
                var result = NumberHelper.BinomialCoefficient(n, r);

                // binomial coefficient is symmetric
                if (result > 1_000_000)
                {
                    count += n - (2 * r) + 1;
                    break;
                }
            }
        }

        return Task.FromResult(count.ToString());
    }
}
