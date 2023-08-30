using System.Collections;

namespace ProjectEuler.Helpers;

internal class DefaultPrimes : IPrimes
{
    public IEnumerator<long> GetEnumerator() => NumberHelper.Primes().GetEnumerator();

    public bool IsPrime(long n) => NumberHelper.IsPrime(n);

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
