using ProjectEuler.Problems._001_100._61_70;

namespace ProjectEuler.Tests.Problems._001_100._61_70;

[InheritsTests]
public class Problem062Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem062();

    protected override string Answer => "127035954683";

    [Test]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "3" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        await Assert.That(result).IsEqualTo("41063625");
    }
}
