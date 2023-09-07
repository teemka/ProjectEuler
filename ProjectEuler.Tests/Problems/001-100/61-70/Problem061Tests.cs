using ProjectEuler.Problems._001_100._61_70;

namespace ProjectEuler.Tests.Problems._001_100._61_70;

public class Problem061Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem061();

    public override string Answer => "28684";

    [Fact]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "3" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        result.Should().Be("19291");
    }
}
