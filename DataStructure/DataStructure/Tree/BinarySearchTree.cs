namespace DataStructure.DataStructure.Tree;

/// <summary>
///二叉搜索树 BST
/// 每个节点的左子节点小于右子节点
/// 左右子树也需要满足这个条件
///  平衡因子 = 左子树高度 - 右子树高度
/// </summary>
public class BinarySearchTree<T> where T : IComparable<T>
{
    public TreeNode<T> root;

    public BinarySearchTree()
    {
        root = null;
    }

    public void InSert(T value)
    {
        root = InSertNode(root, value);
    }

    private TreeNode<T> InSertNode(TreeNode<T> node, T value)
    {
        if (node == null) return new TreeNode<T>(value);

        if (value.CompareTo(node.Data) < 0)
        {
            node.Left = InSertNode(node.Left, value);
        }
        else if (value.CompareTo(node.Data) > 0)
        {
            node.Right = InSertNode(node.Right, value);
        }

        return node;
    }


    public void Delete(T value)
    {
        root = DeleteNode(root, value);
    }

    private TreeNode<T> DeleteNode(TreeNode<T> node, T value)
    {
        if (node == null)
        {
            Console.WriteLine("该树为空");
            return node;
        }

        if (value.CompareTo(node.Data) < 0)
        {
            node.Left = DeleteNode(node.Left, value);
        }
        else if (value.CompareTo(node.Data) > 0)
        {
            node.Right = DeleteNode(node.Right, value);
        }
        else
        {
            //如果当前节点为要删除的节点 
            if (node.Left == null || node.Right == null)
            {
                TreeNode<T> temp = null;
                if (temp == node.Left)
                {
                    //如果没有左子节点 就指向右节点
                    temp = node.Right;
                }
                else
                    temp = node.Left;

                if (temp == null)
                {
                    temp = node;
                    node = null;
                }
                else
                    //如果子节点不为空，则吧temp作为当前节点
                    node = temp;
            }
            else
            {
                TreeNode<T> temp = MinValueNode(node.Right);
                node.Data = temp.Data;
                //从右节点中删除该节点
                node.Right = DeleteNode(node.Right, temp.Data);
            }
        }

        return node;
    }

    /// <summary>
    /// 查找有没有该值
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Contains(T value)
    {
        var node = Find(value);
        if (node == null) return false;

        return true;
    }

    private TreeNode<T> Find(T value)
    {
        return find(root, value);
    }

    private TreeNode<T> find(TreeNode<T> node, T value)
    {
        if (node == null) return null;
        TreeNode<T> curr = root;
        while (curr != null)
        {
            if (value.CompareTo(curr.Data) == 0)
            {
                return curr;
            }
            else if (value.CompareTo(curr.Data) < 0)
            {
                curr = curr.Left;
            }
            else
            {
                curr = curr.Right;
            }
        }

        return null;
    }


    /// <summary>
    /// 找到右子树最小值
    /// </summary>
    private TreeNode<T> MinValueNode(TreeNode<T> node)
    {
        //树的左子节点比右节点小
        TreeNode<T> current = node;
        while (current.Left != null)
        {
            current = current.Left;
        }

        return current;
    }


    #region 遍历

    public List<T> PreOrder()
    {
        var res = new List<T>();
        PreOrder(root, res);
        return res;
    }

    private void PreOrder(TreeNode<T> node, List<T> res)
    {
        if (node == null) return;
        res.Add(node.Data);
        PreOrder(node.Left, res);
        PreOrder(node.Right, res);
    }

    public List<T> InOrder()
    {
        var res = new List<T>();
        InOrder(root, res);
        return res;
    }

    private void InOrder(TreeNode<T> node, List<T> res)
    {
        if (node == null) return;
        InOrder(node.Left, res);
        res.Add(node.Data);
        InOrder(node.Right, res);
    }

    public List<T> PostOrder()
    {
        var res = new List<T>();
        PostOrder(root, res);
        return res;
    }

    private void PostOrder(TreeNode<T> node, List<T> res)
    {
        if (node == null) return;
        PostOrder(node.Left, res);
        PostOrder(node.Right, res);
        res.Add(node.Data);
    }

    public List<T> LeverOrder()
    {
        var res = new List<T>();
        LeverOrder(root, res);
        return res;
    }

    private void LeverOrder(TreeNode<T> node, List<T> res)
    {
        if (node == null) return;
        var stack = new Stack<TreeNode<T>>();
        stack.Push(node);
        while (stack.Count > 0)
        {
            var curr = stack.Pop();
            res.Add(curr.Data);
            if (curr.Left != null) LeverOrder(node.Left, res);
            if (curr.Right != null) LeverOrder(node.Right, res);
        }
    }

    #endregion
}