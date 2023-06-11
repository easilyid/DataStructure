namespace DataStructure.DataStructure.Tree;

/// <summary>
/// 红黑树
/// 通过颜色来维护节点
/// 根节点是黑色的
/// </summary>
public class RBTree<T> where T : IComparable<T>
{
    public TreeNode<T> root;

    public RBTree()
    {
        root = null;
    }

    public void InSert(T value)
    {
        root = InSert(root, value);
        root.Color = NODEColor.BLANK;
    }

    private TreeNode<T> InSert(TreeNode<T> node, T value)
    {//如果无节点就创建一个
        if (node == null) return new TreeNode<T>(value);

        if (value.CompareTo(node.Data) < 0)
        {//如果插入值小于当前节点的值，则插入到左子树
            node.Left = InSert(node.Left, value);
        }
        else if (value.CompareTo(node.Data) > 0)
        {
            node.Right = InSert(node.Right, value);
        }

        //维护平衡性
        if (IsRed(node.Right) && !IsRed(node.Left))
        {
            node = RotateLeft(node);
        }

        if (IsRed(node.Left) && IsRed(node.Left.Left))
        {
            node = RotateRight(node);
        }

        //如果左子节点和右子节点都为红，就翻转颜色
        if (IsRed(node.Left) && IsRed(node.Right))
        {
            FlipColors(node);
        }

        Console.WriteLine($"插入成功，节点为[{node.Data}],颜色为{node.Color}");
        return node;
    }

    public void Delete(T value)
    {
        root = Delete(root, value);
        if (root != null)
            root.Color = NODEColor.BLANK;
    }

    private TreeNode<T> Delete(TreeNode<T> node, T value)
    {
        if (node == null) return null;
        if (value.CompareTo(node.Data) < 0)
        {
            if (!IsRed(node.Left) && !IsRed(node.Left.Left))
            {// 如果当前节点是黑色节点，且左右子节点都是黑色节点，则需要将左右子节点的颜色变为红色节点
                //将当前节点和左子节点的颜色进行翻转
                node = MoveRedLeft(node);
            }

            node.Left = Delete(node.Left, value);
        }
        else
        {
            //如果当前左子节点为红就进行右旋转
            if (IsRed(node.Left))
            {
                node = RotateRight(node);
            }

            if (value.CompareTo(node.Data) == 0 && node.Right == null)
            { // 如果当前节点的值等于要删除的值，且右子节点为空，则直接返回 null
                return null;
            }
            // 如果当前节点是黑色节点，且右子节点和右子节点的左子节点都是黑色节点，则需要将右子节点的颜色变为红色节点
            if (!IsRed(node.Right) && !IsRed(node.Right.Left))
            {
                node = MoveRedRight(node); // 将当前节点和右子节点的颜色进行翻转
            }

            if (value.CompareTo(node.Data) == 0)
            { // 如果当前节点的值等于要删除的值，则需要将当前节点的值替换为右子树中的最小值，并删除右子树中的最小值节点
                var min = Min(node.Right); // 获取右子树中的最小值节点
                node.Data = min.Data;// 将当前节点的值替换为右子树中的最小值
                node.Right = DeleteMin(node.Right); // 删除右子树中的最小值节点
            }
            else
            {
                node.Right = Delete(node.Right, value);
            }
        }

        return FixUP(node);//维护平衡性
    }
    
    /// <summary>
    /// 用于将当前节点和左子节点的颜色进行翻转
    /// </summary>
    private TreeNode<T> MoveRedLeft(TreeNode<T> node)
    {
        FlipColors(node);
        if (IsRed(node.Right.Left))
        {
            node.Right = RotateRight(node.Right);
            node = RotateLeft(node);
            FlipColors(node);
        }

        return node;
    }

    /// <summary>
    /// 用于将当前节点和右子节点的颜色进行翻转
    /// </summary>
    private TreeNode<T> MoveRedRight(TreeNode<T> node)
    {
        FlipColors(node);
        if (IsRed(node.Left.Left))
        {
            node = RotateRight(node);
            FlipColors(node);
        }

        return node;
    }

    private TreeNode<T> DeleteMin(TreeNode<T> node)
    {
        if (node.Left == null)
        {
            return null;
        }

        // 如果当前节点是黑色节点，且左右子节点都是黑色节点，则需要将左右子节点的颜色变为红色节点
        if (!IsRed(node.Left) && !IsRed(node.Left.Left))
        {
            node = MoveRedLeft(node); // 将当前节点和左子节点的颜色进行翻转
        }

        node.Left = DeleteMin(node.Left); // 递归调用 DeleteMin 方法删除最小值节点
        return FixUP(node); // 维护红黑树的平衡性
    }

    /// <summary>
    /// 查找最小值节点
    /// </summary>
    private TreeNode<T> Min(TreeNode<T> node)
    {
        if (node.Left == null) return node;
        else
            return Min(node.Left);
    }

    private TreeNode<T> FixUP(TreeNode<T> node)
    {
        if (IsRed(node.Right))
        {//右为红 左旋转
            node = RotateLeft(node);
        }

        if (IsRed(node.Left) && IsRed(node.Left.Left))
        {//左和左子节点都为红 ，右旋转
            node = RotateRight(node);
        }

        if (IsRed(node.Left) && IsRed(node.Right))
        {//左右都为红就翻转颜色
            FlipColors(node);
        }

        return node;
    }


    /// <summary>
    /// 颜色翻转
    /// 将当前节点和其左右子节点的颜色进行翻转
    /// </summary>
    /// <param name="node"></param>
    private void FlipColors(TreeNode<T> node)
    {
        node.Color = NODEColor.RED;
        node.Left.Color = NODEColor.BLANK;
        node.Right.Color = NODEColor.BLANK;
    }


    /// <summary>
    /// 左旋转
    /// </summary>
    private TreeNode<T> RotateLeft(TreeNode<T> node)
    {
        //往那边旋转,它另外一方向的子节点为root节点
        var x = node.Right;
        //将node节点的右边变成 原node
        node.Right = x.Left;
        //将x 左边链接到指定为node节点
        x.Left = node;
        x.Color = node.Color;
        node.Color = NODEColor.RED;
        return x;
    }

    private TreeNode<T> RotateRight(TreeNode<T> node)
    {
        //往那边旋转,它另外一方向的子节点为root节点
        var x = node.Left;
        node.Left = x.Right;
        x.Right = node;
        x.Color = node.Color;
        node.Color = NODEColor.RED;
        return x;
    }


    /// <summary>
    /// 判断一个节点是否是红色
    /// 红黑树 空节点为黑
    /// </summary>
    private bool IsRed(TreeNode<T> node)
    {
        if (node == null) return false;
        else
            return node.Color == NODEColor.RED;
    }

    public bool Contains(T data)
    {
        var node = root;
        while (node != null)
        {
            if (data.CompareTo(node.Data) < 0)
            {
                node = node.Left;
            }
            else if (data.CompareTo(node.Data) > 0)
            {
                node = node.Right;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    public void Print()
    {
        PrintHelper(root, "", true);
    }

    private void PrintHelper(TreeNode<T> node, string indent, bool last)
    {
        if (node != null)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("R----");
                indent += "     ";
            }
            else
            {
                Console.Write("L----");
                indent += "|    ";
            }

            Console.WriteLine($"Color: {node.Color}, Value: [{node.Data}]");
            PrintHelper(node.Left, indent, false);
            PrintHelper(node.Right, indent, true);
        }
    }
}