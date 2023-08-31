namespace ProjectEuler.Extensions;

public static class NumberExtensions
{
    /// <summary>
    /// Is the number a palindrome in decimal representation.
    /// </summary>
    /// <param name="value">The number to check.</param>
    /// <returns>A value indicating if a nubmer is a palindrome.</returns>
    public static bool IsPalindrome(this int value)
    {
        var reversed = value.Reverse();
        return reversed == value;
    }

    /// <summary>
    /// Is the number a palindrome in decimal representation.
    /// </summary>
    /// <param name="value">The number to check.</param>
    /// <returns>A value indicating if a nubmer is a palindrome.</returns>
    public static bool IsPalindrome(this long value)
    {
        var reversed = value.Reverse();
        return reversed == value;
    }

    public static bool IsPandigital(this int number)
    {
        var digits = number.GetDigits().ToArray();

        return digits.Distinct().Count() == digits.Length &&
            digits.All(x => x > 0 && x <= digits.Length);
    }

    /// <summary>
    /// Checks if number is prime by using 6k ± 1 optimization.
    /// </summary>
    /// <param name="n">Number to be tested.</param>
    /// <returns>value indicating if the number is prime.</returns>
    public static bool IsPrime(this long n)
    {
        return NumberHelper.IsPrime(n);
    }

    /// <summary>
    /// Returns non distinc prime factors of a number. If number is a prime - returns itself.
    /// </summary>
    /// <param name="n">Number to be factorized</param>
    /// <returns>Lazy executed prime factors</returns>
    public static IEnumerable<long> PrimeFactors(this long n)
    {
        return NumberHelper.PrimeFactors(n);
    }

    public static ICollection<long> ProperDivisors(this long number)
    {
        return NumberHelper.ProperDivisors(number);
    }

    public static ICollection<long> Divisors(this long number)
    {
        return NumberHelper.Divisors(number);
    }

    public static IEnumerable<int> GetDigits(this int n)
    {
        while (n != 0)
        {
            n = Math.DivRem(n, 10, out var remainder);
            yield return remainder;
        }
    }

    /// <summary>
    /// Reverse decimal number by its digits. 123 becomes 321. 200 becomes 2.
    /// </summary>
    /// <param name="value">value to reverse.</param>
    /// <returns>reversed value.</returns>
    public static int Reverse(this int value)
    {
        int reversed = 0;
        while (value > 0)
        {
            value = Math.DivRem(value, 10, out var remainder);
            reversed = (reversed * 10) + remainder;
        }

        return reversed;
    }

    /// <summary>
    /// Reverse decimal number by its digits. 123 becomes 321. 200 becomes 2.
    /// </summary>
    /// <param name="value">value to reverse.</param>
    /// <returns>reversed value.</returns>
    public static long Reverse(this long value)
    {
        long reversed = 0;
        while (value > 0)
        {
            value = Math.DivRem(value, 10, out var remainder);
            reversed = (reversed * 10) + remainder;
        }

        return reversed;
    }
}
