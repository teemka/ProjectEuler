namespace ProjectEuler.Helpers;

internal static class PermutationsHelper
{
    /// <summary>
    /// Get all permutations of <see cref="IList{T}"/>. List is modified in place.
    /// </summary>
    /// <remarks>
    /// Implementation uses non-recursive Heap's algorithm
    /// </remarks>
    /// <typeparam name="T">Type of values to permute.</typeparam>
    /// <param name="list">List to generate permutations from.</param>
    /// <returns>Enumerable of permutations.</returns>
    internal static IEnumerable<IList<T>> GetPermutations<T>(this IList<T> list)
    {
        // c is an encoding of the stack state.
        var c = new int[list.Count];

        yield return list;

        var i = 1;
        while (i < list.Count)
        {
            if (c[i] < i)
            {
                if (int.IsEvenInteger(i))
                {
                    (list[0], list[i]) = (list[i], list[0]);
                }
                else
                {
                    (list[c[i]], list[i]) = (list[i], list[c[i]]);
                }

                yield return list;
                c[i]++;
                i = 1;
            }
            else
            {
                c[i] = 0;
                i++;
            }
        }
    }
}
