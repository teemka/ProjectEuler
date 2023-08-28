namespace ProjectEuler.Problems._001_100._81_90;

/// <summary>
/// https://projecteuler.net/problem=82
/// Answer: 260324
/// </summary>
public class Problem082 : IProblem
{
    public async Task<string> CalculateAsync(string[] args)
    {
        var size = 80;
        var lines = await File.ReadAllLinesAsync("Problems/001-100/81-90/p082_matrix.txt");

        var graph = new List<Dijkstra.Vertex>();
        var arr = new Dijkstra.Vertex[size, size];

        for (int i = 0; i < size; i++)
        {
            var numbers = lines[i].Split(",").Select(int.Parse).ToArray();

            for (int j = 0; j < size; j++)
            {
                var vertex = new Dijkstra.Vertex(numbers[j]);
                arr[i, j] = vertex;
                graph.Add(vertex);
            }
        }

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                // Up
                if (i > 0)
                {
                    arr[i, j].Neighbours.Add(arr[i - 1, j]);
                }

                // Down
                if (i < size - 1)
                {
                    arr[i, j].Neighbours.Add(arr[i + 1, j]);
                }

                // Right
                if (j < size - 1)
                {
                    arr[i, j].Neighbours.Add(arr[i, j + 1]);
                }
            }
        }

        var targets = new Dijkstra.Vertex[80];
        for (int i = 0; i < size; i++)
        {
            targets[i] = arr[i, size - 1];
        }

        var distances = new List<long>();
        for (int i = 0; i < size; i++)
        {
            var root = arr[i, 0];
            var (dist, prev) = Dijkstra.Calculate(graph, root);

            distances.AddRange(targets.Select(t => dist[t]));
        }

        return distances.Min().ToString();
    }
}
