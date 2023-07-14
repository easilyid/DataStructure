namespace DataStructure.Algo.Greedy;

public class _1029_TwoCitySchedCost
{
    public int TwoCitySchedCost(int[][] costs)
    {
        int n = costs.Length / 2;
        int totalCost = 0;

        Array.Sort(costs, (a, b) => (a[0] - a[1]) - (b[0] - b[1]));
        for (int i = 0; i < n; i++)
        {
            totalCost += costs[i][0];
            totalCost += costs[i + n][1];
        }

        return totalCost;
    }

    public static void Test()
    {
        int[][] costs =
        {
            new int[] { 10, 20 },
            new int[] { 30, 200 },
            new int[] { 400, 50 },
            new int[] { 30, 20 }
        };

        var twoCitySchedCost = new _1029_TwoCitySchedCost().TwoCitySchedCost(costs);
        Console.WriteLine(twoCitySchedCost);
    }
}