using DataStructure.DataStructure.DataQueue.DeQue;
using DataStructure.DataStructure.DataQueue.Loop;
using DataStructure.DataStructure.DataQueue.Priority;

namespace DataStructure.DataStructure.DataQueue;

public class QueueTest
{
    public static void ArrayQueue()
    {
        ArrayQueue<int> a = new ArrayQueue<int>(5);
        a.Enqueue(1);
        a.Enqueue(2);
        a.Enqueue(6);
        a.Enqueue(3);
        a.Print();
        Console.WriteLine("出队的值为: " + a.Dequeue());
        a.Print();
        Console.WriteLine("队首的值为: " + a.Peek());

    }
    
    public static void LinkedQueue()
    {
        LinkedQueue<int> q = new LinkedQueue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(6);
        q.Enqueue(3);
        q.Print();
        Console.WriteLine("出队的值为: " + q.Dequeue());
        q.Print();
        Console.WriteLine("队首的值为: " + q.Peek());

    }
    
    
    public static void ArrayPriorityQueue()
    {
        ArrayPriorityQueue<int> q = new ArrayPriorityQueue<int>(6);
        q.Enqueue(1,5);
        q.Enqueue(2,1);
        q.Enqueue(6,3);
        q.Enqueue(3,2);
        q.Print();
        Console.WriteLine("出队的值为: " + q.Dequeue());
        q.Print();
        Console.WriteLine("队首的值为: " + q.Peek());

    }
    
    public static void LinkedPriorityQueue()
    {
        LinkedPriorityQueue<int> q = new LinkedPriorityQueue<int>();
        q.Enqueue(1,5);
        q.Enqueue(2,1);
        q.Enqueue(6,3);
        q.Enqueue(3,2);
        q.Print();
        Console.WriteLine("出队的值为: " + q.Dequeue());
        q.Print();
        Console.WriteLine("队首的值为: " + q.Peek());

    }


    public static void ArrayLoopQueue()
    {
        ArrayLoopQueue<int> l = new ArrayLoopQueue<int>();
        l.Enqueue(1);
        l.Enqueue(2);
        l.Print();
        Console.WriteLine("出队的值为: " + l.Dequeue());
        l.Print();
        Console.WriteLine("队首的值为: " + l.Peek());
    }
    
    public static void LinkedLoopQueue()
    {
        LinkedLoopQueue<int> l = new LinkedLoopQueue<int>();
        l.Enqueue(1);
        l.Enqueue(2);
        l.Enqueue(3);
        l.Enqueue(4);
        l.Enqueue(5);
        l.Print();
        Console.WriteLine("出队的值为: " + l.Dequeue());
        l.Print();
        Console.WriteLine("队首的值为: " + l.Peek());
    }
    
    
    public static void ArrayDeQue()
    {
        ArrayDeQue<int> l = new ArrayDeQue<int>();
        l.Enqueuefirst(1);
        l.Enqueuefirst(2);
        l.Enqueuefirst(3);
        l.Enqueuefirst(4);
        l.Enqueuefirst(5);
        l.Enqueuefirst(6);
        
        l.Enqueuelast(7);
        l.Enqueuelast(8);
        l.Enqueuelast(9);
        l.Enqueuelast(10);
        l.Enqueuefirst(11);
        l.Enqueuelast(12);
        
        l.Print();
        Console.WriteLine("队首出队的值为: " + l.Dequeuefirst());
        Console.WriteLine("队尾出队的值为: " + l.Dequeuelast());
        l.Print();
        Console.WriteLine("队首的值为: " + l.Peek());
    }
    
    
    
    public static void LinkedDeQue()
    {
        LinkedDeQue<int> l = new LinkedDeQue<int>();
        l.Enqueuefirst(1);
        l.Enqueuefirst(2);
        l.Enqueuefirst(3);
        l.Enqueuefirst(4);
        l.Enqueuefirst(5);
        l.Enqueuefirst(6);
        
        l.Enqueuelast(7);
        l.Enqueuelast(8);
        l.Enqueuelast(9);
        l.Enqueuelast(10);
        
        l.Enqueuefirst(11);
        l.Enqueuelast(12);
        
        l.Print();
        Console.WriteLine("队首出队的值为: " + l.Dequeuefirst());
        Console.WriteLine("队尾出队的值为: " + l.Dequeuelast());
        l.Print();
        Console.WriteLine("队首的值为: " + l.Peek());
    }
}