namespace DataStructure.DataStructure.DataQueue.DeQue;

/// <summary>
/// 基于链表实现的双端队列
/// </summary>
public class LinkedDeQue<T>
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
    private int _size;

    public LinkedDeQue()
    {
        _head = null;
        _tail = null;
        _size = 0;
    }

    public void Enqueuefirst(T value)
    {
        var newNode = new Node(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }

        _size++;
    }

    public void Enqueuelast(T value)
    {
        var newNode = new Node(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }

        _size++;
    }

    public T Dequeuefirst()
    {
        if (IsEmpty())
        {
            Console.WriteLine("该队列为空!");
            return default;
        }
        T temp = _head.Data;
        if (_size==1)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = _head.Next;
            _head.Prev = null;
        }
        _size--;

        return temp;
    }

    public T Dequeuelast()
    {
        if (IsEmpty())
        {
            Console.WriteLine("该队列为空!");
            return default;
        }

        T temp = _tail.Data;

        if (_size == 1)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.Prev;
            _tail.Next = null;
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

        Console.Write("该队列的值为: [ ");
        var current = _head;

        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }

        Console.WriteLine("]");
    }
}