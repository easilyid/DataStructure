namespace DataStructure.Algo.Backtrack.String;

public class _131_Partition
{
    public IList<IList<string>> Partition(string s)
    {
        var res = new List<IList<string>>();
        var path = new List<string>();
        backtrack(0, s, res, path);
        return res;
    }
    private void backtrack(int startIndex, string s, List<IList<string>> res, List<string> path)
    {
        if (startIndex == s.Length)
        {
            res.Add(new List<string>(path));
            return;
        }
        for (int i = startIndex; i < s.Length; i++)
        {
            var endIndex = i;
            if (isPalindrome(s,startIndex,endIndex))//剪枝
            {
                path.Add(s.Substring(startIndex, endIndex - startIndex + 1));//注意这个
                backtrack(i + 1, s, res, path);
                path.RemoveAt(path.Count - 1);
            }
        }
    }

    //判断是否回文，两个指针
    private bool isPalindrome(string s, int startIndex, int endIndex)
    {
        while (startIndex<endIndex)
        {
            if (s[startIndex] != s[endIndex])
            {
                return false;
            }
            startIndex++;
            endIndex--;
        }
        return true;
    }

    public static void Test()
    {
        var s = "aab";
        var x=new _131_Partition().Partition(s);
        foreach (var i in x)
        {
            foreach (var r in i)
            {
                Console.Write(r+" ");
            }

            Console.WriteLine();
        }
    }
}