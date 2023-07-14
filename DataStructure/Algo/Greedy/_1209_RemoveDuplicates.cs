using System.Text;

namespace DataStructure.Algo.Greedy;

public class _1209_RemoveDuplicates
{
    public string RemoveDuplicates(string s, int k)
    {
        var stack = new Stack<(char, int)>();
        foreach (var c in s)
        {
            if (stack.Count == 0 || stack.Peek().Item1 != c)
            {
                stack.Push((c, 1));
            }
            else
            {
                //当前元素和栈顶元素相同
                //获取栈顶的值
                var top = stack.Peek();
                stack.Pop(); //出栈，然后将入新值 栈元素值+1
                stack.Push((c, top.Item2 + 1));
                if (stack.Peek().Item2 == k)
                {
                    //次数达到k就出栈
                    stack.Pop();
                }
            }
        }

        var sb = new StringBuilder();
        while (stack.Count > 0)
        {
            // 将栈中剩余的字符按照计数添加到结果字符串中
            var top = stack.Pop();
            for (int i = 0; i < top.Item2; i++)
            {
                sb.Insert(0, top.Item1);
            }
        }

        return sb.ToString();
    }


    public string RemoveDuplicates1(string s, int k)
    {
        var stack = new Stack<(char, int)>();
        foreach (var c in s)
        {
            if (stack.Count == 0 || stack.Peek().Item1 != c)
            {
                stack.Push((c, 1));
            }
            else
            {
                var topvalue = stack.Peek();
                stack.Pop();
                stack.Push((c, topvalue.Item2 + 1));
                if (stack.Peek().Item2 == k)
                {
                    stack.Pop();
                }
            }
        }

        var sb = new StringBuilder();
        while (stack.Count>0)
        {
            var top = stack.Pop();
            for (int i = 0; i < top.Item2; i++)
            {
                sb.Insert(0, top.Item1);
            }
        }
        return sb.ToString();
    }

    public static void Test()
    {
        var s = "deeedbbcccbdaa";
        int k = 3;
        var removeDuplicates = new _1209_RemoveDuplicates().RemoveDuplicates1(s, k);
        Console.WriteLine(removeDuplicates);
    }
}