using ProjectEuler.Helpers;
using TUnit.Assertions.Enums;

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
        await Assert.That(divisors).IsEquivalentTo(expected, CollectionOrdering.Matching);
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

    [Test]
    [Arguments(2, new[] { 2 })]
    [Arguments(3, new[] { 3 })]
    [Arguments(4, new[] { 2 })]
    [Arguments(6, new[] { 2, 3 })]
    [Arguments(21, new[] { 3, 7 })]
    [Arguments(60, new[] { 2, 3, 5 })]
    [Arguments(72, new[] { 2, 3 })]
    [Arguments(429, new[] { 3, 11, 13 })]
    [Arguments(725, new[] { 5, 29 })]
    public async Task Should_GetPrimeFactors(int number, int[] expected)
    {
        // Act
        var divisors = NumberHelper.PrimeFactors(number).Order().ToArray();

        // Assert
        await Assert.That(divisors).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }
}
