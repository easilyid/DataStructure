namespace DataStructure.Algo.Backtrack.String;

public class _22_GenerateParenthesis
{//多看看
    public static IList<string> GenerateParenthesis(int n)
    {
        var res = new List<string>();
        var path = "";
        if (n <= 0)
        {
            return res;
        }

        backtrack(n, res, path, 0, 0);
        return res;
    }

    /// <summary>
    /// 回溯
    /// </summary>
    /// <param name="number">n</param>
    /// <param name="res">结果集</param>
    /// <param name="path">情况集</param>
    /// <param name="left">左括号数量</param>
    /// <param name="right">右括号数量</param>
    private static void backtrack(int number, List<string> res, string path, int left, int right)
    {
        
        if (path.Length == 2 * number)
        {//括号有两个，或者可以 left==n&&right==n
            res.Add(path);
            return;
        }
        
        //左括号或者右括号,不会超过n的数量
        if (left<number)
        {
            backtrack(number, res, path + "(", left + 1, right);
        }

        if (right<left)
        {
            backtrack(number, res, path + ")", left, right + 1);
        }
       
    }


    public static void Test()
    {
        var digits = "23";
        var x = GenerateParenthesis(1);
        foreach (var i in x)
        {
            Console.WriteLine(i);
        }
    }
}