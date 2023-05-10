namespace DataStructure.DataStructure.DataQueue.Priority;

/// <summary>
/// 基于数组实现的优先队列
/// 队列里的元素带优先级
/// </summary>
public class ArrayPriorityQueue<T>
{
    public struct PriorityValue
    {
        /// <summary>
        /// 数值
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }
    }

    private PriorityValue[] _heap;
    private int _size;

    public ArrayPriorityQueue(int capacity)
    {
        _heap = new PriorityValue[capacity];
        _size = 0;
    }

    public void Enqueue(T value, int priority)
    {
        //添加值到数组的尾部
        _heap[_size] = new PriorityValue { Data = value, Priority = priority };
        //添加到正确的索引里
        int index = _size;
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            //如果当前元素的优先级更高则上移
            if (_heap[parentIndex].Priority > _heap[index].Priority)
            {
                //交换两个索引的值
                (_heap[parentIndex], _heap[index]) = (_heap[index], _heap[parentIndex]);
                //移动到父节点
                index = parentIndex;
            }
            else
            {
                //现在移动到正确位置了
                break;
            }
        }

        _size++;
    }

    public T Dequeue()
    {
        T result = _heap[0].Data;
        _size--;
        // 把最后一个元素放到根节点上
        _heap[0] = _heap[_size];
        _heap[_size] = new PriorityValue();

        int index = 0;
        while (true)
        {
            int leftchildIndex = index * 2 + 1;
            int rightchildIndex = index * 2 + 2;
            int minValue = _heap[index].Priority;
            int minIndex = index;

            if (leftchildIndex < _size && _heap[leftchildIndex].Priority < minValue)
            {
                minValue = _heap[leftchildIndex].Priority;
                minIndex = leftchildIndex;
            }

            if (rightchildIndex < _size && _heap[rightchildIndex].Priority < minValue)
            {
                minValue = _heap[rightchildIndex].Priority;
                minIndex = rightchildIndex;
            }

            if (minIndex != index)
            {
                (_heap[index], _heap[minIndex]) = (_heap[minIndex], _heap[index]);
                index = minIndex;
            }
            else
            {
                break;
            }
        }

        return result;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("该队列为空!");
            return default;
        }

        return _heap[0].Data;
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

        Console.WriteLine("该优先队列的元素为: ");
        for (int i = 0; i < _size; i++)
        {
            Console.WriteLine($"值:{_heap[i].Data},优先级:{_heap[i].Priority}");
        }
    }
}