namespace ProjectEuler.Problems._001_100._31_40;

/// <summary>
/// 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
///
/// Find the sum of all numbers which are equal to the sum of the factorial of their digits.
///
/// Note: as 1! = 1 and 2! = 2 are not sums they are not included.
/// </summary>
public class Problem034 : IProblem
{
    private static readonly Dictionary<int, int> Factorials = new() { { 0, 1 }, { 1, 1 }, { 2, 2 } };

    public Task<string> CalculateAsync(string[] args)
    {
        // 9! = 362880. Sum of factorials of digits of 9,999,999 is 7*9! = 2,540,160
        var result = Enumerable.Range(3, 2_540_160)
            .Select(x => (x, sumOfDigitFactorials: x.GetDigits().Sum(Factorial)))
            .Where(x => x.x == x.sumOfDigitFactorials)
            .Sum(x => x.x);

        return Task.FromResult(result.ToString());
    }

    private static int Factorial(int n)
    {
        if (Factorials.TryGetValue(n, out var value))
        {
            return value;
        }

        value = n * Factorial(n - 1);
        Factorials[n] = value;
        return value;
    }
}
