using ProjectEuler.Extensions;

namespace ProjectEuler.Tests.Helpers;

public class NumberExtensionsTests
{
    [Test]
    [Arguments(123)]
    [Arguments(12345)]
    [Arguments(987654321)]
    public async Task Should_BePandigital(int number)
    {
        await Assert.That(number.IsPandigital()).IsTrue();
    }

    [Test]
    [Arguments(123321)]
    [Arguments(9999999999)]
    [Arguments(100000000001)]
    public async Task Should_BePalindrome(long number)
    {
        await Assert.That(number.IsPalindrome()).IsTrue();
    }

    [Test]
    [Arguments(123456789)]
    [Arguments(9999999998)]
    [Arguments(9999998999)]
    [Arguments(100000000000)]
    public async Task Should_NotBePalindrome(long number)
    {
        await Assert.That(number.IsPalindrome()).IsFalse();
    }
}
