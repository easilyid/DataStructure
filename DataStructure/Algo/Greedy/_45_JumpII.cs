namespace DataStructure.Algo.Greedy;

public class _45_JumpII
{
    #region DFS

    //将所有结果都列举出来找到最短路径
    private int minSteps = Int32.MaxValue; //最小步长

    public int Jump1(int[] nums)
    {
        var path = new List<int>(); //记录路径
        DFS(nums, 0, path);
        return minSteps == Int32.MaxValue ? 0 : minSteps; // 返回最小步长，如果最小步长为Int32.MaxValue，则返回0
    }

    private void DFS(int[] nums, int jumpIndex, List<int> path)
    {
        if (jumpIndex == nums.Length - 1)
        {
            minSteps = Math.Min(minSteps, path.Count);
            return;
        }

        for (int i = 1; i <= nums[jumpIndex]; i++)
        {
            if (jumpIndex + i >= nums.Length) continue;
            path.Add(i);
            DFS(nums, jumpIndex + i, path);
            path.RemoveAt(path.Count - 1);
        }
    }

    #endregion

    #region BFS

    //通过遍历每一层的节点来模拟跳跃的过程，直到找到目标位置或无法到达目标位置为止
    public int Jump2(int[] nums)
    {
        if (nums.Length == 1)
        {
            return 0;
        }

        var queue = new Queue<int>();
        queue.Enqueue(0);
        int level = 0;
        while (queue.Count != 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                int jumpIndex = queue.Dequeue(); //PS:
                if (jumpIndex == nums.Length - 1) return level;
                for (int j = 1; j <= nums[jumpIndex]; j++)
                {
                    queue.Enqueue(jumpIndex + j);
                }
            }

            level++;
        }

        return 0;
    }

    #endregion

    #region 贪心算法

    //每一步都选择能跳的最远距离
    public int Jump(int[] nums)
    {
        int steps = 0;
        int start = 0, end = 0;

        while (end < nums.Length - 1)
        {
            int maxPos = 0; //最大跳跃的值
            for (int i = start; i <= end; i++)
            {
                maxPos = Math.Max(maxPos, i + nums[i]);
            }

            start = end + 1;
            end = maxPos;
            steps++;
        }

        return steps;
    }

    #endregion

    public static void Test()
    {
        int[] nums = { 2, 3, 1, 1, 4 };

        int[] nums2 =
        {
            5, 6, 4, 4, 6, 9,
            4, 4, 7, 4, 4, 8, 2, 6, 8, 
            1, 5, 9, 6, 5, 2, 7, 9,
            7, 9, 6, 9, 4, 1, 6, 8, 8,
            4, 4, 2, 0, 3, 
            8, 5
        };

        var jump1 = new _45_JumpII().Jump(nums2);
        Console.WriteLine(jump1);
    }
}