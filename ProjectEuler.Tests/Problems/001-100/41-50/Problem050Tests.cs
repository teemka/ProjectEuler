using ProjectEuler.Problems._001_100._41_50;

namespace ProjectEuler.Tests.Problems._001_100._41_50;

public class Problem050Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem050();

    protected override string Answer => "997651";

    [Theory]
    [InlineData(100, 41)]
    [InlineData(1000, 953)]
    public void Should_SolveExample(int limit, int expected)
    {
        // Act
        var result = Problem050.MaxSum(limit);

        // Assert
        Assert.Equal(expected, result);
    }
}
