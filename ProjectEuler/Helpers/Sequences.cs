namespace ProjectEuler.Helpers
{
    public static class Sequences
    {
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
}
