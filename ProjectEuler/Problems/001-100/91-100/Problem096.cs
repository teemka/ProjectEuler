using System.Text;

namespace ProjectEuler.Problems._001_100._91_100;

/// <summary>
/// https://projecteuler.net/problem=96
/// </summary>
internal class Problem096 : IProblem
{
    public async Task<string> CalculateAsync(string[] args)
    {
        var lines = await File.ReadAllLinesAsync("Problems/001-100/91-100/p096_sudoku.txt");
        var sudokus = lines.Chunk(10)
            .Select(chunk => Sudoku.Parse(chunk.Skip(1)))
            .ToList();

        var sum = 0;
        foreach (var sudoku in sudokus)
        {
            sudoku.Solve();
            sum += sudoku.Grid[0].Take(3).ToArray().ToNumberFromDigits();
        }

        return sum.ToString();
    }
}

public class Sudoku
{
    private Sudoku(int[][] grid)
    {
        this.Grid = grid;
    }

    public int[][] Grid { get; private set; }

    public void Solve()
    {
        Backtrack(this, Root());
    }

    private static void Backtrack(Sudoku sudoku, Candidate[] candidates)
    {
        if (Reject(sudoku, candidates))
        {
            return;
        }

        if (Accept(sudoku, candidates))
        {
            var solved = sudoku.Apply(candidates);
            sudoku.Grid = solved.Grid;
            return;
        }

        var s = First(sudoku, candidates);
        while (s is not null)
        {
            Backtrack(sudoku, s);
            s = Next(s);
        }
    }

    private Sudoku Apply(Candidate[] candidates)
    {
        // Create a copy of the current Sudoku grid
        var newGrid = this.Grid.Select(row => row.ToArray()).ToArray();

        foreach (var candidate in candidates)
        {
            newGrid[candidate.Row][candidate.Col] = candidate.Value;
        }

        return new Sudoku(newGrid);
    }

    private static bool Reject(Sudoku sudoku, Candidate[] candidates)
    {
        if (candidates.Length == 0)
        {
            return false; // No candidates to check
        }

        var candidate = candidates[^1];
        sudoku = sudoku.Apply(candidates[..^1]);

        // Check row
        for (int col = 0; col < 9; col++)
        {
            if (sudoku.Grid[candidate.Row][col] == candidate.Value)
            {
                return true;
            }
        }

        // Check column
        for (int row = 0; row < 9; row++)
        {
            if (sudoku.Grid[row][candidate.Col] == candidate.Value)
            {
                return true;
            }
        }

        // Check 3x3 block
        int blockRow = candidate.Row / 3 * 3;
        int blockCol = candidate.Col / 3 * 3;
        for (int row = blockRow; row < blockRow + 3; row++)
        {
            for (int col = blockCol; col < blockCol + 3; col++)
            {
                if (sudoku.Grid[row][col] == candidate.Value)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static Candidate[] Root()
    {
        return [];
    }

    private static bool Accept(Sudoku sudoku, Candidate[] candidates)
    {
        sudoku = sudoku.Apply(candidates);

        return sudoku.Grid.Sum(row => row.Count(cell => cell != 0)) == 81;
    }

    private static Candidate[]? First(Sudoku sudoku, Candidate[] candidates)
    {
        sudoku = sudoku.Apply(candidates);

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (sudoku.Grid[row][col] == 0)
                {
                    return [.. candidates, new(row, col, 1)];
                }
            }
        }

        return null; // No empty cell found
    }

    private static Candidate[]? Next(Candidate[] candidates)
    {
        var candidate = candidates.LastOrDefault();
        if (candidate.Equals(default))
        {
            return null;
        }

        return candidate.Value < 9
            ? [.. candidates[..^1], candidate.NextNumber()]
            : null;
    }

    public static Sudoku Parse(string chunk) => Parse(chunk.Split(Environment.NewLine));

    public static Sudoku Parse(IEnumerable<string> chunk)
    {
        return new([.. chunk.Select(line => line.Select(c => c.ToInt()).ToArray())]);
    }

    public readonly record struct Candidate(int Row, int Col, int Value)
    {
        public Candidate NextNumber() => this with { Value = this.Value + 1 };
        public override string ToString() => $"{this.Row},{this.Col}={this.Value}";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                sb.Append(this.Grid[i][j]);
            }

            if (i < 8)
            {
                sb.AppendLine();
            }
        }

        return sb.ToString();
    }
}
