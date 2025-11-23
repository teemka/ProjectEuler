using System.Collections;

namespace ProjectEuler.Helpers;

/// <summary>
/// https://en.wikipedia.org/wiki/Disjoint-set_data_structure
/// </summary>
/// <typeparam name="T">Type of the item in the set.</typeparam>
public class DisjointSet<T> : IReadOnlyCollection<T>
    where T : notnull
{
    private readonly Dictionary<T, T> parents = [];
    private readonly Dictionary<T, int> sizes = [];

    public int Count => this.sizes.Count;

    /// <summary>
    /// Make singleton set from an item.
    /// </summary>
    /// <param name="item">Item to create set from</param>
    /// <exception cref="ArgumentException">Set for this item already exists.</exception>
    public void Add(T item)
    {
        this.parents.Add(item, item);
        this.sizes.Add(item, 1);
    }

    public T FindParent(T x)
    {
        var parent = this.parents[x];
        if (EqualityComparer<T>.Default.Equals(x, parent))
        {
            return x;
        }

        return this.parents[x] = this.FindParent(parent);
    }

    public int GetSize(T item) => this.sizes[this.FindParent(item)];

    public void Union(T x, T y)
    {
        // Replace nodes by roots
        x = this.FindParent(x);
        y = this.FindParent(y);

        // x and y are already in the same set
        if (EqualityComparer<T>.Default.Equals(x, y))
        {
            return;
        }

        // If necessary, rename variables to ensure that
        // x has at least as many descendants as y
        if (this.sizes[x] < this.sizes[y])
        {
            (x, y) = (y, x);
        }

        // Make x the new root
        this.parents[y] = x;

        // Update the size of x
        this.sizes[x] += this.sizes[y];
    }

    public IEnumerator<T> GetEnumerator() => this.sizes.Keys.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.sizes.Keys.GetEnumerator();
}
