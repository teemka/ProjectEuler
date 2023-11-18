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
            trees.Add(vertex);
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
        public HashSet<Edge> Edges { get; } = [];
    }

    public class Edge(
        int value,
        Vertex v1,
        Vertex v2)
    {
        public int Value { get; } = value;

        public Vertex V1 { get; } = v1;

        public Vertex V2 { get; } = v2;

        public override string ToString() => this.Value.ToString();
    }
}
