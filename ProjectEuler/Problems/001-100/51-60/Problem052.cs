namespace ProjectEuler.Problems._001_100._51_60;

/// <summary>
/// It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.
/// Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.
/// </summary>
public class Problem052 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        long number = 1;
        while (true)
        {
            string numberSorted = NumberWithSortedDigits(number);
            for (int i = 2; i < 7; i++)
            {
                long temp = i * number;
                if (NumberWithSortedDigits(temp) != numberSorted)
                {
                    break;
                }

                if (i == 6)
                {
                    return Task.FromResult(number.ToString());
                }
            }

            number++;
        }
    }

    private static string NumberWithSortedDigits(long number)
    {
        return string.Concat(number.ToString().Order());
    }
}
