namespace ProjectEuler.Problems._101_200._101_110;

/// <summary>
/// https://projecteuler.net/problem=107
/// Answer: 259679
/// </summary>
public class Problem107 : IProblem
{
    public static int Solve(string[] lines)
    {
        var vertices = lines.Select(x => new Kruskal.Vertex()).ToArray();

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i].Split(",");
            for (var j = 0; j < i; j++)
            {
                if (!int.TryParse(line[j], out var value))
                {
                    continue;
                }

                var edge = new Kruskal.Edge(value, vertices[i], vertices[j]);

                vertices[i].Edges.Add(edge);
                vertices[j].Edges.Add(edge);
            }
        }

        var mst = Kruskal.CalculateMst(vertices);
        var edges = vertices.SelectMany(x => x.Edges).Distinct();

        var diff = edges.Except(mst).Sum(x => x.Value);

        return diff;
    }

    public async Task<string> CalculateAsync(string[] args)
    {
        var lines = await File.ReadAllLinesAsync("Problems/101-200/101-110/p107_network.txt");

        return Solve(lines).ToString();
    }
}
