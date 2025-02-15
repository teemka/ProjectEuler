namespace ProjectEuler.Tests;

public abstract class ProblemTestBase
{
    protected abstract IProblem Problem { get; }

    protected abstract string Answer { get; }

    [Fact]
    public async Task Should_Solve()
    {
        // Act
        var result = await this.Problem.CalculateAsync([]);

        // Assert
        Assert.Equal(this.Answer, result);
    }
}
