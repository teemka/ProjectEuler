using System.Diagnostics;
using System.Text;

namespace ProjectEuler.Problems._001_100._91_100;

/// <summary>
/// https://projecteuler.net/problem=96
/// </summary>
internal class Problem096 : IProblem
{
    public async Task<string> CalculateAsync(string[] args)
    {
        var sudokus = await ParseData();

        var sum = 0;
        foreach (var sudoku in sudokus)
        {
            if (!new SudokuInductionSolver(sudoku).TrySolve())
            {
                new SudokuBacktrackingSolver(sudoku).Solve();
            }

            sum += sudoku.Grid[0].Take(3).ToArray().ToNumberFromDigits();
        }

        return sum.ToString();
    }

    public static async Task<List<Sudoku>> ParseData()
    {
        var lines = await File.ReadAllLinesAsync("Problems/001-100/91-100/p096_sudoku.txt");

        return [.. lines.Chunk(10).Select(chunk => Sudoku.Parse(chunk.Skip(1)))];
    }
}

public class Sudoku
{
    internal Sudoku(int[][] grid)
    {
        this.Grid = grid;
    }

    public int[][] Grid { get; }

    public static Sudoku Parse(string value) => Parse(value.Split(Environment.NewLine));

    public static Sudoku Parse(IEnumerable<string> lines)
    {
        return new([.. lines.Select(line => line.Select(c => c.ToInt()).ToArray())]);
    }

    public void CopyFrom(Sudoku other)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                this.Grid[i][j] = other.Grid[i][j];
            }
        }
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

public class SudokuInductionSolver
{
    private readonly HashSet<int>[] rows = new HashSet<int>[9];
    private readonly HashSet<int>[] columns = new HashSet<int>[9];
    private readonly Dictionary<int, (int SqRow, int SqCol)>[] inducedRows = new Dictionary<int, (int SqRow, int SqCol)>[9];
    private readonly Dictionary<int, (int SqRow, int SqCol)>[] inducedColumns = new Dictionary<int, (int SqRow, int SqCol)>[9];
    private readonly HashSet<int>[][] squares = new HashSet<int>[3][];
    private readonly HashSet<int>[][] possibleNumbers = new HashSet<int>[9][];
    private int solvedCells;
    private int triesSinceLastProgress;

    public SudokuInductionSolver(Sudoku sudoku)
    {
        this.Sudoku = sudoku;

        for (int i = 0; i < 9; i++)
        {
            this.rows[i] = [];
            this.columns[i] = [];
            this.inducedRows[i] = [];
            this.inducedColumns[i] = [];
            this.possibleNumbers[i] = new HashSet<int>[9];
            for (int j = 0; j < 9; j++)
            {
                this.possibleNumbers[i][j] = [];
            }
        }

        for (int sqRow = 0; sqRow < 3; sqRow++)
        {
            this.squares[sqRow] = new HashSet<int>[3];
            for (int sqCol = 0; sqCol < 3; sqCol++)
            {
                this.squares[sqRow][sqCol] = [];
            }
        }

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                var value = this.Sudoku.Grid[row][col];
                if (value == 0)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        this.possibleNumbers[row][col].Add(k);
                    }

                    continue;
                }

                this.solvedCells++;
                this.rows[row].Add(value);
                this.columns[col].Add(value);
                this.squares[row / 3][col / 3].Add(value);
            }
        }
    }

    public Sudoku Sudoku { get; }

    public bool TrySolve()
    {
        bool[][] unavailable = new bool[3][];
        for (int i = 0; i < 3; i++)
        {
            unavailable[i] = new bool[3];
        }

        var sqRow = 0;
        var sqCol = 0;
        var number = 1;
        while (true)
        {
            // Reset
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    unavailable[i][j] = false;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var row = i + sqRow * 3;
                    var col = j + sqCol * 3;
                    var value = this.Sudoku.Grid[row][col];
                    if (value != 0)
                    {
                        unavailable[i][j] = true;
                    }

                    if (this.squares[sqRow][sqCol].Contains(number))
                    {
                        this.RemovePossibility(number, row, col);
                        unavailable[i][j] = true;
                    }

                    if (this.columns[col].Contains(number))
                    {
                        this.RemovePossibility(number, row, col);
                        unavailable[i][j] = true;
                    }

                    if (this.rows[row].Contains(number))
                    {
                        this.RemovePossibility(number, row, col);
                        unavailable[i][j] = true;
                    }

                    if (this.inducedColumns[col].TryGetValue(number, out var origin) &&
                        (origin.SqRow != sqRow || origin.SqCol != sqCol))
                    {
                        this.RemovePossibility(number, row, col);
                        unavailable[i][j] = true;
                    }

                    if (this.inducedRows[row].TryGetValue(number, out var origin2) &&
                        (origin2.SqRow != sqRow || origin2.SqCol != sqCol))
                    {
                        this.RemovePossibility(number, row, col);
                        unavailable[i][j] = true;
                    }
                }
            }

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (this.possibleNumbers[row][col].Count == 1)
                    {
                        var onlyNumber = this.possibleNumbers[row][col].First();
                        this.CellSolved(onlyNumber, row, col);
                    }
                }
            }

            int availableCount = CountAvailable(unavailable);

            if (availableCount is 2 or 3)
            {
                this.CheckSingleRow(unavailable, sqRow, sqCol, number);
            }

            if (this.solvedCells == 81)
            {
                return true;
            }

            sqCol++;
            if (sqCol == 3)
            {
                sqCol = 0;
                sqRow++;
            }

            if (sqRow == 3)
            {
                sqRow = 0;
                number++;
            }

            if (number > 9)
            {
                number = 1;

                this.CheckSinglePossibilitySquare();
            }

            this.triesSinceLastProgress++;
            if (this.triesSinceLastProgress > 100)
            {
                return false;
            }
        }
    }

    private readonly Dictionary<int, int> countsSquare = [];
    private void CheckSinglePossibilitySquare()
    {
        for (int square = 0; square < 9; square++)
        {
            this.countsSquare.Clear();
            for (int innerSqure = 0; innerSqure < 9; innerSqure++)
            {
                var row = (square / 3) * 3 + innerSqure / 3;
                var col = (square % 3) * 3 + innerSqure % 3;
                foreach (var possibleNumber in this.possibleNumbers[row][col])
                {
                    if (!this.countsSquare.TryAdd(possibleNumber, 1))
                    {
                        this.countsSquare[possibleNumber]++;
                    }
                }
            }

            var found = 0;
            foreach (var kvp in this.countsSquare)
            {
                if (kvp.Value == 1)
                {
                    found = kvp.Key;
                }
            }

            if (found == 0)
            {
                continue;
            }

            for (int innerSqure = 0; innerSqure < 9; innerSqure++)
            {
                var row = (square / 3) * 3 + innerSqure / 3;
                var col = (square % 3) * 3 + innerSqure % 3;
                if (!this.possibleNumbers[row][col].Contains(found))
                {
                    continue;
                }

                this.CellSolved(found, row, col);
            }
        }
    }

    private void RemovePossibility(int number, int row, int col)
    {
        this.possibleNumbers[row][col].Remove(number);
    }

    private void CellSolved(int number, int row, int col)
    {
        Debug.Assert(this.Sudoku.Grid[row][col] == 0, "Cell should be empty before solving.");
        Debug.Assert(this.possibleNumbers[row][col].Contains(number), "Number should be a possible number for the cell.");
        Debug.Assert(!this.squares[row / 3][col / 3].Contains(number), "Number should not be in square.");
        Debug.Assert(!this.columns[col].Contains(number), "Column is already taken.");
        Debug.Assert(!this.rows[row].Contains(number), "Row is already taken.");

        this.Sudoku.Grid[row][col] = number;

        this.solvedCells++;
        this.triesSinceLastProgress = 0;

        this.rows[row].Add(number);
        this.columns[col].Add(number);
        this.squares[row / 3][col / 3].Add(number);

        this.possibleNumbers[row][col].Clear();
        var sqRow = row / 3;
        var sqCol = col / 3;
        for (int cell = 0; cell < 9; cell++)
        {
            var cellRow = sqRow * 3 + cell / 3;
            var cellCol = sqCol * 3 + cell % 3;
            this.possibleNumbers[cellRow][cellCol].Remove(number);
        }
    }

    private readonly List<(int Row, int Col)> taken = new(3);

    private void CheckSingleRow(bool[][] unavailable, int sqRow, int sqCol, int number)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (!unavailable[i][j])
                {
                    this.taken.Add((i, j));
                }
            }
        }

        var (firstRow, firstCol) = this.taken[0];
        if (this.taken.All(x => x.Row == firstRow))
        {
            var row = firstRow + sqRow * 3;
            this.inducedRows[row].TryAdd(number, (sqRow, sqCol));
        }

        if (this.taken.All(x => x.Col == firstCol))
        {
            var col = firstCol + sqCol * 3;
            this.inducedColumns[col].TryAdd(number, (sqRow, sqCol));
        }

        this.taken.Clear();
    }

    private static int CountAvailable(bool[][] unavailable)
    {
        var availableCount = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (unavailable[i][j])
                {
                    continue;
                }

                availableCount++;
            }
        }

        return availableCount;
    }
}

public class SudokuBacktrackingSolver(Sudoku sudoku)
{
    public Sudoku Sudoku { get; } = sudoku;

    public void Solve()
    {
        Backtrack(this, Root());
    }

    private static void Backtrack(SudokuBacktrackingSolver solver, Candidate[] candidates)
    {
        if (Reject(solver, candidates))
        {
            return;
        }

        if (Accept(solver, candidates))
        {
            var solved = solver.Apply(candidates);
            solver.Sudoku.CopyFrom(solved.Sudoku);
            return;
        }

        var s = First(solver, candidates);
        while (s is not null)
        {
            Backtrack(solver, s);
            s = Next(s);
        }
    }

    private SudokuBacktrackingSolver Apply(Candidate[] candidates)
    {
        // Create a copy of the current Sudoku grid
        var newGrid = this.Sudoku.Grid.Select(row => row.ToArray()).ToArray();

        foreach (var candidate in candidates)
        {
            newGrid[candidate.Row][candidate.Col] = candidate.Value;
        }

        return new SudokuBacktrackingSolver(new(newGrid));
    }

    private static bool Reject(SudokuBacktrackingSolver sudoku, Candidate[] candidates)
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
            if (sudoku.Sudoku.Grid[candidate.Row][col] == candidate.Value)
            {
                return true;
            }
        }

        // Check column
        for (int row = 0; row < 9; row++)
        {
            if (sudoku.Sudoku.Grid[row][candidate.Col] == candidate.Value)
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
                if (sudoku.Sudoku.Grid[row][col] == candidate.Value)
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

    private static bool Accept(SudokuBacktrackingSolver sudoku, Candidate[] candidates)
    {
        sudoku = sudoku.Apply(candidates);

        return sudoku.Sudoku.Grid.Sum(row => row.Count(cell => cell != 0)) == 81;
    }

    private static Candidate[]? First(SudokuBacktrackingSolver sudoku, Candidate[] candidates)
    {
        sudoku = sudoku.Apply(candidates);

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (sudoku.Sudoku.Grid[row][col] == 0)
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

        return candidate.Value < 9
            ? [.. candidates[..^1], candidate.NextNumber()]
            : null;
    }

    public readonly record struct Candidate(int Row, int Col, int Value)
    {
        public Candidate NextNumber() => this with { Value = this.Value + 1 };
    }
}
