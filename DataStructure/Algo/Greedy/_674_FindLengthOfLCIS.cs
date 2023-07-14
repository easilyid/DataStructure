namespace DataStructure.Algo.Greedy;

public class _674_FindLengthOfLCIS
{
    public int FindLengthOfLCIS(int[] nums)
    {
        int ans = 1; // 用于存储最长连续递增子序列的长度 默认为1
        int slow = 0; //慢指针
        for (int fast = 1; fast < nums.Length; fast++)
        {
            if (nums[fast - 1] >= nums[fast])
            {
                //说明递增序列断开更新指针位置
                slow = fast;
                continue;
            }

            // 更新最长连续递增子序列的长度
            ans = Math.Max(ans, fast - slow + 1);
        }
        return ans;
    }

    public static void Test()
    {
        int[] nums = { 1, 3, 5, 4, 7 };
        var findLengthOfLcis = new _674_FindLengthOfLCIS().FindLengthOfLCIS(nums);
        Console.WriteLine(findLengthOfLcis);
    }
}