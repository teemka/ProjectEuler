using ProjectEuler.Problems._001_100._11_20;

namespace ProjectEuler.Problems._001_100._61_70;

/// <summary>
/// https://projecteuler.net/problem=67
/// Answer: 7273
/// </summary>
public class Problem067 : IProblem
{
    public async Task<string> CalculateAsync(string[] args)
    {
        var triangle = await File.ReadAllTextAsync("Problems/001-100/61-70/p067_triangle.txt");
        return await new Problem018().CalculateAsync([triangle]);
    }
}
