namespace DataStructure.DataStructure.LinkedList;

/// <summary>
/// 动态数组
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataArrayList<T>
{
    private T[] _arr;
    private int _size;
    private int capaticy;

    public DataArrayList()
    {
        const int DefaultCapaticy = 10;
        _arr = new T[DefaultCapaticy];
    }

    public DataArrayList(int Capaticy)
    {
        if (Capaticy > 0)
        {
            _arr = new T[Capaticy];
            this.capaticy = Capaticy;
            this._size = 0;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public DataArrayList(T[] data)
    {
        this._arr = new T[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            _arr[i] = data[i];
        }

        _size = data.Length;
    }

    public int Count
    {
        get { return _size; }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException();
            }

            return _arr[index];
        }
        set
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException();
            }

            _arr[index] = value;
        }
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }

    /// <summary>
    /// 添加元素
    /// </summary>
    /// <param name="data"></param>
    public void Add(T data)
    {
        if (_size == _arr.Length)
        {
            ReSize(_arr.Length + (_arr.Length >> 1));
        }

        _arr[_size++] = data;
    }

    /// <summary>
    /// 扩容
    /// </summary>
    private void ReSize(int newCapaticy)
    {
        T[] newarr = new T[newCapaticy];
        for (int i = 0; i < _size; i++)
        {
            newarr[i] = _arr[i];
        }

        _arr = newarr;
        capaticy = newCapaticy;
    }

    /// <summary>
    /// 在指定索引插入一个元素
    /// </summary>
    /// <param name="index">索引</param>
    /// <param name="data">元素</param>
    public void Insert(int index, T data)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException();
        }

        if (_size == _arr.Length)
        {
            ReSize(_arr.Length + _arr.Length >> 1);
        }

        //记住
        // for (int i = _size; i >= index; i--)
        // {
        //     _arr[i] = _arr[i - 1];
        // }
        // _arr[index] = data;
        // _size++;

        Array.Copy(_arr, index,
            _arr, index + 1, _size - index);
        _arr[index] = data;
        _size++;
    }


    /// <summary>
    /// 查找元素索引
    /// </summary>
    public int IndexOf(T data)
    {
        for (int i = 0; i < _size; i++)
        {
            // ！空值协定，假定_arr[i]不为空 
            if (_arr[i]!.Equals(data))
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// 删除指定元素
    /// </summary>
    public bool Remove(T data)
    {
        int index = IndexOf(data);
        if (index != -1)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException();
        }

        // for (int i = index + 1; i < _size; i++)
        // {
        //     _arr[i - 1] = _arr[i];
        // }
        // _size--;
        // _arr[_size] = default;
        // if (_size == _arr.Length/4&&_arr.Length/2!=0)
        // {
        //     ReSize(_arr.Length/2);
        // }

        //将要移除元素的后一位向前移1位，然后将多的复制那个数改为0减去有效元素
        Array.Copy(_arr, index + 1, _arr,
            index, _size - index - 1);
        _size--;
        _arr[_size] = default;
       // _arr[--_size] = default;
    }

    public void Clear()
    {
        _arr = new T[capaticy];
        this._size = 0;
        Console.WriteLine("DataArrayList Clear");
    }
    
    public void Print()
    {
        if (_size!=0)
        {
            string str = "";
            foreach (var i in _arr)
            {
                str = str + i + ",";
            }

            Console.WriteLine("["+str.Substring(0,str.Length-1)+"]");
        }

        if (_size==0)
        {
            Console.WriteLine("DataArrayList 无元素");
        }
    }
}