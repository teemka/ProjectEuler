using System.Text;

namespace ProjectEuler.Problems._001_100._31_40;

/// <summary>
/// https://projecteuler.net/problem=38
/// Answer: 932718654
/// </summary>
public class Problem038 : IProblem
{
    private readonly StringBuilder sb = new();

    public Task<string> CalculateAsync(string[] args)
    {
        var pandigitals = "123456789".Select(x => (long)x.ToInt()).ToList().GetPermutations();

        var output = new List<long>();
        foreach (var pandigital in pandigitals)
        {
            var pandigitalNumber = pandigital.ToNumberFromDigits();
            for (var length = 1; length < 9; length++)
            {
                var number = pandigital.ToNumberFromDigits(0, length);
                var n = 2;
                while (true)
                {
                    var multiple = this.CreateMultiple(number, n);
                    if (multiple == pandigitalNumber)
                    {
                        output.Add(pandigitalNumber);
                    }
                    else if (multiple > pandigitalNumber)
                    {
                        break;
                    }

                    n++;
                }
            }
        }

        var maxPandigital = output.Max();

        return Task.FromResult(maxPandigital.ToString());
    }

    public long CreateMultiple(long number, int n)
    {
        this.sb.Clear();
        for (var i = 1; i <= n; i++)
        {
            this.sb.Append(number * i);
        }

        return long.Parse(this.sb.ToString());
    }
}
