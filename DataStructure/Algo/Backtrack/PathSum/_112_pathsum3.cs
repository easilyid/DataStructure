namespace DataStructure.Algo.Backtrack.PathSum;

/// <summary>
/// 路径总和
/// 通过力扣112题来理解
/// 回溯算法
/// 路径和
/// </summary>
public class _112_pathsum3
{
    //穷举所有路径
    public static bool HasPathSum(TreeNode root, int targetSum)
    {
        var res = new List<int>();
        dfs(root,0, res);

        foreach (var onePathSum in res)
        {
            if (onePathSum == targetSum)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// 深度优先遍历
    /// </summary>
    /// <param name="root"></param>
    /// <param name="res">结果集</param>
    private static void dfs(TreeNode node,int parentSum,List<int> res)
    {
        if (node == null) return;
        int currentSum = parentSum + node.val;
        if (node.left==null&&node.right==null)
        {
            res.Add(currentSum);
        }

        //作为下一个节点的父亲节点路径和
        dfs(node.left, currentSum, res);
        dfs(node.right, currentSum, res);
        
    }

    public static void Test()
    {
        TreeNode root = new TreeNode(5);
        TreeNode node1 = new TreeNode(4);
        TreeNode node2 = new TreeNode(8);
        root.left = node1;
        root.right = node2;

        TreeNode node3 = new TreeNode(11);
        TreeNode node4 = new TreeNode(7);
        TreeNode node5 = new TreeNode(2);
        node1.left = node3;
        node3.left = node4;
        node3.right = node5;

        TreeNode node6 = new TreeNode(13);
        TreeNode node7 = new TreeNode(4);
        TreeNode node8 = new TreeNode(5);
        TreeNode node9 = new TreeNode(1);
        node2.left = node6;
        node2.right = node7;
        node7.left = node8;
        node7.right = node9;

        Console.WriteLine( HasPathSum(root, 22));
       

    }
}