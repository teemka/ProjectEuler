using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._31_40
{
    /// <summary>
    /// In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:

    /// 1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
    /// It is possible to make £2 in the following way:
    /// 
    /// 1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
    /// How many different ways can £2 be made using any number of coins?
    /// </summary>
    public class Problem031 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            var coins = new int[] { 1, 2, 5, 10, 20, 50, 100, 200 };
            int amount = 200;

            int ways(int target, int avc)
            {
                if (avc <= 0)
                    return 1;
                int res = 0;
                while (target >= 0)
                {
                    res += ways(target, avc - 1);
                    target -= coins[avc];
                }
                return res;
            }
            var result = ways(amount, coins.Length);
            return Task.FromResult(result.ToString());
        }
    }
}
