using System.Text;

namespace DataStructure.Algo.Greedy;

public class _1047_RemoveDuplicates
{
    #region 栈求解

    public string RemoveDuplicates(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (stack.Count > 0 && stack.Peek() == c)
                stack.Pop();
            else
                stack.Push(c);
        }

        var sb = new StringBuilder();
        while (stack.Count > 0)
            sb.Insert(0, stack.Pop());

        return sb.ToString();
    }

    #endregion

    #region 双指针求解

    public string RemoveDuplicates1(string s)
    {
        var charArray = s.ToCharArray();
        int slow = -1, fast = 0;
        while (fast < charArray.Length)
        {
            if (slow >= 0 && charArray[fast] == charArray[slow])
            {
                slow--;
            }
            else
            {
                slow++;
                charArray[slow] = charArray[fast];
            }
            fast++;
        }

        return new string(charArray, 0, slow + 1);//注意这个
    }

    #endregion

    public static void Test()
    {
        string s = "abbaca";
        var removeDuplicates = new _1047_RemoveDuplicates().RemoveDuplicates1(s);
        Console.WriteLine(removeDuplicates);
    }
}