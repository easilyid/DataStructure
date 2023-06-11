using System.Collections;

namespace DataStructure.Algo.Backtrack;

/// <summary>
/// 树的深度优先遍历
/// </summary>
public class TreeDFS
{
    public class TreeNode
    {
        private int _val;
        public TreeNode _left;
        public TreeNode _right;

        public TreeNode(int data)
        {
            this._val = data;
        }
    }

    public List<TreeNode> preOrder(TreeNode root)
    {
        List<TreeNode> res = new  List<TreeNode>();

        dfs(root, res);
        return res;
    }

    private void dfs(TreeNode root, List<TreeNode> res)
    {//一般的回溯算法题，都可以抽象成树的深度优先遍历
        if(root==null)return;
        res.Add(root);
        dfs(root._left,res);
        dfs(root._right,res);
    }
}