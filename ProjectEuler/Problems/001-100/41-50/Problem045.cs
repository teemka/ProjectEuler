namespace ProjectEuler.Problems._001_100._41_50;

/// <summary>
/// https://projecteuler.net/problem=45
/// Answer: 1533776805
/// </summary>
public class Problem045 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var triangleNumbers = Sequences.TriangleNumbers(286).GetEnumerator();
        var pentagonalNumbers = Sequences.PentagonalNumbers(166).GetEnumerator();
        var hexagonalNumbers = Sequences.HexagonalNumbers(144).GetEnumerator();

        // initialize the enumerators
        triangleNumbers.MoveNext();
        pentagonalNumbers.MoveNext();
        hexagonalNumbers.MoveNext();

        long result;
        while (true)
        {
            while (pentagonalNumbers.Current < hexagonalNumbers.Current)
            {
                pentagonalNumbers.MoveNext();
            }

            while (triangleNumbers.Current < pentagonalNumbers.Current)
            {
                triangleNumbers.MoveNext();
            }

            if (triangleNumbers.Current == pentagonalNumbers.Current && triangleNumbers.Current == hexagonalNumbers.Current)
            {
                result = triangleNumbers.Current;
                break;
            }

            hexagonalNumbers.MoveNext();
        }

        return Task.FromResult(result.ToString());
    }
}
