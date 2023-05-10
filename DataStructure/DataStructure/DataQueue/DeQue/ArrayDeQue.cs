namespace DataStructure.DataStructure.DataQueue.DeQue;

/// <summary>
/// 基于数组实现的双端队列
/// </summary>
public class ArrayDeQue<T>
{
    private T[] _data;
    private int _head;
    private int _tail;
    private int _size;

    public ArrayDeQue()
    {
        _data = new T[0];
        _size = 0;
    }

    public ArrayDeQue(int capacity)
    {
        _data = new T[capacity];
        _size = 0;
    }

    /// <summary>
    /// 头插
    /// </summary>
    /// <param name="value"></param>
    public void Enqueuefirst(T value)
    {
        //防止尾部出队之后的假溢出
        //需要使队头指针向前移动一位，然后再插入数据。
        //如果head指针和tail指针指向的位置相邻，并且队列中的元素个数等于容量n-1时，那么队列就已经满了
        if (_data.Length == 0 || (_tail + 1 + _data.Length) % _data.Length == _head)
        {
            int newCapacity = _data.Length == 0 ? 4 : _data.Length + (_data.Length >> 1);
            ReSize(newCapacity);
        }

        _head = (_head - 1 + _data.Length) % _data.Length;
        _data[_head] = value;
        _size++;
    }


    /// <summary>
    /// 尾插
    /// </summary>
    /// <param name="value"></param>
    public void Enqueuelast(T value)
    {
        if (_data.Length == 0 || _size == _data.Length - 1)
        {
            int newCapacity = _data.Length == 0 ? 4 : _data.Length + (_data.Length >> 1);
            ReSize(newCapacity);
        }

        _data[_tail] = value;
        _tail = (_tail + 1) % _data.Length;
        _size++;
    }

    public T Dequeuefirst()
    {
        if (IsEmpty())
        {
            Console.WriteLine("该队列为空!");
            return default;
        }

        T temp = _data[_head];
        _data[_head] = default(T);
        _head = (_head + 1) % _data.Length;
        if (_size == _data.Length / 2 && _data.Length / 2 != 0)
        {
            ReSize(_data.Length / 2 + 1);
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

        _tail = (_tail + _data.Length - 1) % _data.Length;
        T temp = _data[_tail];
        _data[_tail] = default;
        _size--;
        if (_size == _data.Length / 2 && _data.Length / 2 != 0)
        {
            ReSize(_data.Length / 2 + 1);
        }

        return temp;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("该队列为空!");
            return default;
        }

        return _data[_head];
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }

    public int Count()
    {
        return _size;
    }

    private void ReSize(int newCapacity)
    {
        T[] newData = new T[newCapacity];
        int index = 0;
        for (int i = _head; i != _tail; i = (i + 1) % _data.Length)
        {
            //Bug 值满的时候直接退出循环了
            newData[index++] = _data[i];
        }

        _data = newData;
        _head = 0;
        _tail = _size;
    }

    public void Print()
    {
        if (IsEmpty())
        {
            Console.WriteLine("该队列为空!");
            return;
        }

        Console.Write("该队列元素为: ");
        Console.Write("[ ");

        for (int i = _head; i != _tail; i = (i + 1) % _data.Length)
        {
            Console.Write(_data[i] + " ");
        }

        Console.WriteLine("]");
    }
}