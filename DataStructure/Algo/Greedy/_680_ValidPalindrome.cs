namespace DataStructure.Algo.Greedy;

public class _680_ValidPalindrome
{
    public bool ValidPalindrome(string s)
    {
        int left = 0, right = s.Length - 1;
        while (left < right)
        {
            if (s[left] == s[right])
            {
                left++;
                right--;
            }
            else
            {
                return ValidPalindrome(s, left + 1, right) || ValidPalindrome(s, left, right - 1);
            }
        }

        return true;
    }

    private bool ValidPalindrome(string s, int left, int right)
    {
        while (left < right)
        {
            if (s[left] != s[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }

    public static void Test()
    {
        var s = "abc";
        var validPalindrome = new _680_ValidPalindrome().ValidPalindrome(s);
        Console.WriteLine(validPalindrome);
    }
}