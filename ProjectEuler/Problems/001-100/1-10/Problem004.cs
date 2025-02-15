namespace ProjectEuler.Problems._001_100._1_10;

/// <summary>
/// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
/// Find the largest palindrome made from the product of two 3-digit numbers.
/// Answer: 906609
/// </summary>
public class Problem004 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var threeDigitNumbers = Enumerable.Range(100, 899).Reverse();

        var products = from number1 in threeDigitNumbers
                       from number2 in threeDigitNumbers
                       select number1 * number2;

        var largestProduct = products
            .OrderDescending()
            .First(x => x.IsPalindrome());

        return Task.FromResult(largestProduct.ToString());
    }
}
