using System;
//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 my token


namespace term3lab3v1
{
    public class KeyValuePair
    {
        public string Key { get; }
        
        public string Value { get; }

        public KeyValuePair(string key, string value)
        {
            Key = key;
            Value = value;
        }
        
    }

    public class LinkedListNode
    {
        public KeyValuePair Pair { get; }
        public LinkedListNode Next { get; set; }

        public LinkedListNode(KeyValuePair pair, LinkedListNode next = null)
        {
            Pair = pair;
            Next = next;
        }
        
    }

    public class LinkedList
    {
        private LinkedListNode _first;

        public void Add(KeyValuePair pair)
        {
            if (_first == null)
            {
                _first = new LinkedListNode(pair);
                _first.Next = null;
            }
            else
            {
                LinkedListNode add_value = new LinkedListNode(pair);
                LinkedListNode current = _first;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = add_value;
            }
            
            
        }

        public void RemoveByKey(string key)
        {
           // if (_first == null) return;
            if (_first.Pair.Key == key)
            {
                _first = _first.Next;
                return;
            }

            var current = _first;
            while (current.Next != null)
            {
                if (current.Next.Pair.Key == key)
                {
                    current.Next = current.Next.Next;
                    return;
                }

                current = current.Next;

            }


        }

        public KeyValuePair GetItemWithKey(string key)
        {
         //   if (_first == null) return null;
            if (_first.Pair.Key == key)
            {
                return _first.Pair;
            }
            var current = _first;
            while (current.Next != null)
            {
                if (current.Next.Pair.Key == key)
                {
                    return current.Pair;
                }
            }
            

            return null;
        }

        public LinkedListNode GetFirst()
        {
            return _first;
        }

        public void PrintAll()
        {
            LinkedListNode current = _first;
            while (current != null)
            {
                Console.Write("key: " + current.Pair.Key + ", value " + current.Pair.Value + "\n");
                current = current.Next;
            }
  
        }

        public bool IsEmpty()
        {
            if (_first == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
        
    }

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
            int hash_code = Math.Abs(key.GetHashCode());
            int index = hash_code / InitialSize;
            var _first = _buckets[index];
            _first.RemoveByKey(key);
        } 
        
        public string Get(string key)
        {
            int hash_code = Math.Abs(key.GetHashCode());
            int index = hash_code / InitialSize;
            var _first = _buckets[index];
            string result = null;
            if (_first == null)
            {
                Console.WriteLine("no way");
            }

            if (_first.GetFirst() != null)
            {
                var current = _first.GetFirst();
                while (current.Pair.Key != key)
                {
                    current = current.Next;
                    if (current == null)
                    {
                        break;    
                    }
                }

                if (current.Pair.Key == key)
                {
                    result = current.Pair.Value;
                }

            }

            return result;
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