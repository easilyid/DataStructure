namespace DataStructure.Algo.Greedy;

public class _860_MatrixScore
{
    // [[1,1,1,1], --> 2^3  1 = 4 - 0 - 1  res的解释
    // [1,0,0,1],
    // [1,1,1,1]] --> 2^1 = 2
    // 0b1111 + 0b1001 + 0b1111 = 15 + 9 + 15 = 39
    public int MatrixScore(int[][] grid)
    {
        int rows = grid.Length, cols = grid[0].Length;
        for (int row = 0; row < rows; row++)
        {
            if (grid[row][0] == 0)
            { // 如果当前行的第一个元素为0，则翻转整行
                for (int col = 0; col < cols; col++)
                {
                    grid[row][col] ^= 1;//异或1 
                }
            }
        }

        int res = 0;
        for (int col = 0; col < cols; col++)
        {
            int cnt = 0; //计算1的个数
            for (int row = 0; row < rows; row++)
            {
                cnt += grid[row][col];
            }

            int maxCnt = Math.Max(cnt, rows - cnt);
            res += maxCnt * (1 << (cols - col - 1)); //表示当前列的得分乘以连续出现的1的最大次数。这个乘积就是当前列的总得分
        }

        return res;
    }

    public static void Test()
    {
        int[][] grid =
        {
            new int[] { 0, 0, 1, 1 },
            new int[] { 1, 0, 1, 0 },
            new int[] { 1, 1, 0, 0 }
        };
        var matrixScore = new _860_MatrixScore().MatrixScore(grid);
        Console.WriteLine(matrixScore);
    }
}