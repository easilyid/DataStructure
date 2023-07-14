namespace DataStructure.Algo.Greedy;

public class _738_MonotoneIncreasingDigits
{
    public int MonotoneIncreasingDigits(int n)
    {
        var charArray = n.ToString().ToCharArray(); //将数字分解为数组
        int l = charArray.Length;
        int marker = charArray.Length; //标记需要修改的位置

        for (int i = l - 1; i > 0; i--)
        {
            if (charArray[i] < charArray[i - 1])
            {
                //从右往左遍历 找到不递增的位置，将他减去1再判断是否为递增
                marker = i - 1;
                charArray[i - 1]--;
            }
        }

        //将修改位置的右边全部改为9
        for (int i = marker + 1; i < charArray.Length; i++)
        {
            charArray[i] = '9'; //找到需要修改的位置的右边全部设置为9
        }

        int result = int.Parse(new string(charArray)); //字符串转为整数
        return result;
    }

    public static void Test()
    {
        int n = 332;
        var monotoneIncreasingDigits = new _738_MonotoneIncreasingDigits().MonotoneIncreasingDigits(n);
        Console.WriteLine(monotoneIncreasingDigits);
    }
}