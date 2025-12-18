namespace ProjectEuler.Problems._001_100._81_90;

/// <summary>
/// https://projecteuler.net/problem=82
/// </summary>
public class Problem082 : IProblem
{
    public async Task<string> CalculateAsync(string[] args)
    {
        const int size = 80;
        var lines = await File.ReadAllLinesAsync("Problems/001-100/81-90/p082_matrix.txt");

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

        // Create a fake root which is connected to all vertices on the left column.
        var root = new Dijkstra.Vertex(0);
        graph.Add(root);
        for (var i = 0; i < size; i++)
        {
            root.Neighbours.Add(arr[i, 0]);
        }

        // Create a fake target which is connected to all vertices on the right column.
        var target = new Dijkstra.Vertex(0);
        graph.Add(target);
        for (var i = 0; i < size; i++)
        {
            arr[i, size - 1].Neighbours.Add(target);
        }

        var (dist, _) = Dijkstra.Calculate(graph, root);
        return dist[target].ToString();
    }
}
