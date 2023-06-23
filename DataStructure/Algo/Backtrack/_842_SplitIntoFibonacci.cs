namespace DataStructure.Algo.Backtrack;

public class _842_SplitIntoFibonacci
{
    public IList<int> SplitIntoFibonacci(string num)
    {
        var res = new List<int>();

        backtrack(res, num, 0);
        return res;
    }


    //开始的位置 前面一个值 前面第二个值
    private bool backtrack(List<int> res, string num, int index)
    {
        if (index == num.Length && res.Count >= 3)
        {
            return true;
        }

        for (int i = index; i < num.Length; i++)
        {
            if (i > index && num[index] == '0') break; //如果是0开头且不是第一个数就直接跳过
            long currnum = long.Parse(num.Substring(index, i - index + 1));
            if (currnum > int.MaxValue) break; //如果大于最大值就直接跳过
            int size = res.Count; //记录当前res长度
            if (size >= 2 && currnum > (long)res[size - 1] + (long)res[size - 2]) break; //如果当前的值，大于前两个之和
            if (size <= 1 || currnum == (long)res[size - 1] + (long)res[size - 2])
            {
                res.Add((int)currnum); //找到解了
                if (backtrack(res, num, i + 1)) //如果找到一组解就返回true
                {
                    return true;
                }

                res.RemoveAt(res.Count - 1);
            }
        }

        return false;
    }


    public static void Test()
    {
        var num = "0123";
        var splitIntoFibonacci = new _842_SplitIntoFibonacci().SplitIntoFibonacci(num);

        foreach (var i in splitIntoFibonacci)
        {
            Console.WriteLine(i);
        }
    }
}