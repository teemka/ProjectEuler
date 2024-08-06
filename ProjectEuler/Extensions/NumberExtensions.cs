using System.Numerics;

namespace ProjectEuler.Extensions;

public static class NumberExtensions
{
    /// <summary>
    /// Is the number a palindrome in decimal representation.
    /// </summary>
    /// <typeparam name="T">Type of integer.</typeparam>
    /// <param name="value">The number to check.</param>
    /// <returns>A value indicating if a nubmer is a palindrome.</returns>
    public static bool IsPalindrome<T>(this T value)
        where T : IBinaryInteger<T>
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
    /// Returns distinct prime factors of a number. If number is a prime - returns itself.
    /// </summary>
    /// <typeparam name="T">Type of number.</typeparam>
    /// <param name="n">Number to be factorized</param>
    /// <returns>Lazy executed prime factors</returns>
    public static IEnumerable<T> PrimeFactors<T>(this T n)
        where T : INumber<T>
    {
        return NumberHelper.PrimeFactors(n);
    }

    public static IReadOnlyCollection<T> ProperDivisors<T>(this T number)
        where T : INumber<T>
    {
        return NumberHelper.ProperDivisors(number);
    }

    public static IReadOnlyCollection<T> Divisors<T>(this T number)
        where T : INumber<T>
    {
        return NumberHelper.Divisors(number);
    }

    public static IEnumerable<T> GetDigits<T>(this T n)
        where T : IBinaryInteger<T>
    {
        var ten = T.CreateChecked(10);
        while (n != T.Zero)
        {
            (n, var remainder) = T.DivRem(n, ten);
            yield return remainder;
        }
    }

    /// <summary>
    /// Reverse decimal integer by its digits. 123 becomes 321. 200 becomes 2.
    /// </summary>
    /// <typeparam name="T">Type of integer.</typeparam>
    /// <param name="value">value to reverse.</param>
    /// <returns>reversed value.</returns>
    public static T Reverse<T>(this T value)
        where T : IBinaryInteger<T>
    {
        var ten = T.CreateChecked(10);
        var reversed = T.Zero;
        while (value > T.Zero)
        {
            (value, var remainder) = T.DivRem(value, ten);
            reversed = (reversed * ten) + remainder;
        }

        return reversed;
    }

    public static int DigitCount<T>(this T number)
        where T : IFloatingPointIeee754<T> => NumberHelper.DigitCount(number);

    public static int DigitCount(this BigInteger number) =>
        NumberHelper.DigitCount(number);

    public static T DigitSum<T>(this T number)
        where T : IBinaryInteger<T> => NumberHelper.DigitSum(number);
}
