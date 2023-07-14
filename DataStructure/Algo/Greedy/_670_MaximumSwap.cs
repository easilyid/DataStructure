namespace DataStructure.Algo.Greedy;

public class _670_MaximumSwap
{
    public int MaximumSwap(int num)
    {
        //贪心策略： 找最大的位数字和第一位交换就行了
        var chars = num.ToString().ToCharArray();
        var last = new int[10]; // 记录每个数字最后出现的位置
        for (int i = 0; i < chars.Length; i++)
        {
            last[chars[i] - '0'] = i;
        }
        for (int i = 0; i < chars.Length; i++)
        {
            for (int d = 9; d > chars[i] - '0'; d--)
            {
                // 从9开始向前遍历，找到比当前字符大的最大数字
                if (last[d] > i)
                {
                    //如果找到的数字在当前位置之后还有出现过
                    (chars[i], chars[last[d]]) = (chars[last[d]], chars[i]);
                    return int.Parse(new string(chars));
                }
            }
        }

        return num;
    }

    public int MaximumSwap1(int num)
    {
        var charArray = num.ToString().ToCharArray();
        int len = charArray.Length;
        int max = num;
        for (int i = 0; i < len; i++)
        {
            for (int j = i + 1; j < len; j++)
            {
                (charArray[i], charArray[j]) = (charArray[j], charArray[i]);
                max = Math.Max(max, int.Parse(new string(charArray))); //不停的交换然后保留最大值
                (charArray[i], charArray[j]) = (charArray[j], charArray[i]); //恢复原数组 继承下一轮的交换然后判断大小
            }
        }

        return max;
    }

    public static void Test()
    {
        int num = 98368;
        var maximumSwap1 = new _670_MaximumSwap().MaximumSwap(num);
        Console.WriteLine(maximumSwap1);
    }
}