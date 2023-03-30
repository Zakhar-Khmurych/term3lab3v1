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
        private LinkedListNode pointedNode;

        public void Add(KeyValuePair pair)
        {
            if (pointedNode == null)
            {
                pointedNode = new LinkedListNode(pair);
                pointedNode.Next = null;
            }
            else
            {
                var addValue = new LinkedListNode(pair);
                var current = pointedNode;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = addValue;
            }
        }

        public void RemoveByKey(string key)
        {
            if (pointedNode == null) return;
            if (pointedNode.Pair.Key == key)
            {
                pointedNode = pointedNode.Next;
                return;
            }

            var current = pointedNode;
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
            if (pointedNode == null) return null;
            if (pointedNode.Pair.Key == key)
            {
                return pointedNode.Pair;
            }
            var current = pointedNode;
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
            return pointedNode;
        }

        public void PrintAll()
        {
            LinkedListNode current = pointedNode;
            while (current != null)
            {
                Console.Write("key: " + current.Pair.Key + ", value " + current.Pair.Value + "\n");
                current = current.Next;
            }
  
        }

        public bool IsEmpty()
        {
            if (pointedNode == null)
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