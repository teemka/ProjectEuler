using ProjectEuler.Problems._001_100._91_100;

namespace SudokuDisplay;

public partial class Form1 : Form
{
    private readonly TextBox[,] cells = new TextBox[9, 9];
    private readonly ToolTip toolTip = new();
    private readonly Sudoku sudoku;
    public Form1()
    {
        this.InitializeComponent();
        this.sudoku = Sudoku.Parse("""
            043080250
            600000000
            000001094
            900004070
            000608000
            010200003
            820500000
            000000005
            034090710
            """);

        this.sudoku.Solve();
        this.InitializeSudokuGrid();
    }

    private void InitializeSudokuGrid()
    {
        this.Text = "Sudoku";
        this.ClientSize = new Size(410, 410);
        int cellSize = 45;

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                var cell = new TextBox
                {
                    Multiline = true,
                    TextAlign = HorizontalAlignment.Center,
                    Font = new Font("Arial", 16),
                    Size = new Size(cellSize, cellSize),
                    Location = new Point(col * cellSize, row * cellSize),
                    MaxLength = 1,
                    Text = this.sudoku.Grid[row][col] is int value && value != 0 ? value.ToString() : string.Empty,
                    Tag = (row, col)
                };

                // Highlight 3x3 blocks by alternating background color
                bool isShadedBlock = ((row / 3 + col / 3) % 2 == 0);
                if (isShadedBlock)
                    cell.BackColor = Color.LightGray;
                else
                    cell.BackColor = Color.White;

                cell.MouseEnter += this.Cell_MouseEnter;
                this.cells[row, col] = cell;
                this.Controls.Add(cell);
            }
        }
    }

    private void Cell_MouseEnter(object? sender, EventArgs e)
    {
        var hoveredCell = sender as TextBox;
        var (row, col) = (ValueTuple<int, int>) hoveredCell!.Tag!;
        if (string.IsNullOrWhiteSpace(hoveredCell.Text))
        {
            this.toolTip.SetToolTip(hoveredCell, $"Possible: {string.Join(", ", this.sudoku.possibleNumbers[row][col])}");
        }
        else
        {
            this.toolTip.SetToolTip(hoveredCell, "");
        }
    }
}
