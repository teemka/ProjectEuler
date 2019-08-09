using System;
using System.Linq;

namespace ProjectEuler.Problem1
{
    class Program
    {
        static void Main()
        {
            int sum = Enumerable.Range(1, 999).Where(x => x % 3 == 0 || x % 5 == 0).Sum();
            Console.WriteLine(sum);
        }
    }
}
