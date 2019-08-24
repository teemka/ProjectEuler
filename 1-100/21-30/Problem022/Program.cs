using System;
using System.IO;
using System.Linq;

namespace Problem022
{
    class Program
    {
        /// <summary>
        /// Using names.txt, a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order.
        /// Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.
        /// 
        /// For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list.So, COLIN would obtain a score of 938 × 53 = 49714.
        /// 
        /// What is the total of all the name scores in the file?
        /// </summary>
        static void Main()
        {
            string file = File.ReadAllText("names.txt");
            string[] names = file.Split(",").Select(x => x.Trim('"')).OrderBy(x => x).ToArray();

            int sum = names.Select((name, i) => name.Sum(c => c - 64) * (i + 1)).Sum();
            Console.WriteLine(sum);
        }
    }
}
