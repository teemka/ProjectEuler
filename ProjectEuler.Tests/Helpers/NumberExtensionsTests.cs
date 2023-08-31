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
        number.IsPandigital().Should().BeTrue();
    }
}
