using System.Collections;

namespace ProjectEuler.Helpers;

public class DisjointSet<T> : IEnumerable<T>
    where T : notnull
{
    private readonly Dictionary<T, Element> elements = new();

    public void MakeSet(T x)
    {
        this.elements.Add(x, new Element(x, 1));
    }

    public void Add(T item) => this.MakeSet(item);

    public T FindParent(T x)
    {
        var element = this.elements[x];

        if (element.Parent.Equals(x))
        {
            return x;
        }

        return element.Parent = this.FindParent(element.Parent);
    }

    public int GetSize(T item) => this.elements[this.FindParent(item)].Size;

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
        if (this.elements[x].Size < this.elements[y].Size)
        {
            (x, y) = (y, x);
        }

        // Make x the new root
        var yElem = this.elements[y];
        yElem.Parent = x;

        // Update the size of x
        var xElem = this.elements[x];
        xElem.Size += yElem.Size;
    }

    public bool Contains(T item) => this.elements.ContainsKey(item);

    public IEnumerator<T> GetEnumerator() => this.elements.Keys.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.elements.Keys.GetEnumerator();

    private class Element
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
