using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

[InheritsTests]
public class Problem074Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem074();

    protected override string Answer => "402";

    [Test]
    [Arguments(69, 5)]
    [Arguments(78, 4)]
    [Arguments(540, 2)]
    public async Task Should_CalculateExampleLength(int input, int expected)
    {
        // Act
        var result = new Problem074().ChainLength(input);

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments(0, 1)]
    [Arguments(145, 145)]
    [Arguments(169, 363601)]
    [Arguments(363601, 1454)]
    [Arguments(1454, 169)]
    public async Task Should_CalculateDigitFactorial(int input, int expected)
    {
        var result = Problem074.DigitFactorial(input);

        await Assert.That(result).IsEqualTo(expected);
    }
}
