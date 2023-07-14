namespace DataStructure.Algo.Greedy;

public class _330_MinPatches
{
    public int MinPatches(int[] nums, int n)
    {
        int patches = 0;//要补的数量
        long miss = 1;//想要补的数字
        int i = 0;
        while (miss <= n)
        {//不能越过范围
            if (i < nums.Length && nums[i] <= miss)
            {// 如果当前数字在nums中，并且小于等于miss，则可以用当前数字表示miss
                miss += nums[i];
                i++;
            }
            else
            {
                patches++;
                miss += miss;// 否则，需要补充miss这个数字，并更新补充的数字数量
            }
        }

        return patches;
    }
    

    public static void Test()
    {
        var nums = new[] { 1, 3 };
        int n = 6;

        var minPatches = new _330_MinPatches().MinPatches(nums, n);
        Console.WriteLine(minPatches);
    }
}