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
/// Answer: 1074
/// Path: 75, 64, 82, 87, 82, 75, 73, 28, 83, 32, 91, 78, 58, 73, 93
/// </summary>
public class Problem018 : IProblem
{
    public async Task<string> CalculateAsync(string[] args)
    {
        var lines = args.FirstOrDefault()?.Split("\n") ?? await File.ReadAllLinesAsync("Problems/001-100/11-20/Problem018_triangle.txt");

        var root = new Dijkstra.Vertex(100 - int.Parse(lines[0]));
        var vertices = new Dijkstra.Vertex[lines.Length][];
        vertices[0] = [root];
        var edges = vertices.Take(lines.Length - 1).Zip(lines.Skip(1), (v, l) => (vertices: v, line: l)).ToArray();
        for (var i = 0; i < edges.Length; i++)
        {
            var edge = edges[i];
            var parsed = edge.line.Split(" ").Select(int.Parse).Select(x => new Dijkstra.Vertex(100 - x)).ToArray();

            for (var j = 0; j < edge.vertices.Length; j++)
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
        var (dist, prev) = Dijkstra.Calculate(graph, root);
        var target = vertices[^1].MinBy(x => dist[x])!;
        var maxDistance = dist[target];

        var path = Dijkstra.RecreatePath(prev, target).Reverse();
        var distance = path.Select(x => 100 - x.Value).Sum();

        return distance.ToString();
    }
}
