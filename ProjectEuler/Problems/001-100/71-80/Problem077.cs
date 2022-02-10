namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// https://projecteuler.net/problem=77
/// </summary>
public class Problem077 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        // TODO: Adapt https://projecteuler.net/overview=031
        var coins = NumberHelper.Primes(1_000_000).ToArray();

        int Ways(int target, int avc)
        {
            if (avc <= 2)
            {
                return 1;
            }

            int res = 0;
            while (target >= 0)
            {
                res += Ways(target, avc - 1);
                target -= coins[avc];
            }

            return res;
        }

        var test = Ways(10, 3);

        var result = 11; // 10 is provided in example
        while (Ways(result, result / 2) < 5001)
        {
            result++;
        }

        return Task.FromResult(result.ToString());
    }
}
