using ProjectEuler.Problems._001_100._51_60;

namespace ProjectEuler.Tests.Problems._001_100._51_60;

[InheritsTests]
public class Problem054Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem054();

    protected override string Answer => "376";

    [Test]
    [Arguments(new[] { "5H", "5C", "6S", "7S", "KD" }, new[] { "2C", "3S", "8S", "8D", "TD" }, -1)]
    [Arguments(new[] { "5D", "8C", "9S", "JS", "AC" }, new[] { "2C", "5C", "7D", "8S", "QH" }, 1)]
    [Arguments(new[] { "2D", "9C", "AS", "AH", "AC" }, new[] { "3D", "6D", "7D", "TD", "QD" }, -1)]
    [Arguments(new[] { "4D", "6S", "9H", "QH", "QC" }, new[] { "3D", "6D", "7H", "QD", "QS" }, 1)]
    [Arguments(new[] { "2H", "2D", "4C", "4D", "4S" }, new[] { "3C", "3D", "3S", "9S", "9D" }, 1)]
    [Arguments(new[] { "3C", "3D", "4C", "4D", "5D" }, new[] { "3H", "3S", "4H", "4S", "6D" }, -1)]
    [Arguments(new[] { "3C", "3D", "4C", "4D", "5C" }, new[] { "2H", "2S", "4H", "4S", "6D" }, 1)]
    [Arguments(new[] { "3C", "3D", "4C", "4D", "2C" }, new[] { "3H", "3S", "4H", "4S", "2D" }, 0)]
    [Arguments(new[] { "3C", "3D", "3H", "3S", "2C" }, new[] { "3H", "3S", "4H", "4S", "2D" }, 1)]
    [Arguments(new[] { "TC", "JC", "QC", "KC", "AC" }, new[] { "9H", "TH", "JH", "QH", "KH" }, 1)]
    public async Task ShouldSolveExample(string[] player1, string[] player2, int expected)
    {
        // Arrange
        var player1Hand = new Problem054.Hand([.. player1.Select(x => new Problem054.Card(x[0], x[1]))]);
        var player2Hand = new Problem054.Hand([.. player2.Select(x => new Problem054.Card(x[0], x[1]))]);

        // Act
        var result = player1Hand.CompareTo(player2Hand);

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    [Arguments([new[] { "AC", "AD" }])] // too few cards
    [Arguments([new[] { "2C", "3D", "4C", "5C", "5C" }])] // duplicated card
    public async Task ShouldThrowException(string[] cards)
    {
        // Arrange
        var c = cards.Select(x => new Problem054.Card(x[0], x[1])).ToArray();

        // Act
        Problem054.Hand Act() => new(c);

        // Assert
        await Assert.That(Act).ThrowsExactly<ArgumentException>();

    }
}
