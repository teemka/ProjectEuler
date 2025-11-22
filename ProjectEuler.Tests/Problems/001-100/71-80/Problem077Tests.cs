using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

[InheritsTests]
public class Problem077Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem077();

    protected override string Answer => "71";

    [Test]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "4" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        await Assert.That(result).IsEqualTo("10");
    }
}
