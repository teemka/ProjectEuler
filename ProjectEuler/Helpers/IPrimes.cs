namespace ProjectEuler.Helpers;

/// <summary>
/// An interface to enumerate primes from the begginging
/// </summary>
/// <remarks>
/// It is limited to ints only because even at that limit it would be very slow to generate all primes.
/// </remarks>
public interface IPrimes : IEnumerable<int>
{
    /// <summary>
    /// Determines whether the specified number is a prime number.
    /// </summary>
    /// <param name="n">The number to check. Must be a non-negative integer.</param>
    /// <returns><see langword="true"/> if the specified number is a prime number; otherwise, <see langword="false"/>.</returns>
    bool IsPrime(int n);
}
