using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems._001_100._71_80;

public class Problem078(ILogger<Problem078> logger) : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        const int million = 1_000_000;
        var n = 2;
        List<int> arr = [1];
        while (true)
        {
            if (n % 100 == 0)
            {
                logger.LogInformation("N: {N}", n);
            }

            var table = new long[n + 1];
            table[0] = 1;
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = arr[i]; j <= n; j++)
                {
                    checked
                    {
                        var a = arr[i];
                        var b = j - a;
                        var c = table[b];
                        table[j] %= million;
                        table[j] += c;
                    }
                }
            }

            var p = table[n] + 1;

            if (p % million == 0)
            {
                break;
            }

            arr.Add(arr[^1] + 1);
            n++;
        }

        return Task.FromResult(n.ToString());
    }
}
