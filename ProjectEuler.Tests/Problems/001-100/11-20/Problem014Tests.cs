using ProjectEuler.Problems._001_100._11_20;

namespace ProjectEuler.Tests.Problems._001_100._11_20;

public class Problem014Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem014();

    public override string Answer => "837799";

    [Theory]
    [InlineData(13, 10)]
    [InlineData(837799, 525)]
    public void Should_SolveExample(int start, int expected)
    {
        // Act
        var result = new Problem014().CollatzCount(start);

        // Assert
        Assert.Equal(expected, result);
    }
}
