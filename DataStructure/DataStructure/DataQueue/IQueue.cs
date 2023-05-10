namespace DataStructure.DataStructure.DataQueue;


public interface IQueue<T>
{
    /// <summary>
    /// 入队
    /// </summary>
    /// <param name="value"></param>
    void Enqueue(T value);
    /// <summary>
    /// 出队
    /// 返回出队的值
    /// </summary>
    /// <returns></returns>
    T Dequeue();
    /// <summary>
    /// 查询队首元素
    /// </summary>
    /// <returns></returns>
    T Peek();

    bool IsEmpty();
    int Count();

    void Print();
}