using System.Linq;

namespace ProjectEuler
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string value)
        {
            return value.SequenceEqual(value.Reverse());
        }

        public static int ToInt(this char c) => c - '0';

        public static int ToAlphabeticalPositionUppercase(this char c) => c - 'A' + 1;
    }
}