namespace ProjectEuler.Problems._001_100._1_10;

/// <summary>
/// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
///
/// Find the sum of all the multiples of 3 or 5 below 1000.
///
/// Answer: 233168
/// </summary>
public class Problem001 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        int sum = Enumerable.Range(1, 999).Where(x => x % 3 == 0 || x % 5 == 0).Sum();
        return Task.FromResult(sum.ToString());
    }
}
