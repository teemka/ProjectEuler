using ProjectEuler.Problems._001_100._81_90;

namespace ProjectEuler.Tests.Problems._001_100._81_90;

[InheritsTests]
public class Problem085Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem085();

    protected override string Answer => "2772";

    [Test]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "18" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        await Assert.That(result).IsEqualTo("6");
    }

    [Test]
    [Arguments(1, 1, 1)]
    [Arguments(1, 2, 3)]
    [Arguments(1, 3, 6)]
    [Arguments(2, 2, 9)]
    [Arguments(1, 4, 10)]
    [Arguments(1, 5, 15)]
    [Arguments(3, 2, 18)]
    [Arguments(2, 4, 30)]
    [Arguments(3, 3, 36)]
    public async Task Should_GetSquares(int x, int y, int expected)
    {
        // Act
        var result = Problem085.GetSquares(x, y);

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }
}
