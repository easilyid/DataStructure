namespace DataStructure.Algo.Greedy;

public class _976_LargestPerimeter
{
    public int LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);
        for (int i = nums.Length - 1; i >= 2; i--)
        {
            if (nums[i] < nums[i - 1] + nums[i - 2]) //三角型的另外两条边相加大于第三条边
            {
                return nums[i - 1] + nums[i - 2] + nums[i];
            }
        }
        return 0;
    }

    public static void Test()
    {
        int[] nums = { 2, 1, 2 };
        var largestPerimeter = new _976_LargestPerimeter().LargestPerimeter(nums);
        Console.WriteLine(largestPerimeter);
    }
}