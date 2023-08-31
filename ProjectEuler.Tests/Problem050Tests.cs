using ProjectEuler.Problems._001_100._41_50;

namespace ProjectEuler.Tests;

public class Problem050Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem050();

    public override string Answer => "997651";

    [Theory]
    [InlineData(100, 41)]
    [InlineData(1000, 953)]
    public void Should_SolveExample(int limit, int expected)
    {
        // Act
        var result = Problem050.MaxSum(limit);

        // Assert
        result.Should().Be(expected);
    }
}
