namespace DataStructure.Algo.Backtrack.Int;

public class _47_PermuteUnique
{
    public static IList<IList<int>> PermuteUnique(int[] nums)
    {
        var res = new List<IList<int>>();
        var path = new List<int>();
        var used = new bool[nums.Length];
        Array.Sort(nums); //防止出现1,2,1的队列，去重的基础
        DFS(nums, res, path, used);
        return res;
    }

    private static void DFS(int[] nums, List<IList<int>> res, List<int> path, bool[] used)
    {
        if (path.Count == nums.Length)
        {
            res.Add(new List<int>(path));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i]) continue;
            if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;
            path.Add(nums[i]);
            used[i] = true;
            DFS(nums,res,path,used);
            path.RemoveAt(path.Count - 1);
            used[i] = false;
        }
    }

    public static void Test()
    {
        int[] nums = { 1, 2, 1};
        var res = PermuteUnique(nums);

        foreach (var r in res)
        {
            foreach (var i in r)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}