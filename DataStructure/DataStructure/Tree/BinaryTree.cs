namespace DataStructure.DataStructure.Tree;



/// <summary>
/// 二叉树
/// 每个节点最多有两个子节点的树结构。
/// </summary>
public class BinaryTree<T> where T : IComparable<T>
{
    public TreeNode<T> root;

    public BinaryTree()
    {
        root = null;
    }

    public void InSert(T value)
    {
        var newNode = new TreeNode<T>(value);
        if (root == null)
        {
            root = newNode;
            return;
        }

        var current = root;
        TreeNode<T> parent = null;

        //遍历树,找到插入节点的位置
        while (true)
        {
            parent = current;
            //如果数据小于当前节点的数据,则转到左子节点
            if (value.CompareTo(current.Data) < 0)
            {
                current = current.Left;
                if (current == null)
                {
                    parent.Left = newNode;
                    return;
                }
            }
            else
            {
                current = current.Right;
                if (current == null)
                {
                    parent.Right = newNode;
                    return;
                }
            }
        }
    }

    public void Delete(T value)
    {
        TreeNode<T> current = root;
        TreeNode<T> parent = null;

        while (current != null && value.CompareTo(current.Data) != 0)
        {
            parent = current;
            if (value.CompareTo(current.Data) < 0)
            {
                current = current.Left;
            }
            else
            {
                current = current.Right;
            }
        }

        if (current == null)
        {
            Console.WriteLine("节点不存在");
            return;
        }

        if (current.Left != null && current.Right != null)
        {
            var temp = GetSuccessor(current);
            Delete(temp.Data);
            temp.Left = current.Left;
            temp.Right = current.Right;
        }
        else
        {
            var temp = current.Left != null ? current.Left : current.Right;
            if (parent == null)
            {
                root = temp;
            }
            else
            {
                if (current.Data.CompareTo(parent.Data) < 0)
                {
                    parent.Left = temp;
                }
                else
                {
                    parent.Right = temp;
                }
            }
        }
    }

    /// <summary>
    /// 获取子节点
    /// </summary>
    private TreeNode<T> GetSuccessor(TreeNode<T> node)
    {
        var current = node.Right;
        while (current.Left != null)
            current = current.Left;
        return current;
    }

    public int GetHeight(TreeNode<T> node)
    {
        if (node == null)
        {
            return 0;
        }

        int leftChild = GetHeight(node.Left);
        int rightChild = GetHeight(node.Right);
        return Math.Max(leftChild, rightChild) + 1;
    }

    public void Print()
    {
        if (root == null)
        {
            Console.WriteLine("树为空");
            return;
        }

        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(root);
        int level = 1;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            Console.Write("层级" + level + ": ");
            for (int i = 0; i < size; i++)
            {
                TreeNode<T> node = queue.Dequeue();
                Console.Write(node.Data + " ");
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

            Console.WriteLine();
            level++;
        }
    }

    #region 遍历
    /// <summary>
    /// 前序遍历
    /// 先访问根节点，然后访问左子树，最后访问右子树
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public List<T> Preorder()
    {
        List<T> res = new List<T>();
        preorder(root, res);
        return res;
    }

    private void preorder(TreeNode<T> node, List<T> res)
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
    public List<T> InOrder()
    {
        List<T> res = new List<T>();
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

    /// <summary>
    /// 后序遍历的过程是先访问左子树，然后访问右子树，最后访问根节点
    /// </summary>
    public List<T> PostOrder()
    {
        var res = new List<T>();
        postOrder(root, res);
        return res;
    }

    private void postOrder(TreeNode<T> node, List<T> res)
    {
        if (node == null) return;
        postOrder(node.Right, res);
        postOrder(node.Left, res);
        res.Add(node.Data);
    }

    /// <summary>
    /// 层序遍历
    /// </summary>
    /// <returns></returns>
    public List<T> LevelOrder()
    {
        var res = new List<T>();
        LevelOrder2(root, res);
        return res;
    }

    private void LevelOrder(TreeNode<T> node, List<T> res)
    {
        if(node==null)return;
        var stack = new Stack<TreeNode<T>>();
        stack.Push(node);
        while (stack.Count > 0)
        {
            var curr = stack.Pop();
            res.Add(curr.Data);
            if(curr.Left!=null)stack.Push(curr.Left);
            if(curr.Right!=null)stack.Push(curr.Right);
        }
    }
    
    private void LevelOrder2(TreeNode<T> node, List<T> res)
    {
        if(node==null)return;
        var stack = new Stack<TreeNode<T>>();
        stack.Push(node);
        while (stack.Count > 0)
        {
            int size = stack.Count;
            for (int i = 0; i < size; i++)
            {
                var curr = stack.Pop();
                res.Add(curr.Data);
                if(curr.Left!=null)stack.Push(curr.Left);
                if(curr.Right!=null)stack.Push(curr.Right);
            }
        }
    }

    #endregion
}