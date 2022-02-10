using System.Numerics;

namespace ProjectEuler.Problems._601_700._681_690;

/// <summary>
/// Powers of Two
/// https://projecteuler.net/problem=686
/// </summary>
public class Problem686 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (args.Length != 2)
        {
            args = new[] { "123", "678910" };
        }

        var l = int.Parse(args[0]);
        var n = int.Parse(args[1]);

        int i = 1;
        BigInteger current = 1;
        int currentN = 0;
        while (true)
        {
            current *= 2;
            if (current.ToString().StartsWith(l.ToString()))
            {
                currentN++;
                if (currentN == n)
                {
                    break;
                }
            }

            i++;
        }

        return Task.FromResult(i.ToString());
    }
}
