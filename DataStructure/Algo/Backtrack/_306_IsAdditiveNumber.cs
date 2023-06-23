namespace DataStructure.Algo.Backtrack;

public class _306_IsAdditiveNumber
{
    public bool IsAdditiveNumber(string num)
    {
        if (num.Length < 3)
        {
            return false;
        }

        return backtrack(num, 0, 0, 0, 0);
    }

    //当前值 记录两个数字的和 记录当前已经找到的累加数的个数count 开始索引
    private bool backtrack(string num, long sum, int prev, int count, int startIndex)
    {
        if (startIndex == num.Length)
        {
            return count >= 3;
        }

        long current = 0;
        for (int i = startIndex; i < num.Length; i++)
        {
            if (i > startIndex && num[startIndex] == '0') break; //如果当前位是 0，但不是第一位，跳过。
            
            current = current * 10 + num[i] - '0';
            if (count >= 2)
            {
                if (current < sum) continue;
                else if (current > sum) break;
            }

            if (backtrack(num, prev + current, (int)current, count + 1, i + 1))
            {
                //查找下一位
                return true;
            }
        }

        return false;
    }

    public static void Test()
    {
        string num = "8917";
        var isAdditiveNumber = new _306_IsAdditiveNumber().IsAdditiveNumber(num);
        Console.WriteLine(isAdditiveNumber);
    }
}