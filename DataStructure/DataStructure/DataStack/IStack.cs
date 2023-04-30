namespace DataStructure.DataStructure.DataStack;

public interface IStack<T>
{
    void Push(T value);
    T Pop();
    T Peek();
    bool IsEmpty();
    int Count();
    void Print();
}