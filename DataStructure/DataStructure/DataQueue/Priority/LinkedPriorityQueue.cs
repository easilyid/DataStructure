namespace DataStructure.DataStructure.DataQueue.Priority;

/// <summary>
/// 基于链表实现的优先队列
/// </summary>
public class LinkedPriorityQueue<T>
{
    public class Node<T>
    {
        public T Data { get; set; }
        public int Priority { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data, int priority)
        {
            Data = data;
            Priority = priority;
            Next = null;
        }
    }

    private Node<T> _head;
    private int _size;

    public LinkedPriorityQueue()
    {
        _head = null;
        _size = 0;
    }


    public void Enqueue(T value, int priority)
    {
        var newNode = new Node<T>(value, priority);
        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            var current = _head;
            Node<T> prev = null;
            
            //循环遍历得到优先级相等或小于的那个位置
            //在这个位置后面入队
            while (current != null && current.Priority <= priority)
            {
                //找到优先级比传入优先级小的那个位置
                prev = current;
                //找到比传入优先级大的那个位置
                current = current.Next;
            }

            if (prev == null)
            {//如果传入的优先级直接就比current大，那么prev为空的情况下 新节点为head
                newNode.Next = _head;
                _head = newNode;
            }
            else
            {//因为prev的优先级小于传入的，所以他的下一位就是传入的值
                prev.Next = newNode;
                //current是比传入优先级大的那个位置
                newNode.Next = current;
            }
        }

        _size++;
    }

    public T Dequeue()
    {
        T temp = default;
        if (IsEmpty())
        {
            Console.WriteLine("该队列为空!");
            return temp;
        }

        temp = _head.Data;
        _head = _head.Next;
        _size--;
        return temp;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("该队列为空!");
            return default;
        }

        return _head.Data;
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }

    public int Count()
    {
        return _size;
    }

    public void Print()
    {
        if (IsEmpty())
        {
            Console.WriteLine("该队列为空!");
            return;
        }

        var current = _head;
        Console.WriteLine("该队列的元素为:");
        while (current!=null)
        {
            Console.WriteLine($"值:[{current.Data}],优先级:[{current.Priority}]");
            current = current.Next;
        }
    }
}