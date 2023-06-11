namespace DataStructure.DataStructure.Tree;

public class Traversal<T> where T : IComparable
{
    public Traversal()
    {
    }

    /// <summary>
    /// 前序遍历
    /// 先访问根节点，然后访问左子树，最后访问右子树
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public List<int> preorder(TreeNode<int> root)
    {
        List<int> res = new List<int>();
        preorder(root, res);
        return res;
    }

    private void preorder(TreeNode<int> node, List<int> res)
    {
        //先当前，然后递归左右
        if (node == null) return;
        res.Add(node.Data);
        preorder(node.Left, res);
        preorder(node.Right, res);
    }

    /// <summary>
    /// 中序遍历
    /// 先访问左子树，然后访问根节点，最后访问右子树。
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public List<int> InOrder(TreeNode<int> ro)
    {
        List<int> res = new List<int>();
        InOrder(ro, res);
        return res;
    }

    private void InOrder(TreeNode<int> node, List<int> res)
    {
        if (node == null) return;
        InOrder(node.Left, res);
        res.Add(node.Data);
        InOrder(node.Right, res);
    }

    /// <summary>
    /// 后序遍历的过程是先访问左子树，然后访问右子树，最后访问根节点
    /// </summary>
    public List<int> postOrder(TreeNode<int> root)
    {
        var res = new List<int>();
        postOrder(root, res);
        return res;
    }

    private void postOrder(TreeNode<int> node, List<int> res)
    {
        if (node == null) return;
        postOrder(node.Right, res);
        postOrder(node.Left, res);
        res.Add(node.Data);
    }
}