using System.Text;

namespace DataStructure.Algo.Greedy;

public class _1081_SmallestSubsequence
{
    public string SmallestSubsequence(string s)
    {
        int[] lastIndex = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            lastIndex[s[i] - 'a'] = i;
        }

        var stack = new Stack<char>();
        var isExists = new bool[26];
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (isExists[c - 'a']) continue;
            while (stack.Count > 0 && stack.Peek() > c
                                   && lastIndex[stack.Peek() - 'a'] > i)
            {
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
        string s = "cbacdcbc";
        var smallestSubsequence = new _1081_SmallestSubsequence().SmallestSubsequence(s);
        Console.WriteLine(smallestSubsequence);
    }
}