namespace DataStructure.Algo.Backtrack.Int;

public class _46_Permute
{
    public static IList<IList<int>> Permute(int[] nums)
    {
        //结果集，路劲集
        IList<IList<int>> res = new List<IList<int>>();
        var path = new List<int>();
        //增加的优化代码
        var used = new bool[nums.Length];
        dfs(nums, res, path,used);
        return res;
    }

    private static void dfs(int[] nums, IList<IList<int>> res, List<int> path, bool[] used)
    {
        if (path.Count == nums.Length)
        {//当path列表的长度等于nums数组的长度时，说明目前递归深度所建的path列表已经包含了一个完整的排列。
         //此时，将当前path列表复制一份新的列表添加到res结果集合中，
            res.Add(new List<int>(path));
            return; //ps 不返回的话会导致堆栈溢出
        }

        for (int i = 0; i < nums.Length; i++)
        {
            //if (path.Contains(nums[i])) continue;//去重,将重复的值去除掉 记住是continue
            //优化后的去重 时间复杂度变on
            if(used[i])continue;
            path.Add(nums[i]);
            used[i] = true;
            dfs(nums, res, path,used);
            path.RemoveAt(path.Count - 1);
            used[i] = false;
        }
    }

    public static void Test()
    {
        int[] nums = { 1, 2, 3 };
        var res = Permute(nums);

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