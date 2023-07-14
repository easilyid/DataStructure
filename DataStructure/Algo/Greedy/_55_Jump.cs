namespace DataStructure.Algo.Greedy;

public class _55_Jump
{
    public bool CanJump(int[] nums)
    {
        int target = nums.Length - 1;
        for (int i = nums.Length - 1; i >= 0; --i)
        {
            if (i + nums[i] >= target)
                target = i; //如果当前位置i加上能够跳跃的步数nums[i]大于等于目标位置target，则更新目标位置为i
        }

        if (target == 0)
            return true;
        return false;
    }

    public bool CanJump2(int[] nums)
    {
        int maxPos = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > maxPos)
            {
                return false;
            }

            maxPos = Math.Max(maxPos, i + nums[i]);
        }

        return true;
    }

    public static void Test()
    {
        int[] nums = { 2, 3, 1, 1, 4 };
        int[] nums2 = { 3, 2, 1, 0, 4 };
        var canJump = new _55_Jump().CanJump2(nums2);
        Console.WriteLine(canJump);
    }
}