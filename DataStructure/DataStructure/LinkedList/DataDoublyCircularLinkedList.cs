namespace DataStructure.DataStructure.LinkedList;

//双向循环链表
public class DataDoublyCircularLinkedList<T>
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    private Node<T> _head;
    private Node<T> _tail;
    private int _size;

    public DataDoublyCircularLinkedList()
    {
        _size = 0;
    }

    public int Count => _size;

    public bool Contains(T value)
    {
        if (_head==null)
        {
            return false;
        }
        var current = _head;
        do
        {
            if (current.Data.Equals(value))
            {
                return true;
            }

            current = current.Next;
        } while (current!=_head);
        return false;
    }

    public T this[int index]
    {
        get => GetIndexData(index).Data;
        set => GetIndexData(index).Data = value;
    }

    private Node<T> GetIndexData(int index)
    {
        if (index<0||index>=_size)
        {
            throw new IndexOutOfRangeException("索引不在范围内");
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
        if (_head==null)
        {
            _head = newNode;
            _tail = newNode;
            _tail.Next = _head;
        }
        else
        {
            newNode.Next = _head;
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _head.Prev = newNode;
            _tail = newNode;
        }

        _size++;
    }

    public void InSert(int index, T value)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException("索引不在范围内");
        }
        
        var newNode = new Node<T>(value);
        if (index==0)
        {//头步插入
            newNode.Next = _head;
            newNode.Prev = _tail;
            _head.Prev = newNode;
            _tail.Next = newNode;
            _head = newNode;
        }else if (index==_size-1)
        {//尾部
            newNode.Prev = _tail;
            _tail.Next = newNode;
            newNode.Next = _head;
            _head.Prev = newNode;
            _tail = newNode;
        }
        else
        {
            var current = _head;
            //找到插入的前一个位置
            for (int i = 0; i < index-1; i++)
            {
                current = current.Next;
            }

            current.Next = newNode;
            current.Next.Prev = newNode;
            newNode.Next = current.Next;
            newNode.Prev = current;
        }

        _size++;
    }

    public bool Remove(T value)
    {
        if (_head==null)
        {
            return false;
        }
        var current = _head;

        while (current!=null)
        {
            if (current.Data.Equals(value))
            {
                if (current==_head)
                {//删头
                    _head = _head.Next;
                    current.Next.Prev = _tail;
                    _tail.Next = _head;
                }
                else if (current==_tail)
                {//删尾
                    _tail.Prev.Next = _head;
                    _head.Prev = current.Prev;
                    _tail = current.Prev;
                }
                else
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                }

                _size--;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public bool RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException("索引不在范围内");
        }

       
        if (index==0)
        {
            _head = _head.Next;
            _tail.Next = _head;
            _size--;
            return true;
        }else if (index==_size-1)
        {
            _tail = _tail.Prev;
            _tail.Next = _head;
            _size--;
            return true;
        }
        else
        {
            var current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current = current.Next;
            current.Next.Prev = current.Prev;
            current.Prev.Next = current.Next;
            _size--;
            return true;
        }
    }

    public void Print()
    {
        var current = _head;
        if (_head==null)
        {
            return;
        }
        while (current!=null)
        {
            if (current==_head)
            {
                Console.Write($"[{current.Data}]head ");
            }
            else
            {
                Console.Write($"{current.Data}");
            }

            if (current.Next!=null)
            {
                Console.Write("<->");
            }

            current = current.Next;
            if (current==_head)
            {
                break;
            }
        }

        Console.WriteLine($" head[{current.Data}]");
    }
}