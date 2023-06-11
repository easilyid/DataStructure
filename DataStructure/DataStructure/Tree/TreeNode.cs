namespace DataStructure.DataStructure.Tree;

public enum NODEColor
{
    RED,
    BLANK
}
public class TreeNode<T>
{
    
    public T Data { get; set; }
    public TreeNode<T> Left { get; set; }
    public TreeNode<T> Right { get; set; }

    public NODEColor  Color { get; set; }   

    public int Height;
    public TreeNode(T data)
    {
        Data = data;
        Left = null;
        Right = null;
        Height = -1;
        // 1. 在红黑树中，红色的节点代表的就是它和它的父亲在 2-3 树中是在融合在一起的
        // 2. 在 2-3 树中插入新建的节点的时候，都是先和叶子节点进行融合
        this.Color = NODEColor.RED;
    }
    
    
    //两种遍历方式，深度使用栈，先进后出 广度使用队列，先进先出
    
    /// <summary>
    /// 深度优先遍历
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public List<T> DFS(TreeNode<T> root)
    {
        var res = new List<T>();
        if (root == null) return res;
        var stack = new Stack<TreeNode<T>>();
        stack.Push(root);

        while (stack.Count>0)
        {
            var current = stack.Pop();
            res.Add(current.Data);
            if (root.Left != null) stack.Push(root.Left);
            if (root.Right != null) stack.Push(root.Right);
        }

        return res;
    }

    /// <summary>
    /// 广度优先遍历
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public List<T> BFS(TreeNode<T> root)
    {
        var res = new List<T>();
        if (root == null) return res;
        var queue = new Queue<TreeNode<T>>();
        queue.Enqueue(root);
        while (queue.Count>0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var current = queue.Dequeue();
                res.Add(current.Data);
                if(root.Left!=null) queue.Enqueue(root.Left);
                if(root.Right!=null) queue.Enqueue(root.Right);
            }
        }

        return res;
    }
}



