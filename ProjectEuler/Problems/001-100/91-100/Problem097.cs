﻿namespace ProjectEuler.Problems._001_100._91_100;

/// <summary>
/// https://projecteuler.net/problem=97
/// Solution: 8739992577
/// </summary>
public class Problem097 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        long x = 1;
        for (int i = 0; i < 7_830_457; i++)
        {
            x *= 2;
            x %= 10_000_000_000;
        }

        x *= 28433;
        x += 1;

        var last10digits = x.ToString()[^10..];
        return Task.FromResult(last10digits);
    }
}
