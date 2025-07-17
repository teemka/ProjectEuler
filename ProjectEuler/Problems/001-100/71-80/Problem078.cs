namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// https://projecteuler.net/problem=78
/// </summary>
public class Problem078 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        const int range = 56_000;
        const int million = 1_000_000;
        var output = 0;

        var table = new int[range + 1];
        table[0] = 1;
        for (var i = 0; i < range - 1; i++)
        {
            var i1 = i + 1;
            for (var j = i1; j <= range; j++)
            {
                table[j] %= million;
                table[j] += table[j - i1] % million;
            }

            if (table[i] % million == 0)
            {
                output = i;
                break;
            }
        }

        return Task.FromResult(output.ToString());
    }
}
