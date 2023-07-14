namespace DataStructure.Algo.Greedy;

public class _1985_KthLargestNumber
{
    public string KthLargestNumber(string[] nums, int k)
    {
        Array.Sort(nums, (a, b) =>
            b.Length != a.Length ? b.Length - a.Length : string.CompareOrdinal(b, a));

        return nums[k - 1];
    }

    public static void Test()
    {
        string[] nums = { "3", "6", "7", "10" };
        var kthLargestNumber = new _1985_KthLargestNumber().KthLargestNumber(nums, 4);
        Console.WriteLine(kthLargestNumber);
    }
}