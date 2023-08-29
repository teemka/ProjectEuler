namespace ProjectEuler.Tests;

public abstract class ProblemTestBase
{
    public abstract IProblem Problem { get; }

    public abstract string Answer { get; }

    [Fact]
    public async Task Should_Solve()
    {
        // Act
        var result = await this.Problem.CalculateAsync(Array.Empty<string>());

        // Assert
        result.Should().Be(this.Answer);
    }
}
