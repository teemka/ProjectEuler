namespace ProjectEuler.Problems._001_100._21_30;

/// <summary>
/// Number spiral diagonals
/// https://projecteuler.net/problem=28
/// </summary>
public class Problem028 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var seq = Sequences.SpiralDiagonal().Take((1001 * 2) - 1).ToArray();
        var sum = seq.Sum();
        return Task.FromResult(sum.ToString());
    }
}
