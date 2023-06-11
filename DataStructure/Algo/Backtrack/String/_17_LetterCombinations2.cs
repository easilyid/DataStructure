namespace DataStructure.Algo.Backtrack.String;

public class _17_LetterCombinations2
{
    //多看看
    public static IList<string> LetterCombinations2(string digits)
    {
        Dictionary<char, string> phone = new()
        {
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" }
        };

        var res = new List<string>();
        var path = "";

        if (string.IsNullOrEmpty(digits)) return res;

        backtrack2(phone, digits, 0, res, path);
        return res;
    }

    private static void backtrack2(Dictionary<char, string> phone, string digits,
        int index, List<string> res, string path)
    {
        if (index == digits.Length)
        {
            res.Add(path);
            return;
        }
        
        char digit = digits[index];
        string letters = phone[digit];
        
        for (int i = 0; i < letters.Length; i++)
        {
            backtrack2(phone,digits, index + 1,  res,path+ letters[i]);
        }
    }

    public static void Test()
    {
        var digits = "23";
        var x = LetterCombinations2(digits);
        foreach (var i in x)
        {
            Console.WriteLine(i);
        }
    }
}