using ProjectEuler.Extensions;

namespace ProjectEuler.Tests.Helpers;

public class NumberExtensionsTests
{
    [Theory]
    [InlineData(123)]
    [InlineData(12345)]
    [InlineData(987654321)]
    public void Should_BePandigital(int number)
    {
        Assert.True(number.IsPandigital());
    }

    [Theory]
    [InlineData(123321)]
    [InlineData(9999999999)]
    [InlineData(100000000001)]
    public void Should_BePalindrome(long number)
    {
        Assert.True(number.IsPalindrome());
    }

    [Theory]
    [InlineData(123456789)]
    [InlineData(9999999998)]
    [InlineData(9999998999)]
    [InlineData(100000000000)]
    public void Should_NotBePalindrome(long number)
    {
        Assert.False(number.IsPalindrome());
    }
}
