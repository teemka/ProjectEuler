using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._71_80
{
    public class Problem079 : IProblem
    {
        public async Task<string> CalculateAsync(string[] args)
        {
            var textFile = await File.ReadAllTextAsync("Problems/001-100/71-80/Problem079_keylog.txt");
            var entries = textFile.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            var digits = entries.SelectMany(x => x).Distinct();
            var values = digits.ToDictionary(x => x, x => (int?)null);
            foreach (var entry in entries)
            {
                var pairs = entry.Zip(entry.Skip(1), (x, y) => (x, y));
                foreach (var (x, y) in pairs)
                {
                    if (values[x] is null)
                    {
                        if (values[y] is null)
                        {
                            values[x] = 1;
                            values[y] = 2;
                        }
                        else
                        {
                            values[x] = values[y] - 1;
                        }

                    }
                    else
                    {
                        if (values[y] is null)
                        {
                            values[y] = values[x] + 1;
                        }
                        else if (values[y] <= values[x])
                        {
                            values[y] = values[x] + 1;
                        }
                    }
                }
            }
            var result = values.OrderBy(x => x.Value).Select(x => x.Key).Concat();
            return result;
        }
    }
}
