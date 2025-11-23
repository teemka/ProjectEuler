namespace ProjectEuler.Problems._001_100._11_20;

/// <summary>
/// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
/// </summary>
public class Problem019 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var date = new DateTime(1901, 1, 1);
        var end = new DateTime(2000, 12, 31);
        var sundayCount = 0;
        while (date < end)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                sundayCount++;
            }

            date = date.AddMonths(1);
        }

        return Task.FromResult(sundayCount.ToString());
    }
}
