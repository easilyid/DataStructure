namespace DataStructure.Algo.Greedy;

public class _409_LongestPalindrome
{
    public int LongestPalindrome(string s)
    {
        int[] counter = new int[128];//字符总个数就是128
        foreach (var c in s)
        {
            counter[c]++;//统计字符出现的次数
        }

        int ans = 0;
        foreach (var v in counter)
        {
            ans += v / 2 * 2; // 将出现次数为偶数的字符加入回文串
            if (v % 2 == 1 && ans % 2 == 0)
                ans++; // 如果出现次数为奇数的字符，且回文串长度为偶数，则将该字符作为回文串的中心
        }

        return ans;
    }

    public static void Test()
    {
        var s = "abccccdd";
        var longestPalindrome = new _409_LongestPalindrome().LongestPalindrome(s);
        Console.WriteLine(longestPalindrome);
    }
}