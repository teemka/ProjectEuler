using System.Text.RegularExpressions;

namespace ProjectEuler.Problems._201_300._201_210;

/// <summary>
/// https://projecteuler.net/problem=206
/// </summary>
public partial class Problem206 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var lowerBound = (long)Math.Sqrt(1020304050607080900);
        var upperBound = (long)Math.Sqrt(1929394959697989990);
        long Result()
        {
            var current = lowerBound;
            while (current < upperBound)
            {
                var pow = (long)Math.Pow(current, 2);
                current++;

                if (pow % 10 != 0)
                {
                    continue;
                }

                var str = pow.ToString("0000000000000000000");
                if (Regex().IsMatch(str))
                {
                    return pow;
                }
            }

            return current;
        }

        return Task.FromResult($"{Result()}");
    }

    [GeneratedRegex("^1.2.3.4.5.6.7.8.9.0$")]
    private static partial Regex Regex();
}
