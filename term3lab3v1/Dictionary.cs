using System.Linq;

namespace term3lab3v1;

public class Dictionary
{
    public static int InitialSize = 10;
        
    private LinkedList[] _buckets = new LinkedList[InitialSize];

    private int _loaded;
        
    public void Add(string key, string value)
    {
        int hashCode = CalculateHash(key);
        int index = hashCode % InitialSize;
        var addValue = new KeyValuePair(key, value);
        var bucket = _buckets[index];
        if (bucket == null)
        {
            _buckets[index] = new LinkedList();
            _buckets[index].Add(addValue);
        }
        else
        {
            _buckets[index].Add(addValue);
        }

        _loaded++;

        var a = _loaded / InitialSize;
        if (a > 0.5)
        {
           ExpandArray();
        }
    }

    public void Remove(string key)
    {
        int index = CalculateHash(key) % InitialSize;
        var bucket = _buckets[index];
        if (bucket == null)
        {
            return;
        }
        bucket.RemoveByKey(key);
    } 
        
    public string Get(string key)
    {
        var result = "not found";
        var index = CalculateHash(key) % InitialSize;
        var bucket = _buckets[index];
        var currentNode = bucket.GetFirst();

        if (currentNode == null) return result;
        while (currentNode.Pair.Key != key)
        {
            currentNode = currentNode.Next;
            if (currentNode == null) return result;
        }

        if (currentNode.Pair.Key == key)
        {
            result = currentNode.Pair.Value;
        }
        return result;
    }

    private void ExpandArray()
    {
        _loaded = 0;
        var resize = InitialSize*2;
        var expandedBuckets = new LinkedList[resize];
        foreach (var bucket in _buckets)
        {
            if (bucket == null)
            {
                continue;
            }
            var current = bucket.GetFirst();
            while (current != null)
            {
                var newIndex = CalculateHash(current.Pair.Key) % resize;
                var newBucket = expandedBuckets[newIndex];
                var currentPair = current.Pair;
                if (newBucket == null)
                {
                    expandedBuckets[newIndex] = new LinkedList(); 
                    expandedBuckets[newIndex].Add(currentPair); 
                }
                else 
                { 
                    expandedBuckets[newIndex].Add(currentPair); 
                } 
                
                _loaded++;
                current = current.Next;
            } 
        }
        
        _buckets = expandedBuckets;
        InitialSize = resize;
    }
        
    private int CalculateHash(string key)
    {
        var hash = key.Aggregate(0, (current, letter) => current + letter);

        return hash % InitialSize;
    }
}