namespace ProjectEuler.Tests.Problems._001_100._91_100;

public class Problem093Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem093();

    protected override string Answer => "1258";

    [Fact]
    public void Should_SolveExample()
    {
        // Act
        var result = Problem093.GetResults([1, 2, 3, 4]);

        // Assert
        Assert.Equal(28, result);
    }

    [Fact]
    public void Should_SolveExample_Expression()
    {
        // Act
        var result = Problem093.GetExpression([4, 1, 3, 2], [Problem093.Multiplication, Problem093.Addition, Problem093.Division], [2, 1, 3]);

        // Assert
        Assert.Equal("((4*(1+3))/2)", result.ToString());
    }
}
