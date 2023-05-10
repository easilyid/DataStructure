namespace DataStructure.DataStructure.DataQueue;

public class ArrayQueue<T> : IQueue<T>
{
    private T[] _data;
    private int _head;
    private int _tail;
    private int _size;

    public ArrayQueue()
    {
        _data = new T[0];
        _head = 0;
        _tail = 0;
        _size = 0;
    }

    public ArrayQueue(int capacity)
    {
        _data = new T[capacity];
        _head = 0;
        _tail = 0;
        _size = 0;
    }

    public void Enqueue(T value)
    {
        if (IsEmpty())
        {
            int newIndex = _data.Length == 0 ? 4 : _data.Length + (_data.Length >> 1);
            ReSize(newIndex);
        }

        _data[_tail] = value;
        _tail++;
        _size++;
    }

    private void ReSize(int newIndex)
    {
        T[] newData = new T[newIndex];

        for (int i = 0; i < _data.Length; i++)
        {
            newData[i] = _data[i];
        }

        _data = newData;
        _head = 0;
        _tail = _size;
    }

    public T Dequeue()
    {
        T temp = default;
        if (IsEmpty())
        {
            Console.WriteLine("该队列为空!");
            return default;
        }

        temp = _data[_head];
        //_data[_head] = default(T);
        _head++;
        
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

    public void Print()
    {
        if (IsEmpty())
        {
            Console.Write("该队列为空!");
            return;
        }

        Console.Write("该队列的元素为: [ ");
        //因为数组实现会导致原来数组的默认值0也被打印出来
        // for (int i = 0; i < _data.Length; i++)
        // {
        //     Console.Write(_data[i] + " ");
        // }

        //使用临时变量储存相关值，防止数据污染
        int i = _head;
        int s = _size;
        while ( s-- >0)
        {
            Console.Write(_data[i]+" ");
            i++;
        }

        Console.WriteLine("]");
    }
}