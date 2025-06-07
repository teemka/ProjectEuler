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
        var lines = await File.ReadAllLinesAsync("Problems/001-100/91-100/p096_sudoku.txt");
        var sudokus = lines.Chunk(10)
            .Select(chunk => Sudoku.Parse(chunk.Skip(1)))
            .ToList();

        var i = 0;
        foreach (var sudoku in sudokus)
        {
            //Console.WriteLine(sudoku);
            sudoku.Solve();
            Console.WriteLine($"Sudoku #{++i}:");
            Console.WriteLine(sudoku);
            Console.WriteLine();
        }

        return "Dupa";
    }
}

public class Sudoku
{
    private readonly List<((int Row, int Col) Coordinates, int Number)> solveHistory = [];
    private readonly HashSet<int>[] rows = new HashSet<int>[9];
    private readonly HashSet<int>[] columns = new HashSet<int>[9];
    private readonly Dictionary<int, (int SqRow, int SqCol)>[] inducedRows = new Dictionary<int, (int SqRow, int SqCol)>[9];
    private readonly Dictionary<int, (int SqRow, int SqCol)>[] inducedColumns = new Dictionary<int, (int SqRow, int SqCol)>[9];
    private readonly HashSet<int>[][] squares = new HashSet<int>[3][];
    public readonly HashSet<int>[][] possibleNumbers = new HashSet<int>[9][];
    private int solvedCells;

    public Sudoku(int[][] grid)
    {
        this.Grid = grid;

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

        for (int i = 0; i < 3; i++)
        {
            this.squares[i] = new HashSet<int>[3];
            for (int j = 0; j < 3; j++)
            {
                this.squares[i][j] = [];
            }
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                var value = this.Grid[i][j];
                if (value == 0)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        this.possibleNumbers[i][j].Add(k);
                    }

                    continue;
                }

                this.solvedCells++;
                this.rows[i].Add(value);
                this.columns[j].Add(value);
                this.squares[i / 3][j / 3].Add(value);
            }
        }
    }

    public int[][] Grid { get; }

    public void Solve()
    {
        var tries = 1_000_000;
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
            //if (this.squares[sqRow][sqCol].Contains(number))
            //{
            //    goto Increment;
            //}

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
                    var value = this.Grid[row][col];
                    if (value != 0)
                    {
                        unavailable[i][j] = true;
                        //continue;
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

                    if (this.inducedColumns[col].TryGetValue(number, out var origin))
                    {
                        if (origin.SqRow != sqRow || origin.SqCol != sqCol)
                        {
                            this.RemovePossibility(number, row, col);
                            unavailable[i][j] = true;
                        }
                    }

                    if (this.inducedRows[row].TryGetValue(number, out var origin2))
                    {
                        if (origin2.SqRow != sqRow || origin2.SqCol != sqCol)
                        {
                            this.RemovePossibility(number, row, col);
                            unavailable[i][j] = true;
                        }
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

        Increment:
            if (this.solvedCells == 81)
            {
                return;
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
                //var solvedCell = 
                //    this.CheckSinglePossibilitySquare() ||
                //    this.CheckSinglePossibilityRow() ||
                //    this.CheckSinglePossibilityColumn();
            }

            tries--;
            if (tries <= 0)
            {
                return;
            }
        }
    }

    private readonly Dictionary<int, int> countsSquare = [];
    private bool CheckSinglePossibilitySquare()
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
                return true;
            }
        }

        return false;
    }

    private readonly Dictionary<int, int> countsRow = [];
    private bool CheckSinglePossibilityRow()
    {
        for (int row = 0; row < 9; row++)
        {
            this.countsRow.Clear();
            for (int col = 0; col < 9; col++)
            {
                foreach (var possibleNumber in this.possibleNumbers[row][col])
                {
                    if (!this.countsRow.TryAdd(possibleNumber, 1))
                    {
                        this.countsRow[possibleNumber]++;
                    }
                }
            }

            var found = 0;
            foreach (var kvp in this.countsRow)
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

            for (var col = 0; col < 9; col++)
            {
                if (!this.possibleNumbers[row][col].Contains(found))
                {
                    continue;
                }

                this.CellSolved(found, row, col);
                return true;
            }
        }

        return false;
    }

    private readonly Dictionary<int, int> countsColumn = [];
    private bool CheckSinglePossibilityColumn()
    {
        for (int col = 0; col < 9; col++)
        {
            this.countsColumn.Clear();
            for (int row = 0; row < 9; row++)
            {
                foreach (var possibleNumber in this.possibleNumbers[row][col])
                {
                    if (!this.countsColumn.TryAdd(possibleNumber, 1))
                    {
                        this.countsColumn[possibleNumber]++;
                    }
                }
            }

            var found = 0;
            foreach (var kvp in this.countsColumn)
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

            for (var row = 0; row < 9; row++)
            {
                if (!this.possibleNumbers[row][col].Contains(found))
                {
                    continue;
                }

                this.CellSolved(found, row, col);
                return true;
            }
        }

        return false;
    }

    private void RemovePossibility(int number, int row, int col)
    {
        this.possibleNumbers[row][col].Remove(number);
    }

    private void CellSolved(int number, int row, int col)
    {
        Debug.Assert(this.Grid[row][col] == 0, "Cell should be empty before solving.");
        Debug.Assert(this.possibleNumbers[row][col].Contains(number), "Number should be a possible number for the cell.");
        Debug.Assert(!this.squares[row / 3][col / 3].Contains(number), "Number should not be in square.");
        Debug.Assert(!this.columns[col].Contains(number), "Column is already taken.");
        Debug.Assert(!this.rows[row].Contains(number), "Row is already taken.");
        this.solvedCells++;
        this.possibleNumbers[row][col].Clear();
        this.Grid[row][col] = number;
        this.rows[row].Add(number);
        this.columns[col].Add(number);
        this.squares[row / 3][col / 3].Add(number);
        var sqRow = row / 3;
        var sqCol = col / 3;
        for (int cell = 0; cell < 9; cell++)
        {
            var cellRow = sqRow * 3 + cell / 3;
            var cellCol = sqCol * 3 + cell % 3;
            this.possibleNumbers[cellRow][cellCol].Remove(number);
        }

        this.solveHistory.Add(((row, col), number));
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

    public static Sudoku Parse(string chunk) => Parse(chunk.Split(Environment.NewLine));

    public static Sudoku Parse(IEnumerable<string> chunk)
    {
        return new([.. chunk.Select(line => line.Select(c => c.ToInt()).ToArray())]);
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
