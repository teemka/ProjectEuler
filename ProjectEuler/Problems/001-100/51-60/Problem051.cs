using System.Diagnostics;

namespace ProjectEuler.Problems._001_100._51_60;

public class Problem051 : IProblem
{
    private readonly HashSet<string> checkedWildcards = [];
    private readonly SieveOfErasthotenes sieve = new();

    public Task<string> CalculateAsync(string[] args)
    {
        var target = 8; // default
        if (args.Length == 1)
        {
            _ = int.TryParse(args[0], out target);
        }

        // How many non primes there can be in the wildcards replacements
        var noPrimesTolerance = 10 - target;

        foreach (var prime in this.sieve.Skip(4))
        {
            var wildcards = MakeWildcards(prime.ToString()).ToArray();

            foreach (var wildcard in wildcards)
            {
                if (!this.checkedWildcards.Add(wildcard))
                {
                    // Already checked
                    continue;
                }

                // Don't allow leading zeroes
                var start = wildcard[0] == '*'
                    ? '1'
                    : '0';

                var count = 0;
                string? smallestPrime = null;
                for (var digit = start; digit <= '9'; digit++)
                {
                    var replaced = wildcard.Replace('*', digit);
                    var candidate = int.Parse(replaced);

                    if (this.sieve.IsPrime(candidate))
                    {
                        count++;

                        smallestPrime ??= replaced;
                    }

                    // Break early if the tolarence is exceeded
                    if (digit.ToInt() - count > noPrimesTolerance)
                    {
                        break;
                    }

                    if (count == target)
                    {
                        return Task.FromResult(smallestPrime!);
                    }
                }
            }
        }

        throw new UnreachableException();
    }

    internal static IEnumerable<string> MakeWildcards(string s) => MakeWildcards(s, 0);

    private static IEnumerable<string> MakeWildcards(string s, int i)
    {
        for (var j = i; j < s.Length; j++)
        {
            var replaced = ReplaceDigit(s, j);
            yield return replaced;

            var wildcards = MakeWildcards(replaced, j + 1);

            foreach (var w in wildcards)
            {
                yield return w;
            }
        }
    }

    private static string ReplaceDigit(string s, int i) => s[..i] + "*" + s[(i + 1)..];
}
