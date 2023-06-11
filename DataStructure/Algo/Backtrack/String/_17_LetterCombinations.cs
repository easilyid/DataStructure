namespace DataStructure.Algo.Backtrack.String;

public class _17_LetterCombinations
{//多看看
    public static IList<string> LetterCombinations(string digits)
    {
        Dictionary<char, string> phone = new Dictionary<char, string>();
        phone.Add('2', "abc");
        phone.Add('3', "def");
        phone.Add('4', "ghi");
        phone.Add('5', "jkl");
        phone.Add('6', "mno");
        phone.Add('7', "pqrs");
        phone.Add('8', "tuv");
        phone.Add('9', "wxyz");
        
        var res = new List<string>();
        var path = new string("");

        if (digits.Length==0)
        {
            return res;
        }
        backtrack(phone, digits, 0, res, path);
        return res;
        
    }

    private static void backtrack(Dictionary<char, string> phone, string digits, int index, List<string> res,
        string path)
    {
        if (index == digits.Length)
        {
            res.Add(new string(path));
            return;
        }

        var temp = phone[digits[index]];
        for (int i = 0; i < temp.Length; i++)
        {
            path += temp[i];
            backtrack(phone, digits, index + 1, res, path);
            path = path.Remove(path.Length - 1);
        }
    }

    public static void Test()
    {
        var digits = "23";
        var x = LetterCombinations(digits);
        foreach (var i in x)
        {
            Console.WriteLine(i);
        }
    }
    
}