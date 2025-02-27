﻿using ProjectEuler.Problems._701_800._711_720;

namespace ProjectEuler.Tests.Problems._701_800._721_730;

public class Problem719Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem719();

    protected override string Answer => "128088830547982";

    [Theory]
    [InlineData(81)]
    [InlineData(6724)]
    [InlineData(8281)]
    [InlineData(9801)]
    public void Should_Split_ReturnTrue(long number)
    {
        // Arrange
        var sqrt = (long)Math.Sqrt(number);

        // Act
        var result = Problem719.TrySplit(sqrt, number);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(64)]
    public void Should_Split_ReturnFalse(long number)
    {
        // Arrange
        var sqrt = (long)Math.Sqrt(number);

        // Act
        var result = Problem719.TrySplit(sqrt, number);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "10000" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        Assert.Equal("41333", result);
    }
}
