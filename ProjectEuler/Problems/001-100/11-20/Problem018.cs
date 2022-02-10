namespace ProjectEuler.Problems._001_100._11_20;

/// <summary>
/// By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.
///
///    3
///   7 4
///  2 4 6
/// 8 5 9 3
///
/// That is, 3 + 7 + 4 + 9 = 23.
///
/// Find the maximum total from top to bottom of the triangle below:
///
///    75
///  95 64
/// 17 47 82........
/// </summary>
public class Problem018 : IProblem
{
    public async Task<string> CalculateAsync(string[] args)
    {
        var lines = await File.ReadAllLinesAsync("Problems/001-100/11-20/Problem018_triangle.txt");
        var root = new Vertex(int.Parse(lines[0]));
        var vertices = new Vertex[lines.Length][];
        vertices[0] = new Vertex[] { root };
        var edges = vertices.Take(lines.Length - 1).Zip(lines.Skip(1), (v, l) => (vertices: v, line: l)).ToArray();
        for (int i = 0; i < edges.Length; i++)
        {
            var edge = edges[i];
            var parsed = edge.line.Split(" ").Select(int.Parse).Select(x => new Vertex(x)).ToArray();

            for (int j = 0; j < edge.vertices.Length; j++)
            {
                edge.vertices[j].Neighbours.Add(parsed[j]);
                edge.vertices[j].Neighbours.Add(parsed[j + 1]);
            }

            if (i < edges.Length - 1)
            {
                edges[i + 1].vertices = parsed;
            }

            vertices[i + 1] = parsed;
        }

        var graph = vertices.SelectMany(x => x).ToArray();
        var (dist, prev) = Dijkstra(graph, root);
        var lastRow = vertices[^1];
        var lastRowValue = lastRow.Select(v => (v, dist[v])).ToArray();
        var vertexWithMaxValue = lastRow.OrderBy(v => dist[v]).ToArray()[0];

        var path = RecreatePath(prev, vertexWithMaxValue);
        var sum = path.Select(v => v.OriginalValue).Sum();

        return sum.ToString();
    }

    private static IEnumerable<Vertex> RecreatePath(Dictionary<Vertex, Vertex> prev, Vertex start)
    {
        yield return start;
        var next = start;
        while (prev.ContainsKey(next))
        {
            next = prev[next];
            yield return next;
        }
    }

    private static (Dictionary<Vertex, int> Dist, Dictionary<Vertex, Vertex> Prev) Dijkstra(Vertex[] graph, Vertex source)
    {
        var queue = new List<Vertex>(graph);
        var dist = graph.ToDictionary(x => x, v => int.MaxValue - 100);
        var prev = new Dictionary<Vertex, Vertex>();
        dist[source] = 0;

        while (queue.Any())
        {
            queue = queue.OrderBy(v => dist[v]).ToList();
            var u = queue[0];
            queue = queue.Skip(1).ToList();
            foreach (var v in u.Neighbours)
            {
                if (!queue.Contains(v))
                {
                    continue;
                }

                var alt = dist[u] + v.Value;
                if (alt < dist[v])
                {
                    dist[v] = alt;
                    prev[v] = u;
                }
            }
        }

        return (dist, prev);
    }

    private class Vertex
    {
        public Vertex(int value)
        {
            this.OriginalValue = value;
        }

        public int OriginalValue { get; }

        public int Value => 100 - this.OriginalValue;

        public List<Vertex> Neighbours { get; } = new List<Vertex>();
    }
}
