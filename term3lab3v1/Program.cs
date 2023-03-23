﻿using System;

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
        
    }

    public class StringsDictionary
    {
        public const int InitialSize = 10;

        private LinkedList[] _buckets = new LinkedList[InitialSize];

        public void Add(string key, string value)
        {
            
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