namespace DataStructure.Algo.Greedy;

public class _1578_MinCost
{
    public int MinCost(string colors, int[] neededTime)
    {
        int res = 0;
        int i = 0;
        while (i < colors.Length)
        {
            var c = colors[i];
            int maxCost = 0; //最大删除成本
            int SumCost = 0; //总删除成本
            while (i < colors.Length && colors[i] == c)
            {
                maxCost = Math.Max(maxCost, neededTime[i]);
                SumCost = SumCost + neededTime[i];
                i++;
            }

            res += (SumCost - maxCost);
        }

        return res;
    }

    public static void Test()
    {
        string colors = "abaac";
        int[] needTime = { 1, 2, 3, 4, 5 };
        var minCost = new _1578_MinCost().MinCost(colors,needTime);
        Console.WriteLine(minCost);
    }
}