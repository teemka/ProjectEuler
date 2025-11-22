using ProjectEuler.Problems._701_800._711_720;

namespace ProjectEuler.Tests.Problems._701_800._721_730;

[InheritsTests]
public class Problem719Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem719();

    protected override string Answer => "128088830547982";

    [Test]
    [Arguments(81)]
    [Arguments(6724)]
    [Arguments(8281)]
    [Arguments(9801)]
    public async Task Should_Split_ReturnTrue(long number)
    {
        // Arrange
        var sqrt = (long)Math.Sqrt(number);

        // Act
        var result = Problem719.TrySplit(sqrt, number);

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    [Arguments(64)]
    public async Task Should_Split_ReturnFalse(long number)
    {
        // Arrange
        var sqrt = (long)Math.Sqrt(number);

        // Act
        var result = Problem719.TrySplit(sqrt, number);

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "10000" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        await Assert.That(result).IsEqualTo("41333");
    }
}
