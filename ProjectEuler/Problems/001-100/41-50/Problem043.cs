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
            .GetPermutations()
            .Select(x => string.Concat(x))
            .Where(HasThisProperty)
            .Select(long.Parse)
            .Sum();

        return Task.FromResult(sum.ToString());
    }

    private static bool HasThisProperty(string number)
    {
        return IsSubspanDivisible(number, 1, 4, 2) &&
               IsSubspanDivisible(number, 2, 5, 3) &&
               IsSubspanDivisible(number, 3, 6, 5) &&
               IsSubspanDivisible(number, 4, 7, 7) &&
               IsSubspanDivisible(number, 5, 8, 11) &&
               IsSubspanDivisible(number, 6, 9, 13) &&
               IsSubspanDivisible(number, 7, 10, 17);

        static bool IsSubspanDivisible(ReadOnlySpan<char> number, Index start, Index end, int modulo)
        {
            var d1 = number[start..end];
            return int.Parse(d1) % modulo == 0;
        }
    }
}
