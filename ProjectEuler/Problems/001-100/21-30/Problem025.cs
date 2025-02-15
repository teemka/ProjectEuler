using System.Numerics;

namespace ProjectEuler.Problems._001_100._21_30;

/// <summary>
/// What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
/// </summary>
public class Problem025 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var (_, index) = Sequences.Fibonacci<BigInteger>()
            .Select((x, i) => (digits: x.DigitCount(), index: i + 1))
            .SkipWhile(x => x.digits < 1000)
            .First();
        return Task.FromResult(index.ToString());
    }
}
