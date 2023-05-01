namespace DataStructure.DataStructure.DataStack;

/// <summary>
/// 基于数组的栈
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataArrayStack<T>: IStack<T>
{
    private T[] _data;
    /// <summary>
    /// 栈顶指针
    /// </summary>
    private int _top;

    public DataArrayStack()
    {
        const int capacity = 10;
        _data = new T[capacity];
        _top = -1;
    }
    
    public DataArrayStack(int capacity)
    {
        _data = new T[capacity];
        _top = -1;
    }
    
    /// <summary>
    /// 入栈
    /// </summary>
    /// <param name="value"></param>
    public void Push(T value)
    {
        if (_top == _data.Length-1) 
        {
            Console.WriteLine(); 
        }

        _top++;
        _data[_top] = value;
    }

    /// <summary>
    /// 出栈
    /// 移除并返回栈顶元素
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public T Pop()
    {
        T tmp = default;
        if (_top==-1)
        {
            Console.WriteLine("栈为空，无法删除元素");
            return tmp;
        }

        tmp = _data[_top];
        _top--;
        return tmp;
    }

    /// <summary>
    /// 获取栈顶元素
    /// </summary>
    /// <returns></returns>
    public T Peek()
    {
        if (_top==-1)
        {
            Console.WriteLine("栈为空，无法获取元素");
            return default;
        }

        return _data[_top];
    }

    /// <summary>
    /// 修改栈的元素
    /// </summary>
    /// <param name="newValue">元素</param>
    /// <param name="top">指针的位置</param>
    public void Change(T newValue, int top)
    {
        if (_top==-1)
        {
            Console.WriteLine("栈为空，无法修改");
        }
        else
        {
            _data[top] = newValue;
        }
    }
    
    public bool IsEmpty()
    {
        return _top == -1;
    }

    public int Count()
    {
        return _top + 1;
    }

    
    
    public void Print()
    {
        if (_top==-1)
        {
            Console.WriteLine("栈为空 ！");
        }
        else
        {
            Console.Write("当前栈中的元素为(从栈顶到栈尾): ");
            for (int i = _top; i >= 0; i--)
            {
                Console.Write($"{_data[i]}, ");
            }
        }

        Console.WriteLine();
    }
}