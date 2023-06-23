namespace DataStructure.Algo.Backtrack.Int;

public class _980_UniquePathsIII
{
    private int awaner = 0; //记录答案

    private int noVisited = 1; //记录没有访问的格子数量 起点是已经访问过的

    //左右上下
    private int[,] dirs = new int[,] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } }; //四个方向 
    private int startRow = 0, startCol = 0;
    private int endRow = 0, endCol = 0;
    public int UniquePathsIII(int[][] grid)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 0) noVisited++;
                else if (grid[i][j] == 1)
                {
                    //找到起点了
                    startRow = i;
                    startCol = j;
                }
                else if (grid[i][j] == 2)
                {
                    //找到终点了
                    endRow = i;
                    endCol = j;
                }
            }
        }

        backtrack(startRow, startCol, endRow, endCol, grid);
        return awaner;
    }

    private void backtrack(int row, int col, int endRow1, int endCol1, int[][] grid)
    {
        if (row == endRow1 && col == endCol1 && noVisited == 0)
        {
            awaner++;
            return;
        }
        int temp = grid[row][col];
        grid[row][col] = -2; //-2只是混淆值,标致这这个位置已经被访问过了
        noVisited--;
        for (int i = 0; i < 4; i++)
        {
            //四个方向
            int newRow = row + dirs[i, 0];
            int newCol = col + dirs[i, 1];
            //判断下个格子是否在范围内
            if (newRow >= 0 && newRow < grid.Length && newCol >= 0 && newCol < grid[0].Length)
            {
                if (grid[newRow][newCol]==0||grid[newRow][newCol]==2)
                {
                    backtrack(newRow,newCol,endRow1,endCol1,grid);
                }
            }
        }

        //回溯
        grid[row][col] = temp;
        noVisited++;
    }

    public static void Test()
    {
        int[][] grid = {
            new[] {1,0,0,0},
            new[] {0,0,0,0},
            new[] {0,0,2,-1},
        };

        var uniquePathsIii = new _980_UniquePathsIII();
        int x= uniquePathsIii.UniquePathsIII(grid);
        Console.WriteLine(x);
    }
}