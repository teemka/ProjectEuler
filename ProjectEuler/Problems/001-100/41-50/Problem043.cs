using System.Runtime.InteropServices;

namespace ProjectEuler.Problems._001_100._41_50;

/// <summary>
/// The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.
///
/// Let d1 be the 1st digit, d2 be the 2nd digit, and so on.In this way, we note the following:
///
///     d2d3d4= 406 is divisible by 2
///     d3d4d5= 063 is divisible by 3
///     d4d5d6= 635 is divisible by 5
///     d5d6d7= 357 is divisible by 7
///     d6d7d8= 572 is divisible by 11
///     d7d8d9= 728 is divisible by 13
///     d8d9d10= 289 is divisible by 17
///
/// Find the sum of all 0 to 9 pandigital numbers with this property.
/// </summary>
public class Problem043 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var sum = "0123456789"
            .Select(x => (long)x.ToInt())
            .ToList()
            .GetPermutations()
            .Where(HasThisProperty)
            .Select(x => x.ToNumberFromDigits())
            .Sum();

        return Task.FromResult(sum.ToString());
    }

    private static bool HasThisProperty(IList<long> number)
    {
        return IsSubspanDivisible(number, 1, 2) &&
               IsSubspanDivisible(number, 2, 3) &&
               IsSubspanDivisible(number, 3, 5) &&
               IsSubspanDivisible(number, 4, 7) &&
               IsSubspanDivisible(number, 5, 11) &&
               IsSubspanDivisible(number, 6, 13) &&
               IsSubspanDivisible(number, 7, 17);

        static bool IsSubspanDivisible(IList<long> number, int startIndex, int modulo)
        {
            return number.ToNumberFromDigits(startIndex, length: 3) % modulo == 0;
        }
    }
}
