using ProjectEuler.Problems._001_100._51_60;

namespace ProjectEuler.Tests.Problems._001_100._51_60;

public class Problem051Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem051();

    public override string Answer => "121313";

    [Theory]
    [InlineData("6", "13")]
    [InlineData("7", "56003")]
    public async Task Should_SolveExamples(string target, string expected)
    {
        // Arrange
        var args = new[] { target };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Should_GenerateWildcards_2Digits()
    {
        // Arrange
        var prime = "13";
        var expected = new[] { "*3", "1*", "**" };

        // Act
        var wildcards = Problem051.MakeWildcards(prime);

        // Assert
        wildcards.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Should_GenerateWildcards_3Digits()
    {
        // Arrange
        var prime = "123";
        var expected = new[] { "*23", "**3", "1*3", "*2*", "1**", "12*", "***" };

        // Act
        var wildcards = Problem051.MakeWildcards(prime);

        // Assert
        wildcards.Should().BeEquivalentTo(expected);
    }
}
