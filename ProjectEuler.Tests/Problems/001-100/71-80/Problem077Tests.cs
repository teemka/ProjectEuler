using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

public class Problem077Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem077();

    protected override string Answer => "71";

    [Fact]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "4" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        Assert.Equal("10", result);
    }
}
