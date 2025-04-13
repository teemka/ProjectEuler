using ProjectEuler.Problems._001_100._51_60;

namespace ProjectEuler.Tests.Problems._001_100._51_60;

public class Problem054Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem054();

    protected override string Answer => "376";

    [Theory]
    [InlineData(new[] {"5H", "5C", "6S", "7S", "KD"}, new[] {"2C", "3S", "8S", "8D", "TD"}, -1)]
    [InlineData(new[] {"5D", "8C", "9S", "JS", "AC"}, new[] {"2C", "5C", "7D", "8S", "QH"}, 1)]
    [InlineData(new[] {"2D", "9C", "AS", "AH", "AC"}, new[] {"3D", "6D", "7D", "TD", "QD"}, -1)]
    [InlineData(new[] {"4D", "6S", "9H", "QH", "QC"}, new[] {"3D", "6D", "7H", "QD", "QS"}, 1)]
    [InlineData(new[] {"2H", "2D", "4C", "4D", "4S"}, new[] {"3C", "3D", "3S", "9S", "9D"}, 1)]
    [InlineData(new[] {"3C", "3D", "4C", "4D", "5D"}, new[] {"3H", "3S", "4H", "4S", "6D"}, -1)]
    [InlineData(new[] {"3C", "3D", "4C", "4D", "5C"}, new[] {"2H", "2S", "4H", "4S", "6D"}, 1)]
    [InlineData(new[] {"3C", "3D", "4C", "4D", "2C"}, new[] {"3H", "3S", "4H", "4S", "2D"}, 0)]
    [InlineData(new[] {"3C", "3D", "3H", "3S", "2C"}, new[] {"3H", "3S", "4H", "4S", "2D"}, 1)]
    [InlineData(new[] {"TC", "JC", "QC", "KC", "AC"}, new[] {"9H", "TH", "JH", "QH", "KH"}, 1)]
    public void ShouldSolveExample(string[] player1, string[] player2, int expected)
    {
        // Arrange
        var player1Hand = new Problem054.Hand(player1.Select(x => new Problem054.Card(x[0], x[1])).ToArray());
        var player2Hand = new Problem054.Hand(player2.Select(x => new Problem054.Card(x[0], x[1])).ToArray());

        // Act
        var result = player1Hand.CompareTo(player2Hand);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData([new[] { "AC", "AD" }])] // too few cards
    [InlineData([new[] { "2C", "3D", "4C", "5C", "5C" }])] // duplicated card
    public void ShouldThrowException(string[] cards)
    {
        // Arrange
        var c = cards.Select(x => new Problem054.Card(x[0], x[1])).ToArray();

        // Act
        var act = () => new Problem054.Hand(c);

        // Assert
        Assert.Throws<ArgumentException>(act);

    }
}
