namespace ProjectEuler.Problems._001_100._21_30;

/// <summary>
/// Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
/// If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
///
/// For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
///
/// Evaluate the sum of all the amicable numbers under 10000.
/// </summary>
public class Problem021 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var amicableNumbers = Enumerable.Range(1, 10000).Where(x => IsAmicable(x)).ToArray();
        return Task.FromResult(amicableNumbers.Sum().ToString());
    }

    private static bool IsAmicable(long n)
    {
        var sumOfProperDivisors = n.ProperDivisors().Sum();
        if (sumOfProperDivisors == n)
        {
            return false;
        }

        var sum = sumOfProperDivisors.ProperDivisors().Sum();
        return n == sum;
    }
}
