namespace DataStructure.DataStructure.DataStack;

public class StackTest
{
    public static void ArrayStack()
    {
        int[] data = { 1, 2, 3, 4, 5 };
        DataArrayStack<int> stack = new DataArrayStack<int>();
        for (int i = 0; i < data.Length; i++)
        {
            stack.Push(data[i]);
        }
        stack.Print();
        Console.WriteLine("出栈的值为: "+stack.Pop());
        stack.Print();
        Console.WriteLine("当前栈顶的值为: "+stack.Peek());
        stack.Change(9,2);
        stack.Print();
    }
    public static void ArrayListStack()
    {
        int[] data = { 1, 2, 3, 4, 5 };
        DataArrayListStack<int> stack = new DataArrayListStack<int>();
        for (int i = 0; i < data.Length; i++)
        {
            stack.Push(data[i]);
        }
        stack.Print();
        Console.WriteLine("出栈的值为: "+stack.Pop());
        stack.Push(10);
        Console.WriteLine("当前栈顶的值为: "+stack.Peek());
        stack.Change(3,9);
        stack.Print();
    }
    
    public static void LinkedStack()
    {
        int[] data = { 1, 2, 3, 4, 5 };
        DataLinkedStack<int> stack = new DataLinkedStack<int>();
        for (int i = 0; i < data.Length; i++)
        {
            stack.Push(data[i]);
        }
        stack.Print();
        Console.WriteLine("出栈的值为: "+stack.Pop());
        stack.Push(10);
        Console.WriteLine("当前栈顶的值为: "+stack.Peek());
        stack.Change(3,9);
        stack.Print();
    }

    public static void SharedStack()
    {
        SharedStack<int> s = new SharedStack<int>(10);
        s.Push1(1);
        s.Push1(2);
        s.Push1(3);
        
        s.Push2(4);
        s.Push2(5);
        s.Push2(6);
        s.Print();
        Console.WriteLine("出栈元素为: "+s.Pop1());
        Console.WriteLine("出栈元素为: "+s.Pop2());
        s.Print();
        Console.WriteLine("栈顶元素为: "+s.Peek1());
        Console.WriteLine("栈顶元素为: "+s.Peek2());
        //Change方法有些bug TODO
        s.Change(2,7,9);
        s.Print();
    }
}