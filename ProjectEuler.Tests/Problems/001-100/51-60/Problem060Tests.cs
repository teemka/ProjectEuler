using ProjectEuler.Problems._001_100._51_60;

namespace ProjectEuler.Tests.Problems._001_100._51_60;

public class Problem060Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem060();

    public override string Answer => "26033";

    [Fact]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "4" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        Assert.Equal("792", result);
    }
}
