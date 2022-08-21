using ProjectEuler.Problems._101_200._111_120;

namespace ProjectEuler.Tests;

public class Problem112Tests
{
    [Theory]
    [InlineData("0.9", "21780")]
    [InlineData("0.99", "1587000")]
    public async Task Should_CalculateAnswer(string target, string number)
    {
        var answer = await new Problem112().CalculateAsync(new[] { target.ToString() });
        answer.Should().Be(number);
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
