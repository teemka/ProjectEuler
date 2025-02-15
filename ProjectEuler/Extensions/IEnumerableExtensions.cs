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

    internal static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IList<T> list)
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

            foreach (var permutationOfRemainder in copy.GetPermutations())
            {
                yield return item.Concat(permutationOfRemainder);
            }

            index++;
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
}
