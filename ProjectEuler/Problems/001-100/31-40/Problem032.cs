namespace ProjectEuler.Problems._001_100._31_40;

/// <summary>
/// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.
/// The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.
/// Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
/// HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
/// </summary>
public class Problem032 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        const int limit = 100_000;
        var pandigitalNumbers = Enumerable.Range(2, limit - 2).Where(x => x.IsPandigital()).ToArray();

        var results = new List<(int, int, int Product)>();
        foreach (var multiplicand in pandigitalNumbers)
        {
            if (multiplicand * 2 > limit)
            {
                break;
            }

            foreach (var multiplier in pandigitalNumbers)
            {
                var product = multiplicand * multiplier;

                if (product > limit)
                {
                    break;
                }

                var number = $"{multiplicand}{multiplier}{product}";
                if (number.Length == 9 && int.Parse(number).IsPandigital())
                {
                    results.Add((multiplicand, multiplier, product));
                }
            }
        }

        var products = results.Select(x => x.Product).Distinct().OrderBy(x => x).ToArray();
        var result = products.Sum();

        return Task.FromResult(result.ToString());
    }
}
