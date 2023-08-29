using ProjectEuler.Helpers;

namespace ProjectEuler.Tests.Helpers;

public class NumberHelperTests
{
    [Fact]
    public void Should_CalculatePrimes()
    {
        // Act
        var primes = NumberHelper.Primes(1_000_000).ToArray();

        // Assert
        primes.Should().HaveCount(78498);
        primes.Should().HaveElementAt(0, 2);
        primes.Should().HaveElementAt(78497, 999983);
    }
}
