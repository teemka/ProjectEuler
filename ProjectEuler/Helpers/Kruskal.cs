namespace ProjectEuler.Helpers;

/// <summary>
/// https://en.wikipedia.org/wiki/Kruskal's_algorithm
/// </summary>
public static class Kruskal
{
    public static HashSet<Edge> CalculateMst(IEnumerable<Vertex> graph)
    {
        var trees = graph.ToDictionary(v => v, v => new HashSet<Vertex> { v });

        var output = new HashSet<Edge>();

        var edges = graph
            .SelectMany(v => v.Edges)
            .Distinct()
            .OrderBy(e => e.Value)
            .ToList();

        foreach (var edge in edges)
        {
            if (trees[edge.V1] != trees[edge.V2])
            {
                output.Add(edge);

                // Merge trees
                foreach (var vertex in trees[edge.V2])
                {
                    trees[edge.V1].Add(vertex);
                }

                foreach (var vertex in trees[edge.V1])
                {
                    trees[vertex] = trees[edge.V1];
                }
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
