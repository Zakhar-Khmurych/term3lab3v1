using System;

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
                LinkedListNode addValue = new LinkedListNode(pair);
                LinkedListNode current = _first;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = addValue;
            }
            
            
        }

        public void RemoveByKey(string key)
        {
            if (_first == null) return;
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
            if (_first == null) return null;
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
}