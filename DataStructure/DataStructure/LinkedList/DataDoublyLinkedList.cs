namespace DataStructure.DataStructure.LinkedList;

/// <summary>
/// 双向链表
/// </summary>
public class DataDoublyLinkedList<T>
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

    public DataDoublyLinkedList()
    {
        _head = null;
        _tail = null;
        _size = 0;
    }

    public int Count => _size;

    public bool IsEmpty()
    {
        return _size == null;
    }

    public bool Contains(T value)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data.Equals(value))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
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

    public void AddFirst(T value)
    {
        var newNode = new Node<T>(value);
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

    public void AddLast(T value)
    {
        var newNode = new Node<T>(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }

        _size++;
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

    public void Insert(int index, T value)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException("索引不在范围内");
        }

        var NewNode = new Node<T>(value);
        if (index == 0)
        {
            if (_head == null)
            {
                _head = NewNode;
                _tail = NewNode;
            }
            else
            {
                NewNode.Next = _head;
                _head.Prev = NewNode;
                _head = NewNode;
            }
        }
        else if (index == _size - 1)
        {
            NewNode.Prev = _tail;
            _tail.Next = NewNode;
            _tail = NewNode;
        }
        else
        {
            var current = _head;
            //记住要找插入的前一个位置，所以要减1
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            //将新节点的前一个节点设置为要插入位置的前一个节点
            NewNode.Prev = current;
            //插入数据的下一个指针，指向要插入节点上原本的数据
            NewNode.Next = current.Next;
            //要插入的前一个指针指向为插入的节点， 
            current.Next.Prev = NewNode;
            //然后将插入前一个位置的下指针指向插入的数据 插入完成
            current.Next = NewNode;
        }
        _size++;
    }


    public bool Remove(T value)
    {
        var current = _head;
        while (current!=null)
        {
            if (current.Data.Equals(value))
            {
                if (current==_head)
                {
                    _head = _head.Next;
                }else if (current==_tail)
                {
                    _tail = current.Prev;
                    _tail.Next = null;
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
        if (index<0||index>=_size)
        {
            throw new IndexOutOfRangeException("索引不在范围内");
        }
        if (index==0)
        {
            if (_head!=null)
            {
                _head = _head.Next;
                _size--;
                return true;
            }   
        }
        else if (index == _size - 1)
        {
            _tail = _tail.Prev;
            _tail.Next = null;
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
            //通过循环得到要删除的位置
            //前一个位置的下指针指向删除位置下一个值
            //下一个位置的前指针指向删除位置的前一个值
            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev;
            _size--;
            return true;
        }

        return false;
    }
}