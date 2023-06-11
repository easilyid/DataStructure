namespace DataStructure.Algo.Backtrack.PathSum;

/// <summary>
/// 路径总和
/// 通过力扣112题来理解
/// 回溯算法
/// </summary>
public class _112_pathsum2
{
    //穷举所有路径
    public static bool HasPathSum(TreeNode root, int targetSum)
    {
        var res = new List<IList<int>>();
        var path = new List<int>();
        dfs(root, res, path);

        foreach (var onePath in res)
        {
            int sum = 0;
            foreach (var i in onePath)
            {
                sum += i;
            }

            if (sum == targetSum)
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
    /// <param name="path">路径集</param>
    private static void dfs(TreeNode node, List<IList<int>> res,List<int> path)
    {
        if (node == null) return;
        path.Add(node.val);

        if (node.left == null && node.right == null)
        {//new一个对象的原因，使用res中的对象的和path不是同一个对象
            res.Add(new List<int>(path));
        }
        dfs(node.left,res,path);
        dfs(node.right,res,path);

        //回溯的过程中将当前的节点从path中删除
        path.RemoveAt(path.Count - 1);
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