using System.Numerics;

namespace ProjectEuler.Extensions;

internal static class IEnumerableExtensions
{
    internal static long LargestProductOfConsecutiveNumbers(this IReadOnlyCollection<int> sequence, int count)
    {
        var length = sequence.Count;
        var largest = long.MinValue;
        for (var i = 0; i < length - count; i++)
        {
            var digits = sequence.Skip(i).Take(count).ToArray();
            var product = digits.Aggregate(1L, (a, b) => a * b);
            if (product > largest)
            {
                largest = product;
            }
        }

        return largest;
    }

    internal static IEnumerable<(T A, T B)> CartesianProduct<T>(this IEnumerable<T> sequence, IEnumerable<T> other)
    {
        ArgumentNullException.ThrowIfNull(sequence);
        ArgumentNullException.ThrowIfNull(other);

        return sequence.SelectMany(_ => other, (a, b) => (a, b));
    }

    internal static IEnumerable<IEnumerable<T>> GetLexicographicPermutations<T>(this IList<T> list)
    {
        if (list.Count == 0)
        {
            yield return [];
            yield break;
        }

        var index = 0;
        foreach (var item in list)
        {
            var copy = list.ToList();
            copy.RemoveAt(index);

            foreach (var permutationOfRemainder in copy.GetLexicographicPermutations())
            {
                yield return item.Concat(permutationOfRemainder);
            }

            index++;
        }
    }

    internal static IEnumerable<IList<T>> GetPermutations<T>(this IList<T> list)
    {
        return list.GetPermutations(0);
    }

    private static IEnumerable<IList<T>> GetPermutations<T>(this IList<T> list, int startIndex)
    {
        if (list.Count == startIndex)
        {
            yield return list;
        }

        for (var i = startIndex; i < list.Count; i++)
        {
            (list[i], list[startIndex]) = (list[startIndex], list[i]);

            foreach (var permutation in list.GetPermutations(startIndex + 1))
            {
                yield return permutation;
            }

            (list[i], list[startIndex]) = (list[startIndex], list[i]);
        }
    }

    private static IEnumerable<T> Concat<T>(this T firstElement, IEnumerable<T> secondSequence)
    {
        yield return firstElement;

        foreach (var item in secondSequence)
        {
            yield return item;
        }
    }

    internal static IEnumerable<T> RepeatForever<T>(this IEnumerable<T> sequence)
    {
        var arr = sequence.ToArray();
        while (true)
        {
            foreach (var item in arr)
            {
                yield return item;
            }
        }
    }

    public static T ToNumberFromDigits<T>(this IList<T> digits)
        where T : IBinaryInteger<T>
    {
        return digits.ToNumberFromDigits(0, digits.Count);
    }

    public static T ToNumberFromDigits<T>(this IList<T> digits, int startIndex, int length)
        where T : IBinaryInteger<T>
    {
        if (startIndex > digits.Count || length > digits.Count - startIndex)
        {
            ThrowArgumentOutOfRange(digits, startIndex, length);
        }

        if (length == 0)
        {
            return T.Zero;
        }

        var ten = T.CreateChecked(10);
        var endIndex = startIndex + length;
        var sum = digits[endIndex - 1];

        var multiplier = ten;
        for (var i = endIndex - 2; i >= startIndex; i--)
        {
            var digit = digits[i];
            sum += multiplier * digit;
            multiplier *= ten;
        }

        return sum;
    }

    private static void ThrowArgumentOutOfRange<T>(IList<T> digits, int startIndex, int length)
        where T : IBinaryInteger<T>
    {
        ArgumentOutOfRangeException.ThrowIfNegative(startIndex);

        if (startIndex > digits.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index is greater than the number of elements.");
        }

        ArgumentOutOfRangeException.ThrowIfNegative(length);

        throw new ArgumentOutOfRangeException(nameof(length), "Length is greater than the number of elements.");
    }
}
