using ProjectEuler.Problems._001_100._61_70;

namespace ProjectEuler.Tests.Problems._001_100._61_70;

public class Problem061Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem061();

    protected override string Answer => "28684";

    [Fact]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "3" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        Assert.Equal("19291", result);
    }
}
