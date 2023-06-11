namespace DataStructure.DataStructure.Tree;

/// <summary>
/// 平衡二叉树
/// 左右子树的高度差不超过1
/// 平衡因子 = 左子树高度 - 右子树高度
/// 满足平衡因子
/// </summary>
public class AVLTree<T> where T : IComparable<T>
{
    public TreeNode<T> root;

    public AVLTree()
    {
        root = null;
    }

    public void InSert(T value)
    {
        root = InSert(root, value);
    }

    private TreeNode<T> InSert(TreeNode<T> node, T value)
    {
        if (node == null) return new TreeNode<T>(value);
        if (value.CompareTo(node.Data) < 0)
        {
            node.Left = InSert(node.Right, value);
        }
        else if (value.CompareTo(node.Data) > 0)
        {
            node.Right = InSert(node.Right, value);
        }

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        //树变化了，进行平衡
        return BalanceTree(node, value);
    }

    public void Delete(T value)
    {
        root = Delete(root, value);
    }

    private TreeNode<T> Delete(TreeNode<T> node, T value)
    {
        if (node == null)
        {
            return node;
        }

        if (value.CompareTo(node.Data) < 0)
        {
            node.Left = Delete(node.Left, value);
        }
        else if (value.CompareTo(node.Data) > 0)
        {
            node.Right = Delete(node.Right, value);
        }
        else
        {
            if (node.Left == null || node.Right == null)
            {
                TreeNode<T> temp = null;
                if (temp == node.Left)
                {
                    temp = node.Right;
                }
                else
                    temp = node.Left;

                if (temp == null)
                {
                    node = null;
                }
                else
                    node = temp;
            }
            else
            {
                var temp = FinMinNode(node.Right);
                node.Data = temp.Data;
                node.Right = Delete(node.Right, temp.Data);
            }
        }

        if (node == null) return node;

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        int balance = GetBalance(node);

        if (balance > 1 && GetBalance(node.Left) >= 0)
        {
            return RotateRight(node);
        }

        if (balance > 1 && GetBalance(node.Right) < 0)
        {
            return RotateLeft(node);
        }

        if (balance < -1 && GetBalance(node.Left) <= 0)
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        if (balance < -1 && GetBalance(node.Right) > 0)
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    private TreeNode<T> FinMinNode(TreeNode<T> node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }

        return node;
    }


    /// <summary>
    /// 平衡树
    /// </summary>
    private TreeNode<T> BalanceTree(TreeNode<T> node, T value)
    {
        //计算平衡因子
        int balance = GetBalance(node);
        if (balance > 1 && (value.CompareTo(node.Left.Data) < 0))
        {
            return RotateRight(node);
        }

        if (balance < -1 && (value.CompareTo(node.Right.Data) > 0))
        {
            return RotateLeft(node);
        }

        if (balance > 1 && (value.CompareTo(node.Left.Data) > 0))
        {
            node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }

        if (balance < -1 && (value.CompareTo(node.Right.Data) < 0))
        {
            node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    /// <summary>
    /// 向右旋转
    /// </summary>
    private TreeNode<T> RotateRight(TreeNode<T> node)
    {
        var leftChild = node.Left; //左子树
        var rightChild = leftChild.Right; //子树的右节点

        leftChild.Right = node;
        node.Left = rightChild;

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        leftChild.Height = 1 + Math.Max(GetHeight(leftChild.Left), GetHeight(leftChild.Right));

        return leftChild;
    }

    /// <summary>
    /// 向左旋转
    /// </summary>
    private TreeNode<T> RotateLeft(TreeNode<T> node)
    {
        var rightChild = node.Right;
        var leftChild = rightChild.Left;

        rightChild.Left = node;
        node.Right = leftChild;

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        rightChild.Height = 1 + Math.Max(GetHeight(rightChild.Left), GetHeight(rightChild.Right));
        return rightChild;
    }


    /// <summary>
    /// 平衡因子
    /// </summary>
    private int GetBalance(TreeNode<T> node)
    {
        if (node == null)
        {
            return 0;
        }

        //平衡因子 = 左子树高度 - 右子树高度
        return GetHeight(node.Left) - GetHeight(node.Right);
    }

    private int GetHeight(TreeNode<T> node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.Height;
    }

    #region 遍历

    public List<T> Preorder()
    {
        var res = new List<T>();
        Preorder(root, res);
        return res;
    }

    private void Preorder(TreeNode<T> node, List<T> res)
    {
        if(node==null)return;
        res.Add(node.Data);
        Preorder(node.Left, res);
        Preorder(node.Right, res);
    }
    
    public List<T> InOrder()
    {
        var res = new List<T>();
        InOrder(root, res);
        return res;
    }

    private void InOrder(TreeNode<T> node, List<T> res)
    {
        if(node==null)return;
        Preorder(node.Left, res);
        res.Add(node.Data);
        Preorder(node.Right, res);
    }

    public List<T> PostOrder()
    {
        var res = new List<T>();
        PostOrder(root, res);
        return res;
    }

    private void PostOrder(TreeNode<T> node, List<T> res)
    {
        if(node==null)return;
        Preorder(node.Left, res);
        Preorder(node.Right, res);
        res.Add(node.Data);
    }

    public List<T> LevelOrder()
    {
        var res = new List<T>();
        LevelOrder(root, res);
        return res;
    }

    private void LevelOrder(TreeNode<T> node, List<T> res)
    {
        if(node==null)return;
        var stack = new Stack<TreeNode<T>>();
        stack.Push(node);
        while (stack.Count>0)
        {
            var current = stack.Pop();
            res.Add(current.Data);
            if (node.Left != null) LevelOrder(node.Left, res);
            if (node.Right != null) LevelOrder(node.Right, res);
        }
    }

    #endregion

}