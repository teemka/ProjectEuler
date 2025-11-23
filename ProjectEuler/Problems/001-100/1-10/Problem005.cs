namespace ProjectEuler.Problems._001_100._1_10;

/// <summary>
/// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
/// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
/// </summary>
public class Problem005 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        // Greatest powers of primes below 20
        var multiplicands = new[]
        {
            16, // 2 ^ 4
            9, // 3 ^ 2
            5,
            7,
            11,
            13,
            17,
            19,
        };

        var multiple = multiplicands.Aggregate((a, b) => a * b);

        return Task.FromResult(multiple.ToString());
    }

    internal static bool IsEvenlyDivisible(long value, int[] divisors)
    {
        return divisors.All(divisor => value % divisor == 0);
    }
}
