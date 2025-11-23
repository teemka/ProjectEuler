namespace ProjectEuler.Problems._001_100._81_90;

/// <summary>
/// https://projecteuler.net/problem=89
/// </summary>
internal class Problem089 : IProblem
{
    public async Task<string> CalculateAsync(string[] args)
    {
        var romans = await File.ReadAllLinesAsync("Problems/001-100/81-90/p089_roman.txt");

        var count = 0;
        foreach (var roman in romans)
        {
            var newRoman = Simplify(roman);

            count += roman.Length - newRoman.Length;
        }

        return count.ToString();
    }

    public static string Simplify(string roman) => roman
        .Replace("IIII", "IV")
        .Replace("VIV", "IX")
        .Replace("XXXX", "XL")
        .Replace("LXL", "XC")
        .Replace("CCCC", "CD")
        .Replace("DCD", "CM");
}
