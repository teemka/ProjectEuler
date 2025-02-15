using Fractions;
using ProjectEuler.Problems._001_100._51_60;

namespace ProjectEuler.Tests.Problems._001_100._51_60;

public class Problem057Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem057();

    protected override string Answer => "153";

    [Theory]
    [InlineData(1, 3, 2)]
    [InlineData(2, 7, 5)]
    [InlineData(3, 17, 12)]
    [InlineData(4, 41, 29)]
    [InlineData(5, 99, 70)]
    [InlineData(6, 239, 169)]
    [InlineData(7, 577, 408)]
    [InlineData(8, 1393, 985)]
    public void Should_ExpandExamples(int iter, int numerator, int denominator)
    {
        // Arrange
        var expected = new Fraction(numerator, denominator);

        // Act
        var fraction = Problem057.SqaureRootOfTwoFractionApproxMinus1().ElementAt(iter - 1);
        fraction += Fraction.One;

        // Assert
        Assert.Equal(expected, fraction);
    }
}
