namespace DataStructure.Algo.Greedy;

public class _322_CoinChange
{
    //贪心思路: 每次用最大面值的硬币
    //ps: 当贪心失效的时候，我们应该回溯
    public int CoinChange(int[] coins, int amount)
    {
        Array.Sort(coins);

        //排序完是升序的，我们从后往前遍历
        int res = 0;
        int amo = amount;
        for (int i = coins.Length - 1; i >= 0; i--)
        {
            int currentCount = amo / coins[i]; //需要当前面值的硬币多少个
            //amount -= currentCount * coins[i]; //这是剩下的amount
            amo -= currentCount * coins[i];

            res += currentCount; //累加当前面值
            if (amo == 0)
            {
                return res;
            }
        }
        return -1;
    }


    //回溯写法
    public int CoinChange1(int[] coin, int amount)
    {
        var res = new List<List<int>>();
        var coins = new List<int>();
        backtrack(amount, coin, coins, res); //回溯穷举所有组合
        if (res.Count == 0) return -1;

        //找到最少组合的硬币数
        int min = 0;
        for (int i = 1; i < res.Count; i++)
        {
            if (res[i].Count < res[min].Count)
                min = i;
        }

        return res[min].Count;
    }

    void backtrack(int target, int[] coin, List<int> coins, List<List<int>> res)
    {
        if (target < 0) return;
        if (target == 0)
        {
            res.Add(new List<int>(coins));
            return;
        }

        for (int i = 0; i < coin.Length; i++)
        {
            coins.Add(coin[i]);
            backtrack(target - coin[i], coin, coins, res);
            coins.RemoveAt(coins.Count - 1);
        }
    }

    public static void Test()
    {
        int[] coins = { 186,419,83,408 };
        int amount = 6249;

        var coinChange = new _322_CoinChange().CoinChange(coins, amount);
        Console.WriteLine(coinChange);
    }


    //回溯写法  优化的
    int mincoin = Int32.MaxValue;

    public int CoinChange2(int[] coin, int amount)
    {
        var coins = new List<int>();
        backtrack2(amount, coin, coins); //回溯穷举所有组合
        return mincoin == Int32.MaxValue ? -1 : mincoin;
    }

    void backtrack2(int target, int[] coin, List<int> coins)
    {
        if (target < 0) return;
        if (target == 0)
        {
            mincoin = Math.Min(mincoin, coins.Count);
            return;
        }

        for (int i = 0; i < coin.Length; i++)
        {
            if (target - coin[i] < 0) continue;
            coins.Add(coin[i]);
            backtrack2(target - coin[i], coin, coins);
            coins.RemoveAt(coins.Count - 1);
        }
    }
}