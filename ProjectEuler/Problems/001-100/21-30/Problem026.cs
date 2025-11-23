namespace ProjectEuler.Problems._001_100._21_30;

/// <summary>
/// A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:
///
/// 1/2 = 0.5
/// 1/3 = 0.(3)
/// 1/4 = 0.25
/// 1/5 = 0.2
/// 1/6 = 0.1(6)
/// 1/7 = 0.(142857)
/// 1/8 = 0.125
/// 1/9 = 0.(1)
/// 1/10 = 0.1
/// Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle.It can be seen that 1/7 has a 6-digit recurring cycle.
///
/// Find the value of d &lt; 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
/// </summary>
public class Problem026 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var sequenceLength = 0;

        for (var i = 1000; i > 1; i--)
        {
            if (sequenceLength >= i)
            {
                break;
            }

            var foundRemainders = new int[i];
            var value = 1;
            var position = 0;

            while (foundRemainders[value] == 0 && value != 0)
            {
                foundRemainders[value] = position;
                value *= 10;
                value %= i;
                position++;
            }

            if (position - foundRemainders[value] > sequenceLength)
            {
                sequenceLength = position - foundRemainders[value] + 1;
            }
        }

        return Task.FromResult(sequenceLength.ToString());
    }
}
