﻿using System.Numerics;

namespace ProjectEuler.Helpers;

public static class Sequences
{
    public static IEnumerable<int> SpiralDiagonal()
    {
        var current = 1;
        var diff = 2;
        yield return current;
        while (true)
        {
            for (var i = 0; i < 4; i++)
            {
                current += diff;
                yield return current;
            }

            diff += 2;
        }
    }

    public static IEnumerable<long> TriangleNumbers(long n = 1)
    {
        while (true)
        {
            yield return n * (n + 1) / 2;
            n++;
        }
    }

    public static IEnumerable<long> SquareNumbers(long n = 1)
    {
        while (true)
        {
            yield return n * n;
            n++;
        }
    }

    public static IEnumerable<long> PentagonalNumbers(long n = 1)
    {
        while (true)
        {
            yield return n * ((3 * n) - 1) / 2;
            n++;
        }
    }

    public static IEnumerable<long> HexagonalNumbers(long n = 1)
    {
        while (true)
        {
            yield return n * ((2 * n) - 1);
            n++;
        }
    }

    public static IEnumerable<long> HeptagonalNumbers(long n = 1)
    {
        while (true)
        {
            yield return n * ((5 * n) - 3) / 2;
            n++;
        }
    }

    public static IEnumerable<long> OctagonalNumbers(long n = 1)
    {
        while (true)
        {
            yield return n * ((3 * n) - 2);
            n++;
        }
    }

    public static IEnumerable<long> Collatz(long n)
    {
        yield return n;
        while (n != 1)
        {
            if (n % 2 == 0)
            {
                n /= 2;
            }
            else
            {
                n = (3 * n) + 1;
            }

            yield return n;
        }
    }

    public static IEnumerable<T> Fibonacci<T>()
        where T : INumber<T>
    {
        var a = T.One;
        var b = T.One;
        yield return a;
        yield return b;
        while (true)
        {
            (a, b) = (b, a + b);
            yield return b;
        }
    }
}
