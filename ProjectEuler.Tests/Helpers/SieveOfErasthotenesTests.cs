using ProjectEuler.Helpers;

namespace ProjectEuler.Tests.Helpers;

public class SieveOfErasthotenesTests
{
    [Fact]
    public void Should_CalculatePrimes()
    {
        // Arrange
        var sieve = new SieveOfErasthotenes(1_000_000);

        // Act
        var primes = sieve.Take(78498).ToArray();

        // Assert
        primes.Should().HaveCount(78498);
        primes.Should().HaveElementAt(0, 2);
        primes.Should().HaveElementAt(78497, 999983);

        sieve.IsPrime(2).Should().BeTrue();
        sieve.IsPrime(3).Should().BeTrue();
        sieve.IsPrime(4).Should().BeFalse();
        sieve.IsPrime(5).Should().BeTrue();
        sieve.IsPrime(6).Should().BeFalse();
        sieve.IsPrime(7).Should().BeTrue();
        sieve.IsPrime(999983).Should().BeTrue();
    }

    [Fact]
    public void Should_Grow()
    {
        // Arrange
        var sieve = new SieveOfErasthotenes(1_000_000);

        // Act
        var primes = sieve.Take(148933).ToArray();

        // Assert
        primes.Should().HaveCount(148933);
        primes.Should().HaveElementAt(78498, 1000003);
        primes.Should().HaveElementAt(148932, 1999993);
    }
}
