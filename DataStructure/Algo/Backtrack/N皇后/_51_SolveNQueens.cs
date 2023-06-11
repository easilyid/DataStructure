using System.Text;

namespace DataStructure.Algo.Backtrack.N皇后;

public class _51_SolveNQueens
{
    private int number;
    private int[] rows;
    private int[] cols;
    private int[] mains;
    private int[] secondary;
    private IList<IList<string>> res;

    public IList<IList<string>> SolveNQueens(int n)
    {
        number = n; //几个皇后
        rows = new int[n]; //存放皇后的位置
        cols = new int[n]; //该列
        mains = new int[2 * n - 1]; //主对角线
        secondary = new int[2 * n - 1]; //次对角线
        res = new List<IList<string>>();
        backtrack(0);
        return res;
    }

    private void backtrack(int row)
    {
        if (row >= number) return;
        for (int col = 0; col < number; col++)
        {
            if (isnoQueen(row, col))
            {
                //放皇后 在当前行列位置
                placequeen(row, col);
                //当前行是最后一行，则找到一个答案
                if (row == number - 1) addAnswer();
                backtrack(row + 1);
                backQueen(row, col); //回溯
            }
        }
    }

    private void addAnswer()
    {
        List<string> answer = new List<string>();
        for (int i = 0; i < number; i++)
        {
            int col = rows[i];
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < col; ++j) sb.Append(".");
            sb.Append("Q");
            for (int j = 0; j < number - col - 1; ++j) sb.Append(".");
            answer.Add(sb.ToString());
        }

        res.Add(new List<string>(answer));
    }


    /// <summary>
    /// 移除皇后 ，用来回溯用
    /// 无皇后设置为0
    /// </summary>
    private void backQueen(int row, int col)
    {
        rows[row] = 0;
        cols[col] = 0;
        mains[row - col + number - 1] = 0;
        secondary[row + col] = 0;
    }

    /// <summary>
    /// 在当前位置 放皇后
    /// 有皇后的位置设置为1
    /// </summary>
    private void placequeen(int row, int col)
    {
        // 在 row 行，col 列 放置皇后
        rows[row] = col;
        cols[col] = 1; //当前位置记住已经有了皇后
        mains[row - col + number - 1] = 1;
        secondary[row + col] = 1;
    }

    /// <summary>
    /// 当前位置 行 列 对角线 只有一个皇后
    /// </summary>
    private bool isnoQueen(int row, int col)
    {
        //因为有皇后为1 无皇后为0
        // 行只有皇后 列只有一个皇后 对角线只有一个皇后 回溯的时候看列不看行 因为就是一行一行放置的
        return cols[col] + mains[row - col + number - 1] + secondary[row + col] == 0;
    }

    public static void Test()
    {
        var solveNQueens = new _51_SolveNQueens();
        var x = solveNQueens.SolveNQueens(4);
        foreach (var i in x)
        {
            foreach (var q in i)
            {
                Console.Write(q);
            }

            Console.WriteLine();
        }
    }
}