namespace DataStructure.DataStructure.LinkedList;

public class LinkedListTest
{
    /// <summary>
    /// ArrayList
    /// </summary>
    public static void Arraylist()
    {
        int[] data = { 1, 2, 3, 4, 5, 6 };
        DataArrayList<int> list = new DataArrayList<int>(data);
        list.Print();
        list.Add(7);
        list.Print();
        list.Insert(2, 8);
        list.Print();
        var res = list.IndexOf(5);
        Console.WriteLine("索引为" + res);
        list.Remove(4);
        list.Print();
        var b = list.IsEmpty();
        Console.WriteLine(b);
        list.RemoveAt(3);
        list.Print();
        list.Clear();
    }

    /// <summary>
    /// 单向链表
    /// </summary>
    public static void Single()
    {
        int[] data = { 1, 2, 3, 4, 5, 6 };
        DataSingleLinkedList<int> list = new DataSingleLinkedList<int>();
        foreach (var i in data)
        {
            list.AddLast(i);
        }

        list.Print();
        list.AddFirst(7);
        list.Print();
        list.InSert(2, 8);
        list.Print();
        list.Remove(4);
        list.Print();
        list.RemoveAt(3);
        list.Print();
        list.Clear();
    }

    /// <summary>
    /// 双向链表
    /// </summary>
    public static void DoublyLinkedList()
    {
        int[] data = { 1, 2, 3, 4, 5, 6 };
        DataDoublyLinkedList<int> list = new DataDoublyLinkedList<int>();
        foreach (var i in data)
        {
            list.AddLast(i);
        }

        list.Print();
        list.AddLast(7);
        list.Print();
        list.AddLast(9);
        list.Insert(0, 8);
        list.Print();
        list.Remove(5);
        list.Print();
        list.RemoveAt(4);
        list.Print();
    }

    /// <summary>
    /// 单向循环链表
    /// </summary>
    public static void SingleCircular()
    {
        int[] data = { 1, 2, 3, 4, 5, 6 };
        DataSingleCircularLinkedList<int> list = new DataSingleCircularLinkedList<int>();
        foreach (var i in data)
        {
            list.Add(i);
        }

        list.Print();
        list.Add(7);
        list.Print();
        list.InSert(0, 8);
        list.Print();
        list.Remove(4);
        list.Print();
        list.RemoveAt(0);
        list.Print();
    }
    
    /// <summary>
    /// 双向循环链表
    /// </summary>
    public static void DoublyCircular()
    {
        int[] data = { 1, 2, 3, 4, 5, 6 };
        DataDoublyCircularLinkedList<int> list = new DataDoublyCircularLinkedList<int>();
        foreach (var i in data)
        {
            list.Add(i);
        }

        list.Print();
        list.Add(7);
        list.Print();
        list.InSert(0, 8);
        list.Print();
        list.Remove(4);
        list.Print();
        list.RemoveAt(0);
        list.Print();
    }
}