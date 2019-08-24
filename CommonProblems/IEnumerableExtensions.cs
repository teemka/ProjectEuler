using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonProblems
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
            if (sequence is null)
                throw new ArgumentNullException(nameof(sequence));

            return helper(sequence, sequence.Count());

            IEnumerable<IEnumerable<T>> helper(IEnumerable<T> coll, int depth)
            {
                if (depth == 1)
                    return sequence.Select(t => new T[] { t });

                return helper(coll, depth - 1)
                    .SelectMany(t => sequence.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new T[] { t2 }));
            }
        }
    }
}
