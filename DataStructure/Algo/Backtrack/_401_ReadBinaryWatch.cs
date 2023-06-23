namespace DataStructure.Algo.Backtrack;

public class _401_ReadBinaryWatch
{
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        int[] nums1 = { 8, 4, 2, 1 };
        int[] nums2 = { 32, 16, 8, 4, 2, 1 };
        var res = new List<string>();

        for (int i = 0; i <= turnedOn; i++)
        {//记住这里要等于tuenedOn 不然会少一种组合
            //找到i个小时的
            var hours = findCombination(i, nums1);
            //然后就是iturnedOn-i的分钟
            var minute = findCombination(turnedOn - i, nums2);

            //找到组合后进行拼接
            foreach (var hour in hours)
            {
                if (hour > 11) continue;
                foreach (var min in minute)
                {
                    if (min > 59) continue;
                    var minstr = (min < 10) ? "0" + min : min + "";
                    res.Add(hour + ":" + minstr);
                }
            }
        }
        return res;
    }

    //多少个小时 或者多少个分钟灯
    private List<int> findCombination(int count, int[] nums)
    {
        var res = new List<int>();
        backtrack(nums, count, 0, 0, res);
        return res;
    }

    //count 多少个灯 起始点 总值 
    void backtrack(int[] nums, int count, int start, int sum, List<int> res)
    {
        if (count == 0)
        {
            res.Add(sum);
            return;
        }

        for (int i = start; i < nums.Length; i++)
        {
            backtrack(nums, count - 1, i + 1, sum + nums[i], res);
        }
    }

    public static void Test()
    {
        var readBinaryWatch = new _401_ReadBinaryWatch().ReadBinaryWatch(1);
        foreach (var i in readBinaryWatch)
        {
            Console.WriteLine(i);
        }
    }
}