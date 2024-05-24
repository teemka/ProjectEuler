using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

public class Problem072Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem072();

    public override string Answer => "303963552391";

    [Theory]
    [InlineData("8", "21")] // example
    [InlineData("9", "27")]
    public async Task Should_Calculate(string arg, string expected)
    {
        var result = await this.Problem.CalculateAsync([arg]);

        result.Should().Be(expected);
    }
}
