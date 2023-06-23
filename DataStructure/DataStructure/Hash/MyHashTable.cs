namespace DataStructure.DataStructure.Hash;

public class MyHashTable
{
    private const int Capacity = 10;
    private readonly LinkedList<KeyValuePair<int, object>>[] _buckets; //KeyValuePair 定义可以设置或检索的键/值对。


    public MyHashTable()
    {
        _buckets = new LinkedList<KeyValuePair<int, object>>[Capacity];
    }

    int GetBucketIndex(int key)
    {
        return key % Capacity;
    }

    void Add(int key, object value)
    {
        int bucketIndex = GetBucketIndex(key);
        if (_buckets[bucketIndex] == null)
        {
            _buckets[bucketIndex] = new LinkedList<KeyValuePair<int, object>>();
        }

        foreach (var item in _buckets[bucketIndex])
        {
            if (item.Key == key)
            {
                throw new ArgumentException("已经存在相同的键");
            }
        }

        _buckets[bucketIndex].AddLast(new KeyValuePair<int, object>(key, value));
    }

    public bool ContainsKey(int key)
    {
        int bucketIndex = GetBucketIndex(key);
        if (_buckets[bucketIndex] != null)
        {
            foreach (var item in _buckets[bucketIndex])
            {
                if (item.Key == key)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public object this[int key]
    {
        get
        {
            int index = GetBucketIndex(key);
            if (_buckets[index] != null)
            {
                foreach (var item in _buckets[index])
                {
                    if (item.Key == key)
                    {
                        return item.Key;
                    }
                }
            }

            throw new KeyNotFoundException("Hashtable中不存在给定的键。");
        }
    }

    public void Remove(int key)
    {
        int bucketIndex = GetBucketIndex(key);
        if (_buckets[bucketIndex] != null)
        {
            LinkedListNode<KeyValuePair<int, object>> currentNode = _buckets[bucketIndex].First;
            while (currentNode != null)
            {
                if (currentNode.Value.Key == key)
                {
                    _buckets[bucketIndex].Remove(currentNode);
                    return;
                }

                currentNode = currentNode.Next;
            }
        }

        throw new KeyNotFoundException("Hashtable中不存在给定的键。");
    }

    public void Clear()
    {
        for (int i = 0; i < Capacity; i++)
        {
            _buckets[i] = null;
        }
    }
}