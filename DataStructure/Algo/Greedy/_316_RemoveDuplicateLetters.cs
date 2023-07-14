using System.Text;

namespace DataStructure.Algo.Greedy;

public class _316_RemoveDuplicateLetters
{
    public string RemoveDuplicateLetters(string s)
    {
        int[] lastIndex = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            lastIndex[s[i] - 'a'] = i; //记录字符减去a ASCII码的整数 0-25
        }

        var stack = new Stack<char>();
        bool[] isExists = new bool[26];
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (isExists[c - 'a']) continue;//很重要 如果字符已经存在栈中 就跳过
            while (stack.Count > 0 && stack.Peek() > c
                                   && lastIndex[stack.Peek() - 'a'] > i)
            {
                //栈顶元素大于当前元素，切当前栈顶元素在后续还会出现 就删除栈顶的元素
                var pop = stack.Pop();
                isExists[pop - 'a'] = false;
            }

            stack.Push(c);
            isExists[c - 'a'] = true;
        }

        var sb = new StringBuilder();
        while (stack.Count > 0)
        {
            sb.Insert(0, stack.Pop());
        }

        return sb.ToString();
    }

    public static void Test()
    {
        string s = "bcabc";
        var removeDuplicateLetters = new _316_RemoveDuplicateLetters().RemoveDuplicateLetters(s);
        Console.WriteLine(removeDuplicateLetters);
    }
}