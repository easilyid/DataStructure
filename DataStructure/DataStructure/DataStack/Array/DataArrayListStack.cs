namespace DataStructure.DataStructure.DataStack.Array;

/// <summary>
/// 动态数组实现的栈
/// </summary>
public class DataArrayListStack<T> : IStack<T>
{
    private T[] _data;
    private int _top;

    public DataArrayListStack()
    {
        const int capacity = 10;
        _data = new T[capacity];
        _top = -1;
    }

    public DataArrayListStack(int capacity)
    {
        _data = new T[capacity];
        _top = -1;
    }

    public DataArrayListStack(T[] value)
    {
        _data = new T[value.Length];
        for (int i = 0; i < value.Length; i++)
        {
            _data[i] = value[i];
        }
        
        _top = value.Length - 1;
    }

    /// <summary>
    /// 入栈
    /// </summary>
    /// <param name="value"></param>
    public void Push(T value)
    {
        if (_top == _data.Length - 1)
        {
            ReSize(_data.Length + (_data.Length >> 1));
        }

        _top++;
        _data[_top] = value;
    }

    /// <summary>
    /// 出栈
    /// 返回删除的值
    /// </summary>
    public T Pop()
    {
        T tmp = default(T);
        if (_top == -1)
        {
            Console.WriteLine("栈为空！无法删除元素");
            return tmp;
        }

        tmp = _data[_top];
        _top--;
        if (_top + 1 < _data.Length / 2)
        {
            T[] newData = new T[_data.Length / 2];
            for (int i = 0; i <= _top; i++)
            {
                newData[i] = _data[i];
            }

            _data = newData;
        }

        return tmp;
    }

    /// <summary>
    /// 返回栈顶元素
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public T Peek()
    {
        if (_top==-1)
        {
            Console.WriteLine("栈为空！无法删除元素");
            return default;
        }

        return _data[_top];
    }


    public void Change(int top,T value)
    {
        if (_top==-1)
        {
            Console.WriteLine("栈为空");
        }
        else
        {
            _data[top] = value;
        }
    }

    public bool IsEmpty()
    {
        return _top == -1;
    }

    public int Count()
    {
        return _top = _data.Length-1;
    }

    public void Print()
    {
        if (_top==-1)
        {
            Console.WriteLine("栈为空！");
        }
        else
        {
            Console.Write("该栈中的元素(从栈顶到栈尾)为: ");
            // for (int i = 0; i < _data.Length; i++)
            // {
            //     Console.Write(_data[i]+" ");
            // }

            for (int i = _top; i >= 0; i--)
            {
                Console.Write($"{_data[i]}, ");
            }
            Console.WriteLine();
        }
        
    }

    /// <summary>
    /// 扩容
    /// </summary>
    private void ReSize(int newCapacity)
    {
        T[] newData = new T[newCapacity];
        if (newCapacity > _data.Length - 1)
        {
            for (int i = 0; i < _data.Length - 1; i++)
            {
                newData[i] = _data[i];
            }
        }
        else
        {
            for (int i = 0; i < newCapacity; i++)
            {
                newData[i] = _data[i];
            }
        }

        _data = newData;
    }
}