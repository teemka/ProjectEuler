namespace ProjectEuler.Problems._001_100._31_40;

/// <summary>
/// The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.
///
/// Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
///
/// (Please note that the palindromic number, in either base, may not include leading zeros.)
/// </summary>
public class Problem036 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        long sum = Enumerable.Range(1, 999_999)
            .Where(x => x.IsPalindrome() && Convert.ToString(x, 2).IsPalindrome())
            .Select(x => (long)x)
            .Sum();

        return Task.FromResult(sum.ToString());
    }
}
