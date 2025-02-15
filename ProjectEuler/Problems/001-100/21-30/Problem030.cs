namespace ProjectEuler.Problems._001_100._21_30;

/// <summary>
/// https://projecteuler.net/problem=30
/// </summary>
public class Problem030 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var numbers = SumOfPowers(5).ToArray();
        return Task.FromResult(numbers.Sum().ToString());
    }

    private static IEnumerable<int> SumOfPowers(int length)
    {
        const int start = 2;
        var end = (int)Math.Pow(10, length + 1);
        var range = Enumerable.Range(start, end - start);
        foreach (var number in range)
        {
            var sum = 0;
            foreach (var digitChar in number.ToString())
            {
                var digit = int.Parse(digitChar.ToString());
                sum += (int)Math.Pow(digit, length);
            }

            if (sum == number)
            {
                yield return number;
            }
        }
    }
}
