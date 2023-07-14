namespace DataStructure.Algo.Greedy;

public class _767_ReorganizeString
{
    public string ReorganizeString(string s)
    {
        var charArray = s.ToCharArray();
        int len = charArray.Length;
        var count = new int[26];
        //记录字母出现的次数
        foreach (var c in charArray)
        {
            int index = c - 'a';
            count[index]++;
            if (count[index] > (len + 1) / 2) return "";//如果字符超过了字符串长度的一半就无法重构
        }

        //找到最大次数的字母
        int maxCount = 0;
        for (int i = 0; i < 26; i++)
        {
            if (count[i] > count[maxCount])
            {
                maxCount = i;
            }
        }

        //先将出现最多次数的字母放在偶数次索引上
        var chars = new char[len];
        int idx = 0;
        while (count[maxCount] > 0)
        {
            chars[idx] = (char)(maxCount + 'a');// 将字母转换为字符并放入结果数组中这里的max已经是记录的字符
            idx += 2;
            count[maxCount]--;
        }

        //将其他的放在剩余的位置
        for (int i = 0; i < 26; i++)
        {
            while (count[i] > 0)
            {
                if (idx >= len)
                {
                    idx = 1;
                }

                chars[idx] = (char)(i + 'a');
                idx += 2;
                count[i]--;
            }
        }

        return new string(chars);
    }

    public string ReorganizeString1(string s)
    {
        var charArray = s.ToCharArray();
        int len = charArray.Length;
        int[] count = new int[26];

        foreach (var c in charArray)
        {
            int index = c - 'a';
            count[index]++;
            if (count[index] > (len + 1) / 2) return "";
        }

        int maxCount = 0;
        for (int i = 0; i < 26; i++)
        {
            if (count[i] > count[maxCount])
            {
                maxCount = i;
            }
        }

        var chars = new char[len];
        int idx = 0;
        while (count[maxCount] > 0)
        {
            chars[idx] = (char)(maxCount + 'a');
            idx += 2;
            count[maxCount]--;
        }

        for (int i = 0; i < 26; i++)
        {
            while (count[i] > 0)
            {
                if (idx >= len)
                {
                    idx = 1;
                }

                chars[idx] = (char)(i + 'a');
                idx += 2;
                count[i]--;
            }
        }

        return new string(chars);
    }

    public static void Test()
    {
        var s = "aab";
        var reorganizeString = new _767_ReorganizeString().ReorganizeString1(s);
        Console.WriteLine(reorganizeString);
    }
}