using ProjectEuler.Problems._001_100._61_70;

namespace ProjectEuler.Tests.Problems._001_100._61_70;

public class Problem065Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem065();

    public override string Answer => "272";

    [Fact]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "10" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        Assert.Equal("17", result);
    }
}
