namespace DataStructure.DataStructure.DataQueue.Loop;

/// <summary>
/// 基于链表实现的循环队列
/// </summary>
public class LinkedLoopQueue<T> : IQueue<T>
{
    public class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(T value)
        {
            Data = value;
        }
    }

    private Node _head;
    private Node _tail;
    private int size;

    public LinkedLoopQueue()
    {
        size = 0;
    }

    public void Enqueue(T value)
    {
        var newNode = new Node(value);
        if (_head==null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            _tail = newNode;
        }

        _tail.Next = _head;
        size++;
    }

    public T Dequeue()
    {
        var temp = default(T);
        if (IsEmpty())
        {
            Console.WriteLine("该队列为空!");
            return temp;
        }

        if (size==1)
        {
            temp = _head.Data;
            _head = _tail = null;
        }
        else
        {
            temp = _head.Data;
            _head = _head.Next;
            _tail.Next = _head;
        }
        size--;
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
        return size == 0;
    }

    public int Count()
    {
        return size;
    }

    public void Print()
    {
        if (IsEmpty())
        {
            Console.WriteLine("该队列为空!");
            return;
        }
        var current = _head;

        Console.Write("循环队列的值为:[ ");
        do
        {
            Console.Write(current.Data+" ");
            current = current.Next;
        } while (current!=_head);

        Console.WriteLine(" ]");
    }
}