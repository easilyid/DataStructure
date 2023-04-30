namespace DataStructure.DataStructure.LinkedList;

/// <summary>
/// 单向链表
///  _____    _____    _____    _____    _____
/// |     |  |     |  |     |  |     |  |     |
/// |  A  |->|  B  |->|  C  |->|  D  |->|  E  |
/// |_____|  |_____|  |_____|  |_____|  |_____|
/// </summary>
public class DataSingleLinkedList<T>
{
    public class Node<T>
    {
        /// <summary>
        /// 指针域
        /// </summary>
        public Node<T> Next;

        /// <summary>
        /// 节点值
        /// </summary>
        public T Data;

        public Node(T data = default, Node<T> next = null)
        {
            Data = data;
            Next = next;
        }
    }

    private Node<T> _head;
    private int _size;

    public DataSingleLinkedList()
    {
        _head = null;
        _size = 0;
    }

    public int Count => _size;

    public bool Contains(T value)
    {
        var current = _head;
        while (current != null)
        {
            if (Equals(current.Data, value))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public void Print()
    {
        var current = _head;
        while (current != null)
        {
            Console.Write(current.Data + "->");
            current = current.Next;
        }

        Console.Write("null \n");
    }

    public void Clear()
    {
        _head = null;
        _size = 0;
        
    }

    public T this[int index]
    {
        get { return GetindexOf(index).Data; }
        set { GetindexOf(index).Data = value; }
    }

    public Node<T> GetindexOf(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "输入的索引越界");
        }

        var current = _head;
        // int count = 0;
        // while (current != null && count < index - 1)
        // {
        //     current = current.Next;
        //     count++;
        // }
        // return current;

        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        return current;
    }


    public void AddFirst(T data)
    {
        _head = new Node<T>(data, _head);
        _size++;
    }

    public void AddLast(T value)
    {
        if (_head == null)
        {
            AddFirst(value);
            return;
        }

        Node<T> current = _head;
        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = new Node<T>(value);
        _size++;
    }

    public void InSert(int index, T value)
    {
        if (_head == null)
        {
            AddFirst(value);
            return;
        }

        var current = _head;
        int count = 0;
        while (current != null && count < index - 1)
        {
            current = current.Next;
            count++;
        }

        if (current == null)
        {
            return;
        }
        current.Next = new Node<T>(value, current.Next);
        _size++;
    }

    public bool Remove(T value)
    {
        if (_head==null)
        {
            return false;
        }
        
        if (_head.Data.Equals(value))
        {
            _head = _head.Next;
            _size--;
            return true;
        }
        
        var current = _head.Next;
        var prev = _head;
        while (current!=null)
        {
            if (Equals(current.Data,value))
            {
                prev.Next = current.Next;
                _size--;
                return true;
            }

            prev = current;
            current = current.Next;
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (index<0||index>=_size)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "索引不合规");
        }

        var delNode = GetindexOf(index).Data;
        Remove(delNode);
    }
}