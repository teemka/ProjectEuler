using ProjectEuler.Helpers;

namespace ProjectEuler.Tests.Helpers;

public class NumberHelperTests
{
    [Theory]
    [InlineData(220, new[] { 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110 })]
    [InlineData(284, new[] { 1, 2, 4, 71, 142 })]
    public void Should_GetProperDivisors(int number, int[] expected)
    {
        // Act
        var divisors = NumberHelper.ProperDivisors(number).Order().ToArray();

        // Assert
        Assert.Equal(expected, divisors);
    }
}
