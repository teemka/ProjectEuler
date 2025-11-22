using ProjectEuler.Problems._001_100._61_70;

namespace ProjectEuler.Tests.Problems._001_100._61_70;

[InheritsTests]
public class Problem066Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem066();

    protected override string Answer => "661";

    [Test]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "7" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        await Assert.That(result).IsEqualTo("5");
    }

    [Test]
    [Arguments(2, 3, 2)]
    [Arguments(3, 2, 1)]
    [Arguments(5, 9, 4)]
    [Arguments(6, 5, 2)]
    [Arguments(7, 8, 3)]
    public async Task Should_SolveExampleEquations(int d, int x, int y)
    {
        // Act
        var result = Problem066.IsEquationSolved(d, x, y);

        // Assert
        await Assert.That(result).IsTrue();
    }
}
