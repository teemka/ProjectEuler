using System.Globalization;

namespace ProjectEuler.Problems._001_100._11_20;

/// <summary>
/// Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
/// How many such routes are there through a 20×20 grid?
/// </summary>
public class Problem015 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        return Task.FromResult(BinomialCoefficient(40, 20).ToString(CultureInfo.InvariantCulture));
    }

    private static decimal BinomialCoefficient(int n, int k)
    {
        decimal result = 1;
        for (var i = 1; i <= k; i++)
        {
            result *= n - (k - i);
            result /= i;
        }

        return result;
    }
}
