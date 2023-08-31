namespace ProjectEuler.Problems._001_100._31_40;

/// <summary>
/// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.
/// The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.
/// Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
/// HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
/// </summary>
public class Problem032 : IProblem
{
    private const int Limit = 100_000;

    public Task<string> CalculateAsync(string[] args)
    {
        var products = new HashSet<int>();
        var pandigitalNumbers = Enumerable.Range(2, Limit - 2)
            .Where(x => !ContainsZero(x))
            .ToArray();

        foreach (var multiplicand in pandigitalNumbers)
        {
            if (multiplicand * 2 > Limit)
            {
                break;
            }

            foreach (var multiplier in pandigitalNumbers)
            {
                var product = multiplicand * multiplier;

                if (product > Limit)
                {
                    break;
                }

                var number = $"{multiplicand}{multiplier}{product}";
                if (number.Length == 9 && int.Parse(number).IsPandigital())
                {
                    products.Add(product);
                }
            }
        }

        var result = products.Sum();

        return Task.FromResult(result.ToString());
    }

    private static bool ContainsZero(int number) => number.GetDigits().Any(digit => digit == 0);
}
