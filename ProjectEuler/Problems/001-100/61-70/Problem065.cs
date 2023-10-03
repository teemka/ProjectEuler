using Fractions;

namespace ProjectEuler.Problems._001_100._61_70;

public class Problem065 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var arr = ExpandE().Take(100).Reverse().ToArray();

        var fraction = new Fraction(1, arr[0]);
        foreach (var number in arr.Skip(1))
        {
            fraction += number;
            fraction = fraction.Reciprocal();
        }

        fraction = fraction.Reciprocal();

        return Task.FromResult(fraction.Numerator.DigitSum().ToString());
    }

    private static IEnumerable<int> ExpandE()
    {
        yield return 2;
        yield return 1;

        var k = 0;
        while (true)
        {
            yield return k += 2;
            yield return 1;
            yield return 1;
        }
    }
}
