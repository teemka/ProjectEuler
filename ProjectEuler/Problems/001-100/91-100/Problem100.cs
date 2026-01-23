using Fractions;

namespace ProjectEuler.Problems._001_100._91_100;

/// <summary>
/// https://projecteuler.net/problem=100
/// </summary>
public sealed class Problem100 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        // Rearange the equation for P to get Pell's equation (2n - 1)^2 - 2(2b - 1)^2 = -1
        // Substitute x = 2n - 1 and y = 2b - 1 to get x^2 - 2y^2 = -1
        // Solve Pell's equation using continued fractions of sqrt(2) = [1;(2)]
        for (var i = 0; ; i++)
        {
            var convergent = new Fraction(1, 2);
            for (var j = 0; j < i; j++)
            {
                convergent += 2;
                convergent = convergent.Reciprocal();
            }

            convergent += 1;

            var (x, y) = (convergent.Numerator, convergent.Denominator);

            // Convert back to original variables
            var n = (x + 1) / 2;
            var b = (y + 1) / 2;

            if (n > 1_000_000_000_000)
            {
                return Task.FromResult(b.ToString());
            }
        }
    }
}
