using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public static class IEnumerableExtensions
    {
        public static long LargestProductOfConsecutiveNumbers(this IEnumerable<int> sequence, int count)
        {
            var length = sequence.Count();
            long largest = long.MinValue;
            for (int i = 0; i < length - count; i++)
            {
                var digits = sequence.Skip(i).Take(count).ToArray();
                long product = digits.Aggregate((long)1, (a, b) => a * b);
                if (product > largest)
                    largest = product;
            }

            return largest;
        }

        public static IEnumerable<(T a, T b)> CartesianProduct<T>(this IEnumerable<T> sequence, IEnumerable<T> other)
        {
            if (sequence is null)
                throw new ArgumentNullException(nameof(sequence));
            if (other is null)
                throw new ArgumentNullException(nameof(other));
            return sequence.SelectMany(x => other, (a, b) => (a, b));
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                yield break;
            }

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
        private static IEnumerable<T> Concat<T>(this T firstElement, IEnumerable<T> secondSequence)
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
    }
}
