using System.Text;

namespace DataStructure.Algo.Backtrack.Permute;

public class test
{
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
        var path = "";
        if (digits.Length == 0)
        {
            return res;
        }

        bnacktrack(digits, res, path, phone, 0);
        return res;
    }

    private static void bnacktrack(string digits, List<string> res, string path, Dictionary<char, string> phone,
        int index)
    {
        if (index == digits.Length)
        {
            res.Add(new string(path));
            return;
        }

        //这步很重要，拿到字典里的键值对
        var temp = phone[digits[index]];
        for (int i = 0; i < temp.Length; i++)
        {
            path += temp[i];
            bnacktrack(digits, res, path, phone, index + 1);
            path = path.Remove(path.Length - 1);
        }
    }


    private int number;
    private IList<IList<string>> res;
    private int[] cols;
    private int[] rows;
    private int[] mains;
    private int[] secondry;

    public IList<IList<string>> SoloveQueens(int n)
    {
        number = n;
        res = new List<IList<string>>();
        cols = new int[n];
        rows = new int[n];
        mains = new int[2 * n - 1];
        secondry = new int[2 * n - 1];
        back(0);
        return res;
    }

    private void back(int row)
    {
        if (row >= number) return;

        for (int col = 0; col < number; col++)
        {
            if (haveoneQueen(row, col))
            {
                placeQueen(row, col);
                if (row == number - 1) add();
                back(row + 1);
                removeQueen(row, col);
            }
        }
    }

    private void add()
    {
        var awaer = new List<string>();

        for (int i = 0; i < number; i++)
        {
            int col = rows[i];
            var sb = new StringBuilder();
            for (int j = 0; j < col; ++j) sb.Append(".");
            sb.Append("Q");
            for (int j = 0; j < number - col - 1; ++j) sb.Append(".");
            awaer.Add(sb.ToString());
        }

        res.Add(new List<string>(awaer));
    }

    private void removeQueen(int row, int col)
    {
        rows[row] = 0;
        cols[col] = 0;
        mains[row - col + number - 1] = 0;
        secondry[row + col] = 0;
    }

    private void placeQueen(int row, int col)
    {
        rows[row] = col; //这步很重要;
        cols[col] = 1;
        mains[row - col + number - 1] = 1;
        secondry[row + col] = 1;
    }

    private bool haveoneQueen(int row, int col)
    {
        return cols[col] + mains[row - col + number - 1] + secondry[row + col] == 0;
    }


    private int count = 0;

    public int TotalNQueens(int n)
    {
        int number = n;
        bool[] main = new bool[2 * n + 1];
        bool[] secondrys = new bool[2 * n + 1];
        bool[] cols = new bool[n];
        backTotal(0, number, main, secondrys, cols);
        return count;
    }

    private void backTotal(int row, int number, bool[] main, bool[] secondrys, bool[] cols)
    {
        if (row >= number)
        {
            count ++;
            return;
        }

        for (int col = 0; col < number; col++)
        {
            int mai = col - row + number - 1;
            int sec = row + col;
            if (cols[col] || main[mai] || secondrys[sec])continue;
            placeTotalQueen(col,main,secondrys,cols,mai,sec);
            backTotal(row + 1, number, main, secondrys, cols);
            removeTotalQueen(col, main, secondrys, cols, mai, sec);
        }
    }

    private void removeTotalQueen(int col, bool[] main, bool[] secondrys, bool[] cols, int mai, int sec)
    {
        cols[col] = false;
        main[mai] = false;
        secondrys[sec] = false;
    }

    private void placeTotalQueen(int col, bool[] main, bool[] secondrys, bool[] cols, int mai, int sec)
    {
        cols[col] = true;
        main[mai] = true;
        secondrys[sec] = true;
    }


    public static void Test()
    {
        // var digits = "23";
        // var x = LetterCombinations(digits);
        // foreach (var i in x)
        // {
        //     Console.WriteLine(i);
        // }

        var test1 = new test();
        var x = test1.SoloveQueens(4);

        var y = test1.TotalNQueens(4);
        
        foreach (var i in x)
        {
            foreach (var k in i)
            {
                Console.Write(k);
            }

            Console.WriteLine();
        }
        
        Console.WriteLine(y);
    }
}