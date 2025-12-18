using ProjectEuler.Problems._001_100._51_60;

namespace ProjectEuler.Tests.Problems._001_100._51_60;

[InheritsTests]
public class Problem051Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem051();

    protected override string Answer => "121313";

    [Test]
    [Arguments("6", "13")]
    [Arguments("7", "56003")]
    public async Task Should_SolveExamples(string target, string expected)
    {
        // Arrange
        var args = new[] { target };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task Should_GenerateWildcards_2Digits()
    {
        // Arrange
        const string prime = "13";
        HashSet<string> expected = ["*3", "1*", "**"];

        // Act
        var wildcards = Problem051.MakeWildcards(prime).ToHashSet();

        // Assert
        await Assert.That(wildcards).IsEquivalentTo(expected);
    }

    [Test]
    public async Task Should_GenerateWildcards_3Digits()
    {
        // Arrange
        const string prime = "123";
        HashSet<string> expected = ["*23", "**3", "1*3", "*2*", "1**", "12*", "***"];

        // Act
        var wildcards = Problem051.MakeWildcards(prime).ToHashSet();

        // Assert
        await Assert.That(wildcards).IsEquivalentTo(expected);
    }
}
