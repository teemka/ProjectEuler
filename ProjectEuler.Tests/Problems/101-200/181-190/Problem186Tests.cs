using ProjectEuler.Problems._101_200._181_190;

namespace ProjectEuler.Tests.Problems._101_200._181_190;

[InheritsTests]
public class Problem186Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem186();

    protected override string Answer => "2325629";

    [Test]
    [Arguments(1, 200007, 100053)]
    [Arguments(2, 600183, 500439)]
    [Arguments(3, 600863, 701497)]
    public async Task Should_GenerateExample(int recNr, int caller, int called)
    {
        var lfg = new Problem186.LaggedFibonacciGenerator();
        var numbers = lfg.Skip(2 * (recNr - 1)).Take(2).ToArray();

        await Assert.That(numbers.Length).IsEqualTo(2);
        await Assert.That(numbers[0]).IsEqualTo(caller);
        await Assert.That(numbers[1]).IsEqualTo(called);
    }
}
