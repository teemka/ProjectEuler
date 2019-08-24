using System;

namespace Problem019
{
    class Program
    {
        /// <summary>
        /// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
        /// </summary>
        static void Main()
        {
            var date = new DateTime(1901, 1, 1);
            var end = new DateTime(2000, 12, 31);
            int sundayCount = 0;
            while (date < end)
            {
                if (date.DayOfWeek == DayOfWeek.Sunday)
                    sundayCount++;
                date = date.AddMonths(1);
            }
            Console.WriteLine(sundayCount);
        }
    }
}
