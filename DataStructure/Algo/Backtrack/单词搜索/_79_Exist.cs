namespace DataStructure.Algo.Backtrack.单词搜索;

public class _79_Exist
{
    bool[,] visited; //是否已经访问
    private char[][] boxs;
    private string words;
    public bool Exist(char[][] board, string word)
    {
        boxs = board;
        words = word;
        visited = new bool[board.Length, board[0].Length];
        //初始化遍历行列 如果找到第一个字符，调用 backtrack 函数搜索剩余字符
        
        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[0].Length; col++)
            {
                if (board[row][col] == word[0]&&backtrack(row, col, 0))
                { 
                    return true;
                }
            }
        }
        return false;
    }
    private bool backtrack(int row, int col, int index)
    {
        if (index == words.Length) return true;//说明遍历到结尾了
        if (row < 0 || row >= boxs.Length || col < 0 || col >= boxs[0].Length
            || visited[row, col] || boxs[row][col] != words[index])//查看合法性 ,
        {
            return false;
        }
        visited[row, col] = true;//上面都不满足的话，说明这个位置是合法的，就设置为已经访问过了
        
        //回溯遍历各个节点 ,搜索下一个字符
        bool res = backtrack(row + 1, col, index + 1) ||
                   backtrack(row - 1, col, index + 1) ||
                   backtrack(row, col + 1, index + 1) ||
                   backtrack(row, col - 1, index + 1);
        
        visited[row, col] = false;//回溯, 恢复单元格状态
        return res;
    }

    public static void Test()
    {
        char[][] board =
        {
            new char[] { 'A', 'B', 'C', 'E' },
            new char[] { 'S', 'F', 'C', 'S' },
            new char[] { 'A', 'D', 'E', 'E' },
        };
        string word = "ABCCED";

      var  x=new _79_Exist().Exist(board, word);
      Console.WriteLine(x);
    }
}