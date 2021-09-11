namespace ProjectEuler.Problems._001_100._41_50;

/// <summary>
/// https://projecteuler.net/problem=45
/// Answer: 
/// </summary>
public class Problem045 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var triangleNumbers = TriangleNumbers(286).GetEnumerator();
        var pentagonalNumbers = PentagonalNumbers(166).GetEnumerator();
        var hexagonalNumbers = HexagonalNumbers(144).GetEnumerator();

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

    public static IEnumerable<long> TriangleNumbers(long n = 1)
    {
        while (true)
        {
            yield return n * (n + 1) / 2;
            n++;
        }
    }

    public static IEnumerable<long> PentagonalNumbers(long n = 1)
    {
        while (true)
        {
            yield return n * ((3 * n) - 1) / 2;
            n++;
        }
    }

    public static IEnumerable<long> HexagonalNumbers(long n = 1)
    {
        while (true)
        {
            yield return n * ((2 * n) - 1);
            n++;
        }
    }
}
