namespace ProjectEuler.Extensions
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Checks if number is prime by using 6k ± 1 optimization
        /// </summary>
        /// <param name="n">Number to be tested.</param>
        public static bool IsPrime(this int n)
        {
            if (n < 3)
                return n > 1;
            else if (n % 2 == 0 || n % 3 == 0)
                return false;
            int i = 5;
            while (i * i <= n)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
                i += 6;
            }
            return true;
        }
    }
}
