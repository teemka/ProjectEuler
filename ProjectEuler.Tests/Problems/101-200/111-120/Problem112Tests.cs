using ProjectEuler.Problems._101_200._111_120;

namespace ProjectEuler.Tests.Problems._101_200._111_120;

[InheritsTests]
public class Problem112Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem112();

    protected override string Answer => "1587000";

    [Test]
    public async Task Should_CalculateExample()
    {
        var answer = await new Problem112().CalculateAsync(["0.9"]);

        await Assert.That(answer).IsEqualTo("21780");
    }

    [Test]
    [Arguments(12345, false)]
    [Arguments(134468, false)]
    [Arguments(54321, false)]
    [Arguments(66420, false)]
    [Arguments(155349, true)]
    [Arguments(21780, true)]
    public async Task Should_CheckIsBouncy(int number, bool expected)
    {
        var result = Problem112.IsBouncy(number);

        await Assert.That(result).IsEqualTo(expected);
    }
}
