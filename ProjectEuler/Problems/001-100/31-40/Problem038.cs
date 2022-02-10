namespace ProjectEuler.Problems._001_100._31_40;

/// <summary>
/// https://projecteuler.net/problem=38
/// Answer: 932718654
/// </summary>
public class Problem038 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var pandigitals = "123456789".GetPermutations().Select(x => string.Concat(x)).ToArray();

        var output = new List<((long Number, int N) Input, string Pandigital)>();
        foreach (var pandigital in pandigitals)
        {
            var pandigitalNumber = long.Parse(pandigital);
            for (int length = 1; length < 9; length++)
            {
                var number = long.Parse(pandigital[..length]);
                int n = 2;
                while (true)
                {
                    var multiple = CreateMultiple(number, n);
                    var s = multiple.ToString();
                    if (s == pandigital)
                    {
                        output.Add(((number, n), s));
                    }
                    else if (multiple > pandigitalNumber)
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

    private static long CreateMultiple(long number, int n)
    {
        var multiples = Enumerable.Range(1, n)
            .Select(x => number * x);
        var multiplesAsStrings = multiples.Select(x => x.ToString());
        return long.Parse(string.Concat(multiplesAsStrings));
    }
}
