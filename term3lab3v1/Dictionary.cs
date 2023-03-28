using System;

namespace term3lab3v1
{
    public class Dictionary
    {
        public const int InitialSize = 10;
        
        private LinkedList[] _buckets = new LinkedList[InitialSize];

        private int loaded;
        
        public void Add(string key, string value)
        {
            int hashCode = Math.Abs(key.GetHashCode());
            int index = hashCode / InitialSize;
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
            
            
        }

        public void Remove(string key)
        {
            
        } 
        
        public void Get(string key)
        {
            
        }

        private int CalculateHash(string key)
        {
            int hash = 0;
            return hash;
        }
    }
}