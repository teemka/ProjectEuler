namespace ProjectEuler.Problems._001_100._1_10;

/// <summary>
/// The sum of the squares of the first ten natural numbers is,
///     1^2 + 2^2 + ... + 10^2 = 385
/// The square of the sum of the first ten natural numbers is,
///     (1 + 2 + ... + 10)^2 = 55^2 = 3025
/// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
/// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
/// </summary>
public class Problem006 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var arithmeticSeries = ArithmeticSeries(1, 1, 100);
        var arithmeticSeriesSquared = (int)Math.Pow(arithmeticSeries, 2);
        var sumOfSquares = SumOfSquares(100);
        var difference = arithmeticSeriesSquared - sumOfSquares;
        return Task.FromResult(difference.ToString());
    }

    private static int ArithmeticSeries(int start, int commonDifference, int count)
    {
        var end = start + ((count - 1) * commonDifference);
        return count * (start + end) / 2;
    }

    private static int SumOfSquares(int n)
    {
        return n * (n + 1) * ((2 * n) + 1) / 6;
    }
}
