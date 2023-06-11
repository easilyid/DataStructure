namespace DataStructure.Algo.Backtrack.Int;

public class _40_CombinationSum2
{
    public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        var res = new List<IList<int>>();
        var path = new List<int>();
        Array.Sort(candidates);
        bacttrack(res, path, candidates, target, 0);
        return res;
    }

    private static void bacttrack(List<IList<int>> res, List<int> path,
        int[] candidates, int target, int index)
    {
        if (target < 0) return;
        if (target == 0)
        {
            res.Add(new List<int>(path));
            return;
        }

        for (int i = index; i < candidates.Length; i++)
        {
            if (i > index && candidates[i] == candidates[i - 1]) continue;
            path.Add(candidates[i]);
            //ps: 注意要从i+1的位置开始
            bacttrack(res, path, candidates, target - candidates[i], i+1);
            path.RemoveAt(path.Count - 1);
        }
    }

    public static void Test()
    {
        int[] nums = { 10, 1, 2, 7, 6, 1, 5 };
        var res = CombinationSum2(nums, 8);
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