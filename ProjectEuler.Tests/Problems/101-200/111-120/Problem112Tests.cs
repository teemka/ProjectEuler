using ProjectEuler.Problems._101_200._111_120;

namespace ProjectEuler.Tests.Problems._101_200._111_120;

public class Problem112Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem112();

    public override string Answer => "1587000";

    [Fact]
    public async Task Should_CalculateExample()
    {
        var answer = await new Problem112().CalculateAsync(new[] { "0.9" });
        answer.Should().Be("21780");
    }

    [Theory]
    [InlineData(12345, false, "is increasing")]
    [InlineData(134468, false, "is increasing")]
    [InlineData(54321, false, "is decreasing")]
    [InlineData(66420, false, "is decreasing")]
    [InlineData(155349, true, "is bouncy")]
    [InlineData(21780, true, "is bouncy")]
    public void Should_CheckIsBouncy(int number, bool expectedResult, string because)
    {
        Problem112.IsBouncy(number).Should().Be(expectedResult, because);
    }
}
