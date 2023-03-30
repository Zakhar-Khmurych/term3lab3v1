namespace term3lab3v1;

public class Dictionary
{
    public const int InitialSize = 10;
        
    private LinkedList[] _buckets = new LinkedList[InitialSize];

    private int loaded;
        
    public void Add(string key, string value)
    {
        int hashCode = CalculateHash(key);
        int index = hashCode % InitialSize;
        var addValue = new KeyValuePair(key, value);
        var first = _buckets[index];
        if (first == null)
        {
            _buckets[index] = new LinkedList();
            _buckets[index].Add(addValue);
            loaded++;
        }
        else
        {
            _buckets[index].Add(addValue);
            loaded++;
        }

        var a = loaded / InitialSize;
        if (a > 0.5)
        {
           ExpandArray();
        }
            
    }

    public void Remove(string key)
    {
        int hashCode = CalculateHash(key);
        int index = hashCode % InitialSize;
        var _first = _buckets[index];
        if (_first == null)
        {
            return;
        }
        _first.RemoveByKey(key);
    } 
        
    public string Get(string key)
    {
        string result = "not found";
        int hashCode = CalculateHash(key);
        int index = hashCode % InitialSize;
        var first = _buckets[index];
        var current = first.GetFirst();

        if (current == null) return result;
        while (current.Pair.Key != key)
        {
            current = current.Next;
            if (current == null) return result;
        }

        if (current.Pair.Key == key)
        {
            result = current.Pair.Value;
        }
        return result;
    }

    private void ExpandArray()
    {
        var resize = InitialSize*2;
        var newArray = new LinkedList[resize];
        foreach (var element in _buckets)
        {
            if (element == null)
            {
                continue;
            }
            var current = element.GetFirst();
            while (current != null)
            {
                int hash = CalculateHash(current.Pair.Key);
                int newIndex = hash % resize;
                var newfirst = newArray[newIndex];
                var currentPair = current.Pair;
                if (newfirst == null)
                {
                    newArray[newIndex] = new LinkedList(); 
                    newArray[newIndex].Add(currentPair); 
                    loaded += 1;
                }
                else 
                { 
                    newArray[newIndex].Add(currentPair); 
                    loaded += 1;
                } 
                current = current.Next;
            } 
        }
        loaded = 0;
        _buckets = newArray;
    }
        
    private int CalculateHash(string key)
    {
        int hash = 0;
        foreach (var letter in key)
        {
            hash += letter;
        }
            
        return hash % InitialSize;
    }
}