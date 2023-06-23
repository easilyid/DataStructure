namespace DataStructure.Algo.Backtrack.解数独;

public class _36_IsValidSudoku
{
    public bool IsValidSudoku(char[][] board)
    {
        bool[,] rows = new bool[9, 10];
        bool[,] cols = new bool[9, 10];
        bool[,,] boxs = new bool[3, 3, 10];
        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[0].Length; col++)
            {
                if (board[row][col] != '.')
                {
                    int num = board[row][col] - '0';
                    if (rows[row, num] || cols[col, num] || boxs[row / 3, col / 3, num]) return false;
                    else
                    {
                        rows[row, num] = true;
                        cols[col, num] = true;
                        boxs[row / 3, col / 3, num] = true;
                    }
                }
            }
        }

        return true;
    }
}