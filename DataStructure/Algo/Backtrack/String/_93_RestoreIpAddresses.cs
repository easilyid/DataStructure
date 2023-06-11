namespace DataStructure.Algo.Backtrack.String;

public class _93_RestoreIpAddresses
{
    public static IList<string> RestoreIpAddresses(string s)
    {
        var res = new List<string>();
        var path = "";
        if (s == null || string.IsNullOrEmpty(s))
        {
            return res;
        }

        backtrack(s, res, 0, 0, path);
        return res;
    }

    //count 192.168.1.1 四段
    private static void backtrack(string sIP, List<string> res, int index, int count, string path)
    {
        switch (count)
        {
            case > 4:
                return;
            case 4 when index == sIP.Length:
                res.Add(path);
                return;
        }

        for (var len = 1; len < 4; len++)
        {
            if(index+len>sIP.Length)break;
            //切割字符创，成一段一段的，最多4段 注意一下截取字符串的范围
            //Substring函数的第二个参数表示子串的长度
            var ipAddress = sIP.Substring(index, index + len);
            if (!isTrueIP(ipAddress)) continue; //如果是无效的就退出
            var suffix = count == 3 ? "" : ".";
            backtrack(sIP, res, index + len, count + 1, path+ ipAddress + suffix);
        }
    }

    /// <summary>
    /// ip段是不是有效的
    /// </summary>
    private static bool isTrueIP(string IpAddress)
    {
        // 长度不能大于 3
        int len = IpAddress.Length;
        if (len > 3) return false;

        // 1. ip 段如果是以 0 开始的话，那么这个 ip 段只能是 0
        // 2. ip 段需要小于等于 255
        return (IpAddress[0] == '0') ? (len == 1) : (int.Parse(IpAddress) <= 255);
    }

    public static void Test()
    {
        string s = "25525511135";
        var x = RestoreIpAddresses(s);

        foreach (var i in x)
        {
            Console.Write(i + "");
            Console.WriteLine();
        }
    }
}