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
        Assert.Equal(78498, primes.Length);
        Assert.Equal(2, primes[0]);
        Assert.Equal(999983, primes[78497]);

        Assert.True(sieve.IsPrime(2));
        Assert.True(sieve.IsPrime(3));
        Assert.False(sieve.IsPrime(4));
        Assert.True(sieve.IsPrime(5));
        Assert.False(sieve.IsPrime(6));
        Assert.True(sieve.IsPrime(7));
        Assert.True(sieve.IsPrime(999983));
    }

    [Fact]
    public void Should_Grow()
    {
        // Arrange
        var sieve = new SieveOfErasthotenes(1_000_000);

        // Act
        var primes = sieve.Take(148933).ToArray();

        // Assert
        Assert.Equal(148933, primes.Length);
        Assert.Equal(1000003, primes[78498]);
        Assert.Equal(1999993, primes[148932]);
    }
}
