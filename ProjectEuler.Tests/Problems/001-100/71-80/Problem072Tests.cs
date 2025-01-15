using ProjectEuler.Problems._001_100._71_80;
using ProjectEuler.Tests.Helpers;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

public class Problem072Tests : ProblemTestBase
{
    private static readonly int[] A000010 = [1, 1, 2, 2, 4, 2, 6, 4, 6, 4];
    private static readonly int[] A005728 = [0, 1, 2, 4, 6, 10, 12, 18, 22, 28];

    public override IProblem Problem => new Problem072();

    public override string Answer => "303963552391";

    [Theory]
    [InlineData("8", "21")] // example
    [InlineData("9", "27")]
    public async Task Should_Calculate(string arg, string expected)
    {
        var result = await this.Problem.CalculateAsync([arg]);

        Assert.Equal(expected, result);
    }

    public static readonly TheoryData<int, int> Eulers = A000010.Select((x, i) => (i + 1, x)).ToTheoryData();

    [Theory]
    [MemberData(nameof(Eulers))]
    public void Should_CalculateEuler(int n, int expected)
    {
        var result = Problem072.EulersTotient(n);

        Assert.Equal(expected, result);
    }

    public static readonly TheoryData<int, int> Phis = A005728.Select((x, i) => (i, x)).ToTheoryData();

    [Theory]
    [MemberData(nameof(Phis))]
    public void Should_CalculatePhi(int n, int expected)
    {
        var result = Problem072.Phi(n);

        Assert.Equal(expected, result);
    }
}
