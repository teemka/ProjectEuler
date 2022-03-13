namespace ProjectEuler.Helpers;

/// <summary>
/// https://en.wikipedia.org/wiki/Kruskal's_algorithm
/// </summary>
public static class Kruskal
{
    public static HashSet<Edge> CalculateMst(IEnumerable<Vertex> graph)
    {
        var trees = new DisjointSet<Vertex>();

        foreach (var vertex in graph)
        {
            trees.MakeSet(vertex);
        }

        var output = new HashSet<Edge>();

        var edges = graph
            .SelectMany(v => v.Edges)
            .Distinct()
            .OrderBy(e => e.Value)
            .ToList();

        foreach (var edge in edges)
        {
            if (trees.FindParent(edge.V1) != trees.FindParent(edge.V2))
            {
                output.Add(edge);
                trees.Union(trees.FindParent(edge.V1), trees.FindParent(edge.V2));
            }
        }

        return output;
    }

    public class Vertex
    {
        public HashSet<Edge> Edges { get; } = new();
    }

    public class Edge
    {
        public Edge(
            int value,
            Vertex v1,
            Vertex v2)
        {
            this.Value = value;
            this.V1 = v1;
            this.V2 = v2;
        }

        public int Value { get; }

        public Vertex V1 { get; }

        public Vertex V2 { get; }

        public override string ToString() => this.Value.ToString();
    }
}
