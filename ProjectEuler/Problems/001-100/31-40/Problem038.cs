using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._31_40
{
    /// <summary>
    /// https://projecteuler.net/problem=38
    /// Answer: 932718654
    /// </summary>
    public class Problem038 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            var pandigitals = "123456789".GetPermutations().Select(x => string.Concat(x)).ToArray();

            var output = new List<((long number, int n) input, string pandigital)>();
            foreach (var pandigital in pandigitals)
            {
                var pandigitalNumber = long.Parse(pandigital);
                for (int length = 1; length < 9; length++)
                {
                    var number = long.Parse(pandigital.Substring(0, length));
                    int n = 2;
                    while (true)
                    {
                        var multiple = CreateMultiple(number, n);
                        var s = multiple.ToString();
                        if (s == pandigital)
                            output.Add(((number, n), s));
                        else if (multiple > pandigitalNumber)
                            break;
                        n++;
                    }
                }
            }

            var result = output.OrderByDescending(x => x.pandigital).First();

            return Task.FromResult(result.pandigital);
        }

        public static long CreateMultiple(long number, int n)
        {
            var multiples = Enumerable.Range(1, n)
                .Select(x => number * x);
            var multiplesAsStrings = multiples.Select(x => x.ToString());
            return long.Parse(string.Concat(multiplesAsStrings));
        }
    }
}
