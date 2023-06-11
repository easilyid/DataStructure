namespace DataStructure.Algo.Backtrack.Int;

public class _77_Combine
{
    public static IList<IList<int>> Combine(int n, int k)
    {
        var res = new List<IList<int>>();
        var path = new List<int>();
        if (n < 1 || k <= 0 || k > n) return res;
        dfs(n, k, 1, res, path); //题目上表面是[1,n]的k个数
        return res;
    }

    private static void dfs(int n, int k, int start, List<IList<int>> res, List<int> path)
    {
        if (path.Count == k)
        {
            res.Add(new List<int>(path));
            return;
        }

        for (int i = start; i <= n; i++)
        {
            if(path.Contains(i))continue;
            path.Add(i);
            dfs(n, k, i + 1, res, path);
            path.RemoveAt(path.Count - 1);
        }
    }


    public static void Test()
    {
        int n = 4, k = 2;
        var res= Combine(n, k);
        foreach (var result in res)
        {
            foreach (var i in result)
            {
                Console.Write(i+" ");
            }

            Console.WriteLine();
        }
    }
}