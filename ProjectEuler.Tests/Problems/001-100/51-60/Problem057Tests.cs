using Fractions;
using ProjectEuler.Problems._001_100._51_60;

namespace ProjectEuler.Tests.Problems._001_100._51_60;

[InheritsTests]
public class Problem057Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem057();

    protected override string Answer => "153";

    [Test]
    [Arguments(1, 3, 2)]
    [Arguments(2, 7, 5)]
    [Arguments(3, 17, 12)]
    [Arguments(4, 41, 29)]
    [Arguments(5, 99, 70)]
    [Arguments(6, 239, 169)]
    [Arguments(7, 577, 408)]
    [Arguments(8, 1393, 985)]
    public async Task Should_ExpandExamples(int iter, int numerator, int denominator)
    {
        // Arrange
        var expected = new Fraction(numerator, denominator);

        // Act
        var fraction = Problem057.SqaureRootOfTwoFractionApproxMinus1().ElementAt(iter - 1);
        fraction += Fraction.One;

        // Assert
        await Assert.That(fraction).IsEqualTo(expected);
    }
}
