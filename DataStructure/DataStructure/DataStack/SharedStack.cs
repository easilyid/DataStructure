namespace DataStructure.DataStructure.DataStack;

/// <summary>
/// 共享栈 数组实现
/// 将两个栈共用一个数组实现的栈，也称为双向栈。
/// 共享栈中两个栈的栈顶分别位于数组的两端，可以实现两个栈的同时操作
/// </summary>
public class SharedStack<T>
{
    private T[] _data;

    /// <summary>
    /// 栈1的指针
    /// 从左往右
    /// </summary>
    private int _top1;

    /// <summary>
    /// 栈2的指针
    /// 从右往左
    /// </summary>
    private int _top2;

    public SharedStack(int capacity)
    {
        _data = new T[capacity];
        _top1 = -1;
        _top2 = capacity;
    }


    public void Push1(T value)
    {
        if (IsFull())
        {
            Console.WriteLine("堆栈已满!");
            return;
        }

        _data[++_top1] = value;
    }

    public void Push2(T value)
    {
        if (IsFull())
        {
            Console.WriteLine("堆栈已满!");
            return;
        }

        _data[--_top2] = value;
    }

    public T Pop1()
    {
        T temp = default;
        if (IsEmpty1())
        {
            Console.WriteLine("堆栈为空!");
            return default;
        }

        temp = _data[_top1];
        _data[_top1] = default;
        _top1--;
        return temp;
    }

    public T Pop2()
    {
        T temp = default;
        if (IsEmpty2())
        {
            Console.WriteLine("堆栈为空!");
            return default;
        }

        temp = _data[_top2];
        _data[_top2] = default;
        _top2++;
        return temp;
    }

    public T Peek1()
    {
        if (IsEmpty1())
        {
            Console.WriteLine("堆栈为空!");
            return default;
        }

        return _data[_top1];
    }

    public T Peek2()
    {
        if (IsEmpty2())
        {
            Console.WriteLine("堆栈为空!");
            return default;
        }

        return _data[_top2];
    }


    /// <summary>
    /// 修改共享栈的栈值
    /// </summary>
    /// <param name="stackNumber">堆栈号</param>
    /// <param name="index">下标</param>
    /// <param name="value">值</param>
    public void Change(int stackNumber, int index, T value)
    {
        if (stackNumber < 1 || stackNumber > 2)
        {
            Console.WriteLine("无效的堆栈号");
            return;
        }

        if ((stackNumber == 1 && index >= (_top1+1)) || (stackNumber == 2 && index <= _data.Length-_top2))
        {
            Console.WriteLine($"索引{index}超出堆栈{stackNumber}范围");
            return;
        }

        int realindex = (stackNumber == 1) ? index : _data.Length - _top2+index;
        _data[realindex] = value;
    }

    public bool IsEmpty1()
    {
        return _top1 == -1;
    }

    public bool IsEmpty2()
    {
        return _top2 == _data.Length;
    }

    public int Count1()
    {
        return _top1 + 1;
    }

    public int Count2()
    {
        //栈2的指针是从后往前走
        return _data.Length - _top2;
    }

    public bool IsFull()
    {
        return _top2 - _top1 == 1;
    }

    public void Print()
    {
        if (IsEmpty1() && IsEmpty2())
        {
            Console.WriteLine("堆栈为空! ");
            return;
        }

        //ps：注意这里的遍历
        Console.Write("Stack1: ");
        for (int i = _top1; i >= 0; i--)
        {
            Console.Write(_data[i] + " ");
        }

        Console.Write("\t Stack2: ");
        //ps: 注意这个遍历，
        for (int i = _top2; i < _data.Length; i++)
        {
            Console.Write(_data[i] + " ");
        }

        Console.WriteLine();
    }
}