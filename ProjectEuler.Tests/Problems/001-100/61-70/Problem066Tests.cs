using ProjectEuler.Problems._001_100._61_70;

namespace ProjectEuler.Tests.Problems._001_100._61_70;

public class Problem066Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem066();

    public override string Answer => "661";

    [Fact]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "7" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        result.Should().Be("5");
    }

    [Theory]
    [InlineData(2, 3, 2)]
    [InlineData(3, 2, 1)]
    [InlineData(5, 9, 4)]
    [InlineData(6, 5, 2)]
    [InlineData(7, 8, 3)]
    public void Should_SolveExampleEquations(int d, int x, int y)
    {
        // Act
        var result = Problem066.IsEquationSolved(d, x, y);

        // Assert
        result.Should().BeTrue();
    }
}
