namespace DataStructure.Algo.Backtrack.解数独;

public class _37_SolveSudoku
{
    public void SolveSudoku(char[][] board)
    {
        bool[,] rows = new bool[9, 10];//行 列 盒子(3X3)方块
        bool[,] cols = new bool[9, 10];
        bool[,,] boxs = new bool[3, 3, 10];

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {//将初始数字填入标记为已使用
                int num = board[i][j] - '0';
                if (num >= 1 && num <= 9)
                {
                    rows[i, num] = true;
                    cols[j, num] = true;
                    boxs[i / 3, j / 3, num] = true; //box 索引只在0-3
                }
            }
        }

        backtrack(board, 0, 0, rows, cols, boxs);
    }
    private bool backtrack(char[][] board, int row, int col, bool[,] rows, bool[,] cols, bool[,,] boxs)
    {
        if (col == board[0].Length)
        {//如果到达最后一列，将行+1.列重置
            row++; //下一列
            col = 0;
            if (row == board.Length)
            {//到最后一行了就说明找到解了
                return true;
            }
        }
        //尝试填充数字
        if (board[row][col] == '.')
        {
            for (int num = 1; num <= 9; num++)
            {
                //判断这个位置能不能填
                bool canplace = !(rows[row, num] || cols[col, num] || boxs[row / 3, col / 3, num]);
                if (canplace)
                {
                    Place(board, row, col, rows, cols, boxs, num);
                    if (backtrack(board, row, col + 1, rows, cols, boxs))
                    {//填完继续下一个位置
                        return true;
                    }
                    //如果下一个位置是false 就回溯
                    back(board, row, col, rows, cols, boxs, num);
                }
            }
        }
        else
        {//如果当前位置已经有数字，就跳到下一列
            return backtrack(board, row, col + 1, rows, cols, boxs);
        }

        return false;
    }

    //填充
    private static void Place(char[][] board, int row, int col, bool[,] rows, bool[,] cols, bool[,,] boxs, int num)
    {
        rows[row, num] = true;
        cols[col, num] = true;
        boxs[row / 3, col / 3, num] = true;
        board[row][col] = (char)('0' + num);
    }

    //回溯
    private static void back(char[][] board, int row, int col, bool[,] rows, bool[,] cols, bool[,,] boxs, int num)
    {
        board[row][col] = '.';
        rows[row, num] = false;
        cols[col, num] = false;
        boxs[row / 3, col / 3, num] = false;
    }

    public static void Test()
    {
        char[][] board = new char[][]
        {
            new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
            new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
        };

        var SolveSudoku = new _37_SolveSudoku();

        SolveSudoku.SolveSudoku(board);
    }
}