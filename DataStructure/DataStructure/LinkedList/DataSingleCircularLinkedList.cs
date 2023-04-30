namespace DataStructure.DataStructure.LinkedList;

/// <summary>
/// 单向循环链表
/// </summary>
///     node1        node2        node3
//     +------+    +------+    +------+
//     | data |    | data |    | data |
//     +------+    +------+    +------+
//     |next---|--->|next---|--->|next---|----> node1   
//     +------+    +------+    +------+
public class DataSingleCircularLinkedList<T>
{
    public class Node<T>
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 指针域
        /// </summary>
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node<T> _head;
    private Node<T> _tail;
    private int _size;

    public DataSingleCircularLinkedList()
    {
        _head = null;
        _tail = null;
        _size = 0;
    }

    public int Count => _size;

    public bool Contains(T value)
    {
        var current = _head;
        while (current.Next != _head)
        {
            if (current.Data.Equals(value))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public bool IsEmpty()
    {
        return _size == null;
    }

    public T this[int index]
    {
        get => GetIndexData(index).Data;
        set => GetIndexData(index).Data = value;
    }

    private Node<T> GetIndexData(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "索引不在范围内");
        }

        var current = _head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        return current;
    }

    public void Add(T value)
    {
        var newNode = new Node<T>(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            _tail.Next = _head;
            _size++;
            return;
        }

        //不是头节点就在尾节点后增加
        _tail.Next = newNode;
        _tail = newNode;
        _tail.Next = _head;
        _size++;
    }

    public void InSert(int index, T value)
    {
        if (index < 0 || index >= _size)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "索引不在范围内");
        }

        var newNode = new Node<T>(value);
        if (index == 0)
        {
            newNode.Next = _head;
            _head = newNode;
            _tail.Next = newNode;
        }
        else if (index == _size)
        {
            newNode.Next = _head;
            _tail = newNode;
            _tail.Next = _head;
        }
        else
        {
            var current = _head;
            Node<T> prev = null;
            for (int i = 0; i < index; i++)
            {
                prev = current; //插入的前一个位置
                current = current.Next; //要插入的位置
            }

            newNode.Next = current;
            prev.Next = newNode;
        }

        _size++;
    }

    public bool Remove(T value)
    {
        if (_head == null)
        {
            return false;
        }

        //头节点
        if (_head.Data.Equals(value))
        {
            //一个元素的情况
            if (_head == _tail)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _head = _head.Next;
                _tail.Next = _head;
            }

            _size--;
            return true;
        }

        var current = _head;
        Node<T> prev = null;
        while (current != _tail)
        {
            if (current.Data.Equals(value))
            {
                prev.Next = current.Next;
                _size--;
                return true;
            }

            prev = current; //删除的前一个位置
            current = current.Next; //要删除位置
        }

        return false;
    }

    public bool RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "索引不在范围内");
        }

        if (index == 0)
        {
            _head = _head.Next;
            if (_head == null)
            {
                _tail = null;
            }
            else
            {
                _tail.Next = _head;
            }

            _size--;
            return true;
        }
        else
        {
            var current = _head;
            Node<T> prev = null;
            for (int i = 0; i < index; i++)
            {
                prev = current;
                current = current.Next;
            }

            //prev是要删除的前一个位置 将他下一个指向 删除位置的下一个
            prev.Next = current.Next;
            if (current == _tail)
            {
                //如果删除的尾节点，那么删除的前一个位置做为节点
                _tail = prev;
            }

            _size--;
            return true;
        }

        return false;
    }

    public void Print()
    {
        if (_head==null)
        {
            Console.WriteLine("该链表为空");
        }
        else
        {
            var current = _head;

            do
            {
                Console.Write($"{current.Data} ->");
                current = current.Next;
            } while (current!=_head);

            Console.WriteLine($"{_head.Data}(Head)");
        }
    }
}