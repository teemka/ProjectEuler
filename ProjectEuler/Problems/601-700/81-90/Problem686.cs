namespace ProjectEuler.Problems._601_700._81_90;

/// <summary>
/// https://projecteuler.net/problem=686
/// </summary>
public class Problem686 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        const int target = 678910;

        var count = 0;
        for (int i = 0; ; i++)
        {
            if (123 != GetFirstDigitsOfPow2(digits: 3, exponent: i))
            {
                continue;
            }

            if (target != ++count)
            {
                continue;
            }

            return Task.FromResult(i.ToString());
        }
    }

    private static int GetFirstDigitsOfPow2(int digits, int exponent) =>
        GetFirstDigitsOfPow(digits, @base: 2, exponent);

    private static int GetFirstDigitsOfPow(int digits, int @base, int exponent)
    {
        // Transform the number to 10^x form
        var decimalExponent = exponent * Math.Log10(@base);
        var fractionalPart = decimalExponent - (int)decimalExponent;
        return (int)Math.Pow(10, digits - 1 + fractionalPart);
    }
}
