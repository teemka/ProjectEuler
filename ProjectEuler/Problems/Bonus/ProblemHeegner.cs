namespace ProjectEuler.Problems.Bonus;

/// <summary>
/// https://projecteuler.net/problem=heegner
/// </summary>
public class ProblemHeegner : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var min = int.MaxValue;
        var minDiff = double.MaxValue;
        for (int n = -100; n <= 1000; n++)
        {
            if (n >= 0 && double.IsInteger(Math.Sqrt(n)))
            {
                continue;
            }

            // cos ix = cosh x
            var value = n < 0
                ? Math.Cosh(Math.PI * Math.Sqrt(-n))
                : Math.Cos(Math.PI * Math.Sqrt(n));

            var diff = Math.Abs(value - Math.Round(value));

            if (diff < minDiff)
            {
                minDiff = diff;
                min = n;
            }
        }

        return Task.FromResult(min.ToString());
    }
}
