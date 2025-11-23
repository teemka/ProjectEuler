using ProjectEuler.Problems._001_100._41_50;

namespace ProjectEuler.Tests.Problems._001_100._41_50;

[InheritsTests]
public class Problem050Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem050();

    protected override string Answer => "997651";

    [Test]
    [Arguments(100, 41)]
    [Arguments(1000, 953)]
    public async Task Should_SolveExample(int limit, int expected)
    {
        // Act
        var result = Problem050.MaxSum(limit);

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }
}
