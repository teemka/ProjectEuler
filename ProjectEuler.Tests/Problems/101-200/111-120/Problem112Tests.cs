using ProjectEuler.Problems._101_200._111_120;

namespace ProjectEuler.Tests.Problems._101_200._111_120;

public class Problem112Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem112();

    public override string Answer => "1587000";

    [Fact]
    public async Task Should_CalculateExample()
    {
        var answer = await new Problem112().CalculateAsync(["0.9"]);

        Assert.Equal("21780", answer);
    }

    [Theory]
    [InlineData(12345, false)]
    [InlineData(134468, false)]
    [InlineData(54321, false)]
    [InlineData(66420, false)]
    [InlineData(155349, true)]
    [InlineData(21780, true)]
    public void Should_CheckIsBouncy(int number, bool expected)
    {
        var result = Problem112.IsBouncy(number);

        Assert.Equal(expected, result);
    }
}
