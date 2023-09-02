namespace ProjectEuler.Extensions;

public static class StringExtensions
{
    public static bool IsPalindrome(this string value)
    {
        return value.SequenceEqual(value.Reverse());
    }
}
