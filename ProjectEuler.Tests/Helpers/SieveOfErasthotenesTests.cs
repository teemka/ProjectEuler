using ProjectEuler.Helpers;

namespace ProjectEuler.Tests.Helpers;

public class SieveOfErasthotenesTests
{
    [Test]
    public async Task Should_CalculatePrimes()
    {
        // Arrange
        var sieve = new SieveOfErasthotenes(1_000_000);

        // Act
        var primes = sieve.Take(78498).ToArray();

        // Assert
        await Assert.That(primes.Length).IsEqualTo(78498);
        await Assert.That(primes[0]).IsEqualTo(2);
        await Assert.That(primes[78497]).IsEqualTo(999983);

        await Assert.That(sieve.IsPrime(2)).IsTrue();
        await Assert.That(sieve.IsPrime(3)).IsTrue();
        await Assert.That(sieve.IsPrime(4)).IsFalse();
        await Assert.That(sieve.IsPrime(5)).IsTrue();
        await Assert.That(sieve.IsPrime(6)).IsFalse();
        await Assert.That(sieve.IsPrime(7)).IsTrue();
        await Assert.That(sieve.IsPrime(999983)).IsTrue();
    }

    [Test]
    public async Task Should_Grow()
    {
        // Arrange
        var sieve = new SieveOfErasthotenes(1_000_000);

        // Act
        var primes = sieve.Take(148933).ToArray();

        // Assert
        await Assert.That(primes.Length).IsEqualTo(148933);
        await Assert.That(primes[78498]).IsEqualTo(1000003);
        await Assert.That(primes[148932]).IsEqualTo(1999993);
    }
}
