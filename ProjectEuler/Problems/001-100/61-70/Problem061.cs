namespace ProjectEuler.Problems._001_100._61_70;

/// <summary>
/// https://projecteuler.net/problem=61
/// </summary>
public class Problem061 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var lastRow = 6; // default
        if (args.Length == 1)
        {
            lastRow = int.Parse(args[0]);
        }

        var origin = new long[][]
        {
            FourDigit(Sequences.TriangleNumbers()),
            FourDigit(Sequences.SquareNumbers()),
            FourDigit(Sequences.PentagonalNumbers()),
            FourDigit(Sequences.HexagonalNumbers()),
            FourDigit(Sequences.HeptagonalNumbers()),
            FourDigit(Sequences.OctagonalNumbers()),
        };

        foreach (var numbers in origin.Take(lastRow).GetPermutations().Select(x => x.ToArray()))
        {
            // Init DFS
            var discovered = new HashSet<Address2d>();
            var stack = new Stack<Address2d>();
            var prev = new Dictionary<Address2d, Address2d>();

            // Add first row as sources
            for (var j = 0; j < numbers[0].Length; j++)
            {
                stack.Push(new(0, j));
            }

            while (stack.TryPop(out var address))
            {
                if (!discovered.Add(address))
                {
                    continue;
                }

                var number = numbers[address.I][address.J];
                var right = number.ToString()[^2..];
                var i = address.I + 1;

                // Check if loop is closed
                if (i == lastRow)
                {
                    var path = RecreatePath(prev, address).Reverse().ToArray();
                    var sourceAddress = path.First();
                    var nextNumber = numbers[0][sourceAddress.J];
                    var left = nextNumber.ToString()[..2];

                    if (right == left)
                    {
                        // Found
                        var set = path.Select(x => numbers[x.I][x.J]).ToArray();
                        var sum = set.Sum();
                        return Task.FromResult(sum.ToString());
                    }

                    continue;
                }

                for (var j = 0; j < numbers[i].Length; j++)
                {
                    var nextNumber = numbers[i][j];
                    var left = nextNumber.ToString()[..2];

                    // If right part of the previous number is equal to
                    // the left part of the next number then they are neighbours
                    if (right == left)
                    {
                        var neighbour = new Address2d(i, j);
                        prev[neighbour] = address;
                        stack.Push(neighbour);
                    }
                }
            }
        }

        throw new Exception("Solution not found");
    }

    private static IEnumerable<Address2d> RecreatePath(Dictionary<Address2d, Address2d> prev, Address2d target)
    {
        yield return target;
        var next = target;
        while (prev.TryGetValue(next, out var parent))
        {
            next = parent;
            yield return next;
        }
    }

    private static long[] FourDigit(IEnumerable<long> numbers) => numbers
        .SkipWhile(x => x < 1_000)
        .TakeWhile(x => x < 10_000)
        .ToArray();

    private readonly record struct Address2d(int I, int J);
}
