using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

[InheritsTests]
public class Problem072Tests : ProblemTestBase
{
    private static readonly int[] A000010 = [1, 1, 2, 2, 4, 2, 6, 4, 6, 4];
    private static readonly int[] A005728 = [0, 1, 2, 4, 6, 10, 12, 18, 22, 28];

    protected override IProblem Problem => new Problem072();

    protected override string Answer => "303963552391";

    [Test]
    [Arguments("8", "21")] // example
    [Arguments("9", "27")]
    public async Task Should_Calculate(string arg, string expected)
    {
        var result = await this.Problem.CalculateAsync([arg]);

        await Assert.That(result).IsEqualTo(expected);
    }

    public static IEnumerable<(int, int)> Eulers() => A000010.Select((x, i) => (i + 1, x));

    [Test]
    [MethodDataSource(nameof(Eulers))]
    public async Task Should_CalculateEuler(int n, int expected)
    {
        var result = Problem072.EulersTotient(n);

        await Assert.That(result).IsEqualTo(expected);
    }

    public static IEnumerable<(int, int)> Phis() => A005728.Select((x, i) => (i, x));

    [Test]
    [MethodDataSource(nameof(Phis))]
    public async Task Should_CalculatePhi(int n, int expected)
    {
        var result = Problem072.Phi(n);

        await Assert.That(result).IsEqualTo(expected);
    }
}
