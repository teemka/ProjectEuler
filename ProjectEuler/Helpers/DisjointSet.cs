using System.Collections;

namespace ProjectEuler.Helpers;

/// <summary>
/// https://en.wikipedia.org/wiki/Disjoint-set_data_structure
/// </summary>
/// <typeparam name="T">Type of the item in the set.</typeparam>
public class DisjointSet<T> : IReadOnlyCollection<T>
    where T : notnull
{
    private readonly Dictionary<T, T> parents = new();
    private readonly Dictionary<T, int> sizes = new();

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
        if (this.parents[x].Equals(x))
        {
            return x;
        }

        return this.parents[x] = this.FindParent(this.parents[x]);
    }

    public int GetSize(T item) => this.sizes[this.FindParent(item)];

    public void Union(T x, T y)
    {
        // Replace nodes by roots
        x = this.FindParent(x);
        y = this.FindParent(y);

        // x and y are already in the same set
        if (x.Equals(y))
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

    public bool Contains(T item) => this.sizes.ContainsKey(item);

    public IEnumerator<T> GetEnumerator() => this.sizes.Keys.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.sizes.Keys.GetEnumerator();

    private struct Element
    {
        public Element(T parent, int size)
        {
            this.Parent = parent;
            this.Size = size;
        }

        public T Parent { get; set; }

        public int Size { get; set; }
    }
}
