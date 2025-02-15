namespace ProjectEuler.Problems._001_100._1_10;

/// <summary>
/// A Pythagorean triplet is a set of three natural numbers, a &lt; b &lt; c, for which,
///     a^2 + b^2 = c^2
/// For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
/// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
/// Find the product abc.
/// </summary>
public class Problem009 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        for (var a = 1; a <= 500; a++)
        {
            for (var b = a; b <= 500; b++)
            {
                for (var c = b; c <= 500; c++)
                {
                    if ((a * a) + (b * b) == c * c && a + b + c == 1000)
                    {
                        var product = a * b * c;
                        return Task.FromResult(product.ToString());
                    }
                }
            }
        }

        return Task.FromResult("Not calculated");
    }
}
