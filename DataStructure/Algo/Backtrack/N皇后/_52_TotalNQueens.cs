namespace DataStructure.Algo.Backtrack.N皇后;

public class _52_TotalNQueens
{
    int count = 0;

    public int TotalNQueens(int n)
    {
        bool[] cols = new bool[n];//记录每列是否已经有皇后
        bool[] mains = new bool[2 * n - 1];//记录主对角线是否已经有皇后
        bool[] secondarys = new bool[2 * n - 1];//记录次对角线是否已经有皇后

        backtrack(0, n, cols, mains, secondarys);//ps; 注意不能把变量count变为参数，会污染它的值
        return count;
    }

    private void backtrack(int row, int numbers, bool[] cols, bool[] mains, bool[] secondarys)
    {
        if (row == numbers)
        {
            count++;
            return;
        }

        for (int col = 0; col < numbers; col++)
        {
            int main = col - row + numbers - 1; //计算当前位置所在的主对角线的下标
            int secondry = col + row;// 计算当前位置所在的次对角线的下标
            if (cols[col] || mains[main] || secondarys[secondry])
                continue;//如果当前列或者主对角线或者副对角线已经有皇后了，跳过这一列
            placeQueen(cols, mains, secondarys, col, main, secondry);
            backtrack(row + 1, numbers, cols, mains, secondarys);
            backQueen(cols, mains, secondarys, col, main, secondry);
        }
    }

    /// <summary>
    /// 回溯皇后
    /// </summary>
    private static void backQueen(bool[] cols, bool[] mains, bool[] secondarys, int col, int main, int secondry)
    {
        cols[col] = false;
        mains[main] = false;
        secondarys[secondry] = false;
    }

    /// <summary>
    /// 放置皇后
    /// </summary>
    private static void placeQueen(bool[] cols, bool[] mains, bool[] secondarys, int col, int main, int secondry)
    {
        cols[col] = true;
        mains[main] = true;
        secondarys[secondry] = true;
    }

    public static void Test()
    {
        var totalNQueens = new _52_TotalNQueens();
        var nQueens = totalNQueens.TotalNQueens(4);
        Console.WriteLine(nQueens);
    }
}