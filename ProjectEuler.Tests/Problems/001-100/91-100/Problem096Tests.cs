
using ProjectEuler.Problems._001_100._91_100;

namespace ProjectEuler.Tests.Problems._001_100._91_100;

[InheritsTests]
public class Problem096Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem096();

    protected override string Answer => "24702";

    [Test]
    public async Task Should_SolveSudoku1()
    {
        // Arrange
        var unsolved = """
            003020600
            900305001
            001806400
            008102900
            700000008
            006708200
            002609500
            800203009
            005010300
            """;

        var sudoku = Sudoku.Parse(unsolved);

        // Act
        sudoku.Solve();

        // Assert
        var actual = sudoku.ToString();

        var solved = """
            483921657
            967345821
            251876493
            548132976
            729564138
            136798245
            372689514
            814253769
            695417382
            """;

        await Assert.That(actual).IsEquivalentTo(solved);
    }

    [Test]
    public async Task Should_SolveSudoku2()
    {
        // Arrange
        var unsolved = """
            200080300
            060070084
            030500209
            000105408
            000000000
            402706000
            301007040
            720040060
            004010003
            """;

        var sudoku = Sudoku.Parse(unsolved);

        // Act
        sudoku.Solve();

        // Assert
        var actual = sudoku.ToString();

        var solved = """
            245981376
            169273584
            837564219
            976125438
            513498627
            482736951
            391657842
            728349165
            654812793
            """;

        await Assert.That(actual).IsEquivalentTo(solved);
    }
}
