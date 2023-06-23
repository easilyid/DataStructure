using System.Text;

namespace DataStructure.Algo.Backtrack.单词搜索;

public class _212_FindWords
{
    HashSet<string> set = new HashSet<string>(); //存储所有单词
    List<string> ans = new List<string>();// 存储找到的单词
    private int[][] dirs = { new[] { 1, 0 }, new[] { -1, 0 }, new[] { 0, 1 }, new[] { 0, -1 } }; // 四个方向
    private bool[,] visited;//是否访问

    public IList<string> FindWords(char[][] board, string[] words)
    {
        visited = new bool[board.Length, board[0].Length];
        foreach (var w in words)
        {
            set.Add(w);
        }

        var sb = new StringBuilder();// 用 StringBuilder 存储当前路径
        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[0].Length; col++)
            {
                visited[row, col] = true;
                sb.Append(board[row][col]);// 将当前格子的字符添加到路径中
                backtrack(board, row, col, sb);
                visited[row, col] = false;
                sb.Remove(sb.Length - 1, 1);
            }
        }

        return ans;
    }

    private void backtrack(char[][] board, int row, int col, StringBuilder sb)
    {
        if (sb.Length > 10) return;
        if (set.Contains(sb.ToString()))
        {
            ans.Add(sb.ToString());
            set.Remove(sb.ToString());//已经查找到的单词
        }

        foreach (var dir in dirs)//遍历四个方向 
        {
            int newrow = row + dir[0];
            int newcol = col + dir[1];//建立新的坐标系
            
            if (newrow < 0 || newrow >= board.Length || newcol < 0 || newcol >= board[0].Length) continue;
            if (visited[newrow, newcol]) continue;
            visited[newrow, newcol] = true;
            sb.Append(board[newrow][newcol]);
            backtrack(board, newrow, newcol, sb);
            visited[newrow, newcol] = false;
            sb.Remove(sb.Length - 1, 1);
        }
    }

    //写法超时
    public IList<string> FindWords2(char[][] board, string[] words)
    {
        var result = new List<string>();

        foreach (var word in words)
        {
            for (var row = 0; row < board.Length; row++)
            {
                for (var col = 0; col < board[0].Length; col++)
                {
                    //遍历board ,查找符合的值
                    if (board[row][col] != word[0] || !backtrack(board, row, col, word, 0)) continue;
                    result.Add(word);
                    break;
                }

                if (result.Contains(word)) break; //去重的
            }
        }

        return result;
    }

    private bool backtrack(char[][] board, int row, int col, string word, int index)
    {
        if (index == word.Length)
        {
            return true;
        }

        //看看当前位置上的值是不是符合的值
        if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length ||
            board[row][col] != word[index]) return false;
        var temp = board[row][col]; //保存值
        board[row][col] = '@'; //混淆
        //查找下一个字符
        bool res = backtrack(board, row + 1, col, word, index + 1) ||
                   backtrack(board, row - 1, col, word, index + 1) ||
                   backtrack(board, row, col + 1, word, index + 1) ||
                   backtrack(board, row, col - 1, word, index + 1);
        board[row][col] = temp; // 回溯，恢复位置上的值
        return res;
    }

    public static void Test()
    {
        char[][] board =
        {
            new char[] { 'o', 'a', 'a', 'n' },
            new char[] { 'e', 't', 'a', 'e' },
            new char[] { 'i', 'h', 'k', 'r' },
        };
        string[] word = { "oath", "pea", "eat", "rain" };

        var x = new _212_FindWords().FindWords(board, word);
        foreach (var i in x)
        {
            Console.WriteLine(i);
        }
    }
}