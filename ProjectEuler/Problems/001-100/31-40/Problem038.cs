using System.Text;

namespace ProjectEuler.Problems._001_100._31_40;

/// <summary>
/// https://projecteuler.net/problem=38
/// Answer: 932718654
/// </summary>
public class Problem038 : IProblem
{
    private static readonly StringBuilder StringBuilder = new();

    public Task<string> CalculateAsync(string[] args)
    {
        var pandigitals = "123456789".ToList().GetPermutations().Select(x => string.Concat(x));

        var output = new List<((long Number, int N) Input, string Pandigital)>();
        foreach (var pandigital in pandigitals)
        {
            var pandigitalNumber = long.Parse(pandigital);
            for (var length = 1; length < 9; length++)
            {
                var number = long.Parse(pandigital[..length]);
                var n = 2;
                while (true)
                {
                    var multiple = CreateMultiple(number, n);
                    if (multiple == pandigital)
                    {
                        output.Add(((number, n), pandigital));
                    }
                    else if (long.Parse(multiple) > pandigitalNumber)
                    {
                        break;
                    }

                    n++;
                }
            }
        }

        var (_, maxPandigital) = output.MaxBy(x => x.Pandigital);

        return Task.FromResult(maxPandigital);
    }

    private static string CreateMultiple(long number, int n)
    {
        StringBuilder.Clear();
        for (var i = 1; i <= n; i++)
        {
            StringBuilder.Append(number * i);
        }

        return StringBuilder.ToString();
    }
}
