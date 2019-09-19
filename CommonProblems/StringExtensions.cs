using System.Linq;

namespace CommonProblems
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string value)
        {
            return value.SequenceEqual(value.Reverse());
        }
    }
}