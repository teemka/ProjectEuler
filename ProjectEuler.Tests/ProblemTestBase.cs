namespace ProjectEuler.Tests;

public abstract class ProblemTestBase
{
    protected abstract IProblem Problem { get; }

    protected abstract string Answer { get; }

    [Test]
    public async Task Should_Solve()
    {
        // Act
        var result = await this.Problem.CalculateAsync([]);

        // Assert
        await Assert.That(result).IsEqualTo(this.Answer);
    }
}
