namespace ProjectEuler.Problems._001_100._91_100;

/// <summary>
/// https://projecteuler.net/problem=99
/// Answer: 709
/// </summary>
public class Problem099 : IProblem
{
    public async Task<string> CalculateAsync(string[] args)
    {
        var lines = await File.ReadAllLinesAsync("Problems/001-100/91-100/p099_base_exp.txt");

        var max = lines
            .Select(line =>
            {
                var split = line.Split(",");
                var b = int.Parse(split[0]);
                var e = int.Parse(split[1]);
                return (b, e);
            })
            .OrderByDescending(x => x, new LogExponentComparer())
            .First();

        var index = lines.ToList().IndexOf($"{max.b},{max.e}");
        return (index + 1).ToString();
    }

    /// <summary>
    /// https://www.quora.com/How-do-we-compare-numbers-with-big-exponents-and-different-bases-for-example-how-do-we-compare-3-210-and-17-140
    /// </summary>
    private class LogExponentComparer : IComparer<(int Base, int Exponent)>
    {
        public int Compare((int Base, int Exponent) x, (int Base, int Exponent) y)
        {
            var xApprox = x.Exponent * Math.Log10(x.Base);
            var yApprox = y.Exponent * Math.Log10(y.Base);

            return xApprox.CompareTo(yApprox);
        }
    }
}
