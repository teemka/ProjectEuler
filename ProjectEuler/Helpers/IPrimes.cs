namespace ProjectEuler.Helpers;

/// <summary>
/// An interface to enumerate primes from the begginging
/// </summary>
/// <remarks>
/// It is limited to ints only because even at that limit it would be very slow to generate all primes.
/// </remarks>
public interface IPrimes : IEnumerable<int>
{
    bool IsPrime(int n);
}
