namespace DataStructure.Algo.Backtrack.Int;

public class _90_SubsetsWithDup
{
    public static IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        var res = new List<IList<int>>();
        var path = new List<int>();
        Array.Sort(nums);
        backtrack(res, path, nums, 0);
        return res;
    }

    private static void backtrack(List<IList<int>> res, List<int> path, int[] nums, int index)
    {
        //不需要前置条件的时候就不需要
        res.Add(new List<int>(path));

        for (int i = index; i < nums.Length; i++)
        {
            if (i > index && nums[i] == nums[i - 1]) continue;
            path.Add(nums[i]);
            backtrack(res, path, nums, i + 1);
            path.RemoveAt(path.Count - 1);
        }
    }

    public static void Test()
    {
        int[] nums = { 1, 2, 2 };
        var res = SubsetsWithDup(nums);
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