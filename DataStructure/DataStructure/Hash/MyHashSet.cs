namespace DataStructure.DataStructure.Hash;

//哈希Set是基于哈希表实现的 哈希表是基于数组和链表  set中元素是唯一的
//Hashtable中 值是能重复的 键是唯一的 set泛型 table非泛型

public class MyHashSet<T> where T : notnull
{
    private Dictionary<T, bool> dict;

    public MyHashSet()
    {
        dict = new Dictionary<T, bool>();
    }

    public void Add(T value)
    {
        if (!dict.ContainsKey(value))
        {
            dict.Add(value, true);
        }
    }

    public bool Contains(T value)
    {
        return dict.ContainsKey(value);
    }

    public void Delete(T value)
    {
        dict.Remove(value);
    }

    public void Clear()
    {
        dict.Clear();
    }
    
    
}


