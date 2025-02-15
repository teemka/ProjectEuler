namespace ProjectEuler.Problems._001_100._81_90;

/// <summary>
/// https://projecteuler.net/problem=83
/// Answer: 425185
/// </summary>
public class Problem083 : IProblem
{
    public async Task<string> CalculateAsync(string[] args)
    {
        var size = 80;
        var lines = await File.ReadAllLinesAsync("Problems/001-100/81-90/p083_matrix.txt");

        var graph = new List<Dijkstra.Vertex>();
        var arr = new Dijkstra.Vertex[size, size];

        for (var i = 0; i < size; i++)
        {
            var numbers = lines[i].Split(",").Select(int.Parse).ToArray();

            for (var j = 0; j < size; j++)
            {
                var vertex = new Dijkstra.Vertex(numbers[j]);
                arr[i, j] = vertex;
                graph.Add(vertex);
            }
        }

        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                // Up
                if (i > 0)
                {
                    arr[i, j].Neighbours.Add(arr[i - 1, j]);
                }

                // Left
                if (j > 0)
                {
                    arr[i, j].Neighbours.Add(arr[i, j - 1]);
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

        var root = arr[0, 0];
        var target = arr[size - 1, size - 1];
        var (dist, prev) = Dijkstra.Calculate(graph, root);

        return dist[target].ToString();
    }
}
