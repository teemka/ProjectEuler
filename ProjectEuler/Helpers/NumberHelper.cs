using System.Numerics;

namespace ProjectEuler.Helpers;

public static class NumberHelper
{
    public static IEnumerable<T> Divisors<T>(T number)
        where T : INumber<T>
    {
        var sqrt = number.SqrtViaDouble();
        var beginning = new List<T>();
        var end = new List<T>();

        for (var i = T.One; i <= sqrt; i++)
        {
            if (number % i == T.Zero)
            {
                beginning.Add(i);
                end.Add(number / i);
            }
        }

        end.Reverse();
        return beginning.Concat(end).Distinct();
    }

    public static IEnumerable<T> ProperDivisors<T>(T number)
        where T : INumber<T>
    {
        return Divisors(number).TakeWhile(divisor => divisor < number);
    }

    public static T DigitSum<T>(T n)
        where T : IBinaryInteger<T>
    {
        var ten = T.CreateChecked(10);
        var sum = T.Zero;
        while (n != T.Zero)
        {
            sum += n % ten;
            n /= ten;
        }

        return sum;
    }

    /// <summary>
    /// Greatest common divisor. Aka highest common factor (HCF)
    /// </summary>
    /// <param name="a">First value.</param>
    /// <param name="b">Second value.</param>
    /// <returns>The GCD</returns>
    public static int GCD(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
            {
                a %= b;
            }
            else
            {
                b %= a;
            }
        }

        return a == 0 ? b : a;
    }

    /// <summary>
    /// Get the nth triangle number.
    /// </summary>
    /// <param name="n">The nth number.</param>
    /// <returns>Value of the number.</returns>
    public static long TriangleNumber(int n)
    {
        // We can safely assume the triangle number is an integer because one of n or n+1 is even
        return (long)(0.5 * n * (n + 1));
    }

    /// <summary>
    /// Checks if number is prime by using 6k ± 1 optimization.
    /// </summary>
    /// <param name="n">Number to be tested.</param>
    /// <returns>Value indicating if a number is prime.</returns>
    public static bool IsPrime(long n)
    {
        if (n <= 3)
        {
            return n > 1;
        }
        else if (n % 2 == 0 || n % 3 == 0)
        {
            return false;
        }

        long i = 5;
        while (i * i <= n)
        {
            if (n % i == 0 || n % (i + 2) == 0)
            {
                return false;
            }

            i += 6;
        }

        return true;
    }

    /// <summary>
    /// Returns distinct prime factors of a number. If number is a prime - returns itself.
    /// </summary>
    /// <typeparam name="T">Type of number.</typeparam>
    /// <param name="n">Number to be factorized</param>
    /// <returns>Lazy executed prime factors</returns>
    public static IEnumerable<T> PrimeFactors<T>(T n)
        where T : INumber<T>
    {
        var two = T.CreateChecked(2);
        var twoReturned = false; // ensure distinct
        while (n % two == T.Zero)
        {
            if (!twoReturned)
            {
                yield return two;
                twoReturned = true;
            }

            n /= two;
        }

        // n must be odd at this point. So we can
        // skip one element (Note i = i+2)
        var three = T.CreateChecked(3);
        var sqrt = n.SqrtViaDouble();
        for (var i = three; i <= sqrt; i += two)
        {
            // While i divides n, return i and divide n
            var iReturned = false; // ensure distinct
            while (n % i == T.Zero)
            {
                if (!iReturned)
                {
                    yield return i;
                    iReturned = true;
                }

                n /= i;
            }
        }

        // This condition is to handle the case when
        // n is a prime number greater than 2
        if (n > two)
        {
            yield return n;
        }
    }

    public static long BinomialCoefficient(long n, long k)
    {
        k = Math.Min(k, n - k);
        double result = 1;
        for (var i = 1; i < k + 1; i++)
        {
            result *= (n + 1 - i) / (double)i;
        }

        return (long)result;
    }

    public static long AllPossibleSummationsOf(int n)
    {
        var arr = Enumerable.Range(1, n - 1).ToArray();
        var table = new long[n + 1];
        table[0] = 1;
        for (var i = 0; i < arr.Length; i++)
        {
            for (var j = arr[i]; j <= n; j++)
            {
                table[j] += table[j - arr[i]];
            }
        }

        return table[n];
    }

    public static T SqrtViaDouble<T>(this T number)
        where T : INumber<T>
    {
        return T.CreateTruncating(double.Sqrt(double.CreateChecked(number)));
    }

    public static int DigitCount<T>(T number)
        where T : IFloatingPointIeee754<T>
    {
        var log10P1 = T.Log10P1(number);
        var floor = T.Floor(log10P1);
        return int.CreateChecked(floor);
    }

    public static int DigitCount(BigInteger number)
    {
        var log10P1 = BigInteger.Log10(number) + 1;
        var floor = Math.Floor(log10P1);
        return (int)floor;
    }
}
