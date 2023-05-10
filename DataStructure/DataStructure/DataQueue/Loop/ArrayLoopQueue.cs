namespace DataStructure.DataStructure.DataQueue.Loop;

/// <summary>
/// 基于数组实现的循环队列
/// </summary>
/// <typeparam name="T"></typeparam>
public class ArrayLoopQueue<T> : IQueue<T>
{
    private T[] _data;
    private int _head;
    private int _tail;
    private int _size;

    public ArrayLoopQueue()
    {
        _data = new T[0];
        _head = 0;
        _tail = 0;
    } 

    public ArrayLoopQueue(int capacity)
    {
        _data = new T[capacity];
        _head = 0;
        _tail = 0;
        _size = 0;
    }

    public void Enqueue(T value)
    {
        //因为循环队列在无元素和满元素的时候  head都等于tail
        if (_data.Length == 0||(_tail + 1) % _data.Length == _head)
        {
            int newCapacity = _data.Length == 0 ? 4 : _data.Length + (_data.Length >> 1);
            ReSize(newCapacity);
        }
        
        _data[_tail] = value;
        _tail = (_tail + 1) % _data.Length;
        _size++;
    }

    private void ReSize(int newCapacity)
    {
        var newData = new T[newCapacity];
        for (int i = 0; i < _data.Length; i++)
        {
            newData[i] = _data[(_head + i) % _data.Length];
        }

        _data = newData;
        _head = 0;
        _tail = _size;
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            Console.WriteLine("该队列为空!");
            return default;
        }

        T temp = _data[_head];
        _head = (_head + 1) % _data.Length;
        _size--;
        return temp;
    }

    public T Peek()
    {
        if(IsEmpty()){
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
            Console.WriteLine("该队列为空!");
            return;
        }

        Console.Write("该队列元素为: [ ");
        for (int i = _head; i != _tail; i = (i + 1) % _data.Length)
        {
            Console.Write(_data[i] + " ");
        }

        Console.WriteLine("]");
    }
}