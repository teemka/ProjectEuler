using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._101_200._101_110;

/// <summary>
/// https://projecteuler.net/problem=112
/// Answer: 1587000
/// </summary>
public class Problem112 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var bouncyCount = 0;
        var i = 1;
        while (true)
        {
            var result = IsBouncy(i);
            if (result)
            {
                bouncyCount++;
            }

            var percentage = bouncyCount / (double)i;

            if (percentage >= 0.99)
            {
                break;
            }

            i++;
        }

        return Task.FromResult(i.ToString());
    }

    private static bool IsBouncy(int number)
    {
        var n = number.ToString(CultureInfo.InvariantCulture);

        var isInc = string.Join(string.Empty, n.OrderBy(x => x)) == n;
        var isDec = string.Join(string.Empty, n.OrderByDescending(x => x)) == n;

        var result = !isInc && !isDec;
        return result;
    }
}
