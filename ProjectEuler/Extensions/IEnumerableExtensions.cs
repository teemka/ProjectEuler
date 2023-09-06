namespace ProjectEuler.Extensions;

internal static class IEnumerableExtensions
{
    internal static long LargestProductOfConsecutiveNumbers(this IEnumerable<int> sequence, int count)
    {
        var length = sequence.Count();
        long largest = long.MinValue;
        for (int i = 0; i < length - count; i++)
        {
            var digits = sequence.Skip(i).Take(count).ToArray();
            long product = digits.Aggregate(1L, (a, b) => a * b);
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

        return sequence.SelectMany(x => other, (a, b) => (a, b));
    }

    internal static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> sequence)
    {
        var list = sequence.ToList();

        if (!list.Any())
        {
            yield return Enumerable.Empty<T>();
        }
        else
        {
            var startingElementIndex = 0;

            foreach (var startingElement in list)
            {
                var index = startingElementIndex;
                var remainingItems = list.Where((e, i) => i != index);

                foreach (var permutationOfRemainder in remainingItems.GetPermutations())
                {
                    yield return startingElement.Concat(permutationOfRemainder);
                }

                startingElementIndex++;
            }
        }
    }

    internal static IEnumerable<T> Concat<T>(this T firstElement, IEnumerable<T> secondSequence)
    {
        yield return firstElement;
        if (secondSequence == null)
        {
            yield break;
        }

        foreach (var item in secondSequence)
        {
            yield return item;
        }
    }

    // Enumerate all possible m-size combinations of [0, 1, ..., n-1] array
    // in lexicographic order (first [0, 1, 2, ..., m-1]).
    internal static IEnumerable<int[]> Combinations(int m, int n)
    {
        int[] result = new int[m];
        var stack = new Stack<int>(m);
        stack.Push(0);
        while (stack.Count > 0)
        {
            int index = stack.Count - 1;
            int value = stack.Pop();
            while (value < n)
            {
                result[index++] = value++;
                stack.Push(value);
                if (index != m)
                {
                    continue;
                }

                yield return (int[])result.Clone();
                break;
            }
        }
    }

    internal static IEnumerable<T[]> Combinations<T>(this T[] array, int m)
    {
        if (array.Length < m)
        {
            throw new ArgumentException("Array length can't be less than number of selected elements");
        }

        if (m < 1)
        {
            throw new ArgumentException("Number of selected elements can't be less than 1");
        }

        var result = new T[m];
        foreach (int[] j in Combinations(m, array.Length))
        {
            for (int i = 0; i < m; i++)
            {
                result[i] = array[j[i]];
            }

            yield return result;
        }
    }
}
