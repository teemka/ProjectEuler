using ProjectEuler.Problems._001_100._61_70;

namespace ProjectEuler.Tests.Problems._001_100._61_70;

public class Problem069Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem069();

    public override string Answer => "510510";

    [Fact]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "10" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        Assert.Equal("6", result);
    }
}
