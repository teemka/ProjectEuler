﻿namespace ProjectEuler.Problems._001_100._11_20;

/// <summary>
/// The following iterative sequence is defined for the set of positive integers:
///
///     n → n/2 (n is even)
///     n → 3n + 1 (n is odd)
///
/// Using the rule above and starting with 13, we generate the following sequence:
///     13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
///
/// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
///
/// Which starting number, under one million, produces the longest chain?
///
/// NOTE: Once the chain starts the terms are allowed to go above one million.
/// </summary>
public class Problem014 : IProblem
{
    private readonly Dictionary<long, int> cache = new() { { 1, 1 }, { 13, 10 } };

    public Task<string> CalculateAsync(string[] args)
    {
        var (start, _) = Enumerable.Range(1, 999_999)
            .Select(x => (start: x, count: this.CollatzCount(x)))
            .MaxBy(x => x.count);

        return Task.FromResult(start.ToString());
    }

    public int CollatzCount(long n)
    {
        if (this.cache.TryGetValue(n, out var count))
        {
            return count;
        }

        var next = long.IsEvenInteger(n)
            ? n / 2
            : (3 * n) + 1;

        var sum = 1 + this.CollatzCount(next);

        this.cache[n] = sum;

        return sum;
    }
}
