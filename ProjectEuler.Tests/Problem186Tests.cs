using ProjectEuler.Problems._101_200._181_190;

namespace ProjectEuler.Tests;

public class Problem186Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem186();

    public override string Answer => "2325629";

    [Theory]
    [InlineData(1, 200007, 100053)]
    [InlineData(2, 600183, 500439)]
    [InlineData(3, 600863, 701497)]
    public void Should_GenerateExample(int recNr, int caller, int called)
    {
        var lfg = new Problem186.LaggedFibonacciGenerator();
        var numbers = lfg.Skip(2 * (recNr - 1)).Take(2).ToArray();

        numbers.Should().HaveCount(2);
        numbers[0].Should().Be(caller);
        numbers[1].Should().Be(called);
    }
}
