using ProjectEuler.Problems._101_200._101_110;

namespace ProjectEuler.Tests;

public class Problem107Tests
{
    [Fact]
    public async Task Should_SolveExample()
    {
        var exampleLines = await File.ReadAllLinesAsync("p107_network_example.txt");
        var result = Problem107.Solve(exampleLines);
        result.Should().Be(150);
    }

    [Fact]
    public async Task Should_CalculateAnswer()
    {
        var answer = await new Problem107().CalculateAsync(Array.Empty<string>());
        answer.Should().Be("259679");
    }
}
