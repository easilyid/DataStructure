namespace DataStructure.DataStructure.MyDirectory;

public class MyDictionary<TKey, TValue>
{
    private List<TKey> _keys;
    private List<TValue> _values;

    public MyDictionary()
    {
        _keys = new List<TKey>();
        _values = new List<TValue>();
    }

    public void Add(TKey key, TValue value)
    {
        _keys.Add(key);
        _values.Add(value);
    }

    public TValue this[TKey key]
    {
        get
        {
            var index = _keys.IndexOf(key);
            if (index == -1)
                throw new KeyNotFoundException();
            return _values[index];
        }
        set
        {
            var index = _keys.IndexOf(key);
            if (index == -1)
                throw new KeyNotFoundException();
            _values[index] = value;
        }
    }

    public bool ContainsKey(TKey key)
    {
        return _keys.Contains(key);
    }


    public bool Remove(TKey key)
    {
        int index = _keys.IndexOf(key);
        if (index == -1) return false;
        _keys.RemoveAt(index);
        _values.RemoveAt(index);
        return true;
    }
}

class DicTest
{
    public static void MyDictionaryTest1()
    {
        MyDictionary<int, string> myDictionary = new MyDictionary<int, string>();
        myDictionary.Add(1, "mac");
        myDictionary.Add(2, "苹果");
        myDictionary.Add(3, "安卓");
        myDictionary.Add(4, "Windows");

        Console.WriteLine(myDictionary[4]);
    }
}