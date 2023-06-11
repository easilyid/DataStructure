namespace DataStructure.Algo.Backtrack.Int;

public class _39_CombinationSum
{
    public  static IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var res = new List<IList<int>>();
        var path = new List<int>();
        DFS(res, path, target, 0,candidates);
        return res;
    }

    private static void DFS(List<IList<int>> res, List<int> path, int target, int index, int[] candidates)
    {
        if(target<0)return;
        if (target == 0)
        {
            res.Add(new List<int>(path));
            return;
        }

        for (int i = index; i < candidates.Length; i++)
        {
            path.Add(candidates[i]);
            //ps:无重复所以从i 重复必须从i+1
            DFS(res,path,target-candidates[i],i,candidates);
            path.RemoveAt(path.Count-1);
        }
    }

    public static void Test()
    {
        int[] nums = { 2, 3, 6, 7 };
        var res= CombinationSum(nums, 7);
        foreach (var r in res)
        {
            foreach (var i in r)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
        }
    }
}