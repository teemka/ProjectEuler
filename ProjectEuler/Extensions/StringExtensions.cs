namespace ProjectEuler.Extensions;

public static class StringExtensions
{
    public static bool IsPalindrome(this string value)
    {
        return value.SequenceEqual(value.Reverse());
    }

    public static string Concat(this IEnumerable<char> chars)
    {
        return string.Concat(chars);
    }

    public static int ToInt(this char c) => c - '0';

    public static int ToAlphabeticalPositionUppercase(this char c) => c - 'A' + 1;
}
