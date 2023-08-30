namespace ProjectEuler.Helpers;

public interface IPrimes : IEnumerable<long>
{
    bool IsPrime(long n);
}
