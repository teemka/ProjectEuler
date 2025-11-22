using ProjectEuler.Helpers;

namespace ProjectEuler.Tests.Helpers;

public class NumberHelperTests
{
    [Test]
    [Arguments(220, new[] { 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110 })]
    [Arguments(284, new[] { 1, 2, 4, 71, 142 })]
    public async Task Should_GetProperDivisors(int number, int[] expected)
    {
        // Act
        var divisors = NumberHelper.ProperDivisors(number).Order().ToArray();

        // Assert
        await Assert.That(divisors).IsEquivalentTo(expected);
    }

    [Test]
    [Arguments(5, 6)]
    [Arguments(100, 190569291)]
    public async Task Should_GetAllPossibleSummationsOf(int number, int expected)
    {
        // Act
        var result = NumberHelper.AllPossibleSummationsOf(number);

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }
}
