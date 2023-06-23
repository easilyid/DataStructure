namespace DataStructure.Algo.Backtrack;

public class _301_RemoveInvalidParentheses
{
    //存储符合条件的字符
    private HashSet<string> Set = new HashSet<string>();
    private int max, len;// max 用于记录最多可以删除的括号数，len 用于记录当前最长的符合条件的字符串长度

    public IList<string> RemoveInvalidParentheses(string s)
    {
        int left = 0, right = 0;//统计左右字符的数量
        foreach (var c in s.ToCharArray())
        {
            if (c == '(') left++;
            else if (c == ')') right++;
        }

        max = Math.Min(left, right);// 最多可以删除的括号数为左右括号数量的较小值
        backtrack(s, 0, "", 0);
        return new List<string>(Set);
    }

    private void backtrack(string s, int u, string curr, int count)
    {
        if (count < 0 || count > max) return;//如果当前 count 小于 0 或大于最多可以删除的括号数，直接返回
        if (u == s.Length)//已经遍历完字符串
        {
            if (count == 0 && curr.Length >= len)
            {
                if (curr.Length > len) Set.Clear();// 如果当前字符串长度大于当前最长的符合条件的字符串长度，清空 Set
                len = curr.Length;
                Set.Add(curr); // 将当前字符串添加到 Set 中
            }
            return;
        }

        char c = s[u];

        if (c == '(') {
            backtrack(s, u + 1, curr + c, count + 1);
            backtrack(s, u + 1, curr, count);
        }
        else if (c == ')') {
            backtrack(s, u + 1, curr + c, count - 1);
            backtrack(s, u + 1, curr, count);
        }
        else
            backtrack(s, u + 1, curr + c, count );
    }

    public static void Test()
    {
        var s = "()())()";
        var removeInvalidParentheses = new _301_RemoveInvalidParentheses().RemoveInvalidParentheses(s);

        foreach (var res in removeInvalidParentheses)
        {
            Console.WriteLine(res);
        }
    }
}