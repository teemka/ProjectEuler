using ProjectEuler.Problems._001_100._81_90;

namespace ProjectEuler.Tests.Problems._001_100._81_90;

public class Problem085Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem085();

    protected override string Answer => "2772";

    [Fact]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "18" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        Assert.Equal("6", result);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(1, 2, 3)]
    [InlineData(1, 3, 6)]
    [InlineData(2, 2, 9)]
    [InlineData(1, 4, 10)]
    [InlineData(1, 5, 15)]
    [InlineData(3, 2, 18)]
    [InlineData(2, 4, 30)]
    [InlineData(3, 3, 36)]
    public void Should_GetSquares(int x, int y, int expected)
    {
        // Act
        var result = Problem085.GetSquares(x, y);

        // Assert
        Assert.Equal(expected, result);
    }
}
