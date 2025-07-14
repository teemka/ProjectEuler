namespace ProjectEuler.Helpers;

internal static class CombinationsHelper
{
    internal static IEnumerable<IList<T>> GetCombinations<T>(this IList<T> list, int length)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(length);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(length, list.Count);

        return list.GetCombinationsInternal(length);
    }

    private static IEnumerable<IList<T>> GetCombinationsInternal<T>(this IList<T> list, int length)
    {
        if (length == 0)
        {
            yield return [];
            yield break;
        }

        for (var i = 0; i <= list.Count - length; i++)
        {
            var firstElement = list[i];
            var remainingElements = list.Skip(i + 1).ToList();
            foreach (var combination in remainingElements.GetCombinationsInternal(length - 1))
            {
                yield return new[] { firstElement }.Concat(combination).ToList();
            }
        }
    }

    internal static IEnumerable<IList<T>> GetCombinationsWithRepetitions<T>(this IList<T> list, int length)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentOutOfRangeException.ThrowIfNegative(length);

        return list.GetCombinationsWithRepetitionsInternal(length);
    }

    private static IEnumerable<IList<T>> GetCombinationsWithRepetitionsInternal<T>(this IList<T> list, int length)
    {
        if (length == 0)
        {
            yield return [];
            yield break;
        }

        for (var i = 0; i < list.Count; i++)
        {
            var firstElement = list[i];
            foreach (var combination in list.Skip(i).ToList().GetCombinationsWithRepetitionsInternal(length - 1))
            {
                yield return new[] { firstElement }.Concat(combination).ToList();
            }
        }
    }
}
