using ProjectEuler.Problems._101_200._181_190;

namespace ProjectEuler.Tests;

public class Problem186Tests
{
    [Theory]
    [InlineData(1, 200007, 100053)]
    [InlineData(2, 600183, 500439)]
    [InlineData(3, 600863, 701497)]
    public void Should_GenerateExample(int recNr, int caller, int called)
    {
        Problem186.GetCallerNo(recNr).Should().Be(caller);
        Problem186.GetCalledNo(recNr).Should().Be(called);
    }

    [Fact]
    public async Task Should_CalculateAnswer()
    {
        var answer = await new Problem186().CalculateAsync(Array.Empty<string>());
        answer.Should().Be("2325629");
    }
}
