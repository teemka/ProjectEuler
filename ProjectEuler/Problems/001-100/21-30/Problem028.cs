namespace ProjectEuler.Problems._001_100._21_30;

/// <summary>
/// Number spiral diagonals
/// https://projecteuler.net/problem=28
/// </summary>
public class Problem028 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var seq = Sequence().Take((1001 * 2) - 1).ToArray();
        var sum = seq.Sum();
        return Task.FromResult(sum.ToString());
    }

    public static IEnumerable<int> Sequence()
    {
        int current = 1;
        int diff = 2;
        yield return current;
        while (true)
        {
            for (int i = 0; i < 4; i++)
            {
                current += diff;
                yield return current;
            }
            diff += 2;
        }
    }
}
