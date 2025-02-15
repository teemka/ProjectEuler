namespace ProjectEuler.Helpers;

public static class Dijkstra
{
    public static (Dictionary<Vertex, long> Dist, Dictionary<Vertex, Vertex?> Prev) Calculate(IReadOnlyCollection<Vertex> graph, Vertex root)
    {
        var queue = new PriorityQueue<Vertex, long>();
        var dist = graph.ToDictionary(v => v, _ => long.MaxValue);
        var prev = new Dictionary<Vertex, Vertex?>
        {
            [root] = null,
        };
        dist[root] = root.Value;
        queue.EnqueueRange(graph.Select(v => (v, dist[v])));

        while (queue.TryDequeue(out var u, out _))
        {
            foreach (var v in u.Neighbours)
            {
                var alt = dist[u] + v.Value;
                if (alt >= dist[v])
                {
                    continue;
                }

                dist[v] = alt;
                prev[v] = u;
                queue.Enqueue(v, 0);
            }
        }

        return (dist, prev);
    }

    public static IEnumerable<Vertex> RecreatePath(Dictionary<Vertex, Vertex?> prev, Vertex target)
    {
        yield return target;
        var next = target;
        while (prev.ContainsKey(next))
        {
            next = prev[next];
            if (next is null)
            {
                yield break;
            }

            yield return next;
        }
    }

    public class Vertex
    {
        public Vertex(long value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "Value must be positive");
            }

            this.Value = value;
        }

        public long Value { get; }

        public HashSet<Vertex> Neighbours { get; } = [];

        public override string ToString() => this.Value.ToString();
    }
}
