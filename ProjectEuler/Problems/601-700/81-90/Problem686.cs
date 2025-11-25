namespace ProjectEuler.Problems._601_700._81_90;

/// <summary>
/// https://projecteuler.net/problem=686
/// </summary>
public class Problem686 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        const int target = 678910;

        var result = Calculate(target);

        return Task.FromResult(result.ToString());
    }

    public static int Calculate(int n)
    {
        var count = 0;
        var value = 1.0;
        for (int i = 1; ; i++)
        {
            value *= 2;
            if (value > 10)
            {
                value /= 10;
            }

            if (value is not >= 1.23 or not < 1.24)
            {
                continue;
            }

            if (n == ++count)
            {
                return i;
            }
        }
    }
}
