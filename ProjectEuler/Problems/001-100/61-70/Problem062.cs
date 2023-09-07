namespace ProjectEuler.Problems._001_100._61_70;

public class Problem062 : IProblem
{
    private readonly Dictionary<string, List<long>> permutations = new();

    public Task<string> CalculateAsync(string[] args)
    {
        var target = 5; // default
        if (args.Length == 1)
        {
            target = int.Parse(args[0]);
        }

        for (var i = 0; ; i++)
        {
            var cube = (long)Math.Pow(i, 3);
            var key = cube.ToString().OrderBy(x => x).Concat();

            if (!this.permutations.TryGetValue(key, out var cubes))
            {
                cubes = new(1);
                this.permutations[key] = cubes;
            }

            cubes.Add(cube);
            if (cubes.Count == target)
            {
                return Task.FromResult(cubes[0].ToString());
            }
        }
    }
}
