using System;
//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 my token


namespace term3lab3v1
{

    public class StringsDictionary
    {
        public const int InitialSize = 10;
        
        private LinkedList[] _buckets = new LinkedList[InitialSize];

        private int loaded;
        
        public void Add(string key, string value)
        {
            int hashCode = Math.Abs(key.GetHashCode());
            int index = hashCode / InitialSize;
            var add_value = new KeyValuePair(key, value);
            var _first = _buckets[index];
            if (_first == null)
            {
                _buckets[index] = new LinkedList();
                _buckets[index].Add(add_value);
                loaded++;
            }
            else
            {
                _buckets[index].Add(add_value);
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
    
    
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}