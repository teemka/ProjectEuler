using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

public class Problem075Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem075();

    protected override string Answer => "161667";

    [Fact]
    public async Task Should_CalculateExample()
    {
        // Act
        var result = await new Problem075().CalculateAsync(["120"]);

        // Assert
        Assert.Equal("13", result);
    }
}
