namespace DataStructure.DataStructure.DataStack;

/// <summary>
/// 基于链表实现的栈
/// </summary>
public class DataLinkedStack<T>: IStack<T>
{
    public class StackNode<T>
    {
        public T Data { get; set; }
        public StackNode<T> Next { get; set; }

        public StackNode(T data)
        {
            Data = data;
            Next = null;
        }
    }


    /// <summary>
    /// 栈顶元素的引用
    /// </summary>
    private StackNode<T> top;
    private int _size;

    public DataLinkedStack()
    {
        this.top = null;
        _size = -1;
    }
    
    /// <summary>
    /// 入栈
    /// </summary>
    /// <param name="value"></param>
    public void Push(T value)
    {
        var node = new DataLinkedStack<T>.StackNode<T>(value);
        if (top==null)
        {
            top = node;
        }
        else
        {
            node.Next = top;
            top = node;
        }
        _size++;
    }

    /// <summary>
    /// 出栈
    /// 返回出栈的值
    /// </summary>
    /// <returns></returns>
    public T Pop()
    {
        T tmp = default;
        if (_size==-1)
        {
            Console.WriteLine("栈为空！");
            return default;
        }

        //记得更新引用
        tmp = top.Data;
        top = top.Next;
        _size--;
        return tmp;
    }

    /// <summary>
    /// 查询栈顶元素
    /// </summary>
    /// <returns></returns>
    public T Peek()
    {
        if (_size==-1)
        {
            Console.WriteLine("栈为空！");
            return default;
        }

        return top.Data;
    }

    public bool IsEmpty()
    {
        return _size == -1;
    }

    public int Count()
    {
        return _size + 1;
    }


    public void Change(int index, T value)
    {
        if (index<0||index>=_size)
        {
            throw new IndexOutOfRangeException("索引不在范围内");
        }

        var current = top;
        //反向遍历找到正确位置
        for (int i = 0; i < _size-index; i++)
        {
            current = current.Next;
        }

        current.Data = value;
    }
    
    public void Print()
    {
        if (_size==-1)
        {
            Console.WriteLine("栈为空！");
        }
        else
        {
            Console.Write("当前栈的元素为(自栈顶到栈尾): ");
            var current = top;
            while (current!=null)
            {
                Console.Write(current.Data+" ");
                current = current.Next;
            }

            Console.WriteLine();
        }
    }
}