namespace DataStructure.DataStructure.DataQueue;

/// <summary>
/// 基于链表实现的队列
/// </summary>
public class LinkedQueue<T>: IQueue<T>
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T>? Next { get; set; }
        public Node(T value, Node<T>? next=null)
        {
            Data = value;
            Next = next;
           
        }
    }

    private Node<T>? _head;
    private Node<T>? _tail;
    private int _size;

    public LinkedQueue()
    {
        _head = null;
        _tail = null;
        _size = 0;
    }
    
    
    
    public void Enqueue(T value)
    {
        var newNode = new Node<T>(value);
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
        if (_head==_tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = _head.Next;
        }
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
        Console.Write("当前队列元素为: [ ");
        while (current!=null)
        {
            Console.Write(current.Data+" ");
            current = current.Next;
        }

        Console.WriteLine("]");
    }
}