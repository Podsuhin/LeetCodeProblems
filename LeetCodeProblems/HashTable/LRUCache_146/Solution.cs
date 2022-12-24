using System.Collections.Generic;

namespace LeetCodeProblems.HashTable.LRUCache_146
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; }
        
        public Node Next { get; set; }
        
        public Node Previous { get; set; }
    }

    
    // <-1-> <-5-> <-6-> <-7-> null 
    public class Rating
    {
        private Node first;
        private Node last;

        public void AddFirst(Node node)
        {
            if (IsEmpty())
            {
                first = node;
                last = node;
                return;
            }

            node.Next = first;
            first.Previous = node;
            first = node;
        }

        public void ToFirst(Node node)
        {
            if (first?.Equals(node) == true)
                return;

            if (last.Equals(node))
            {
                var newLast = last.Previous;
                newLast.Next = null;
                last = newLast;

                node.Previous = null;
                node.Next = first;
                first.Previous = node;

                first = node;
                
                return;
            }

            var right = node.Next;
            var left = node.Previous;

            right.Previous = left;
            left.Next = right;

            node.Previous = null;
            node.Next = first;
            first.Previous = node;

            first = node;
        }

        public int RemoveLast()
        {
            var value = last.Value;
            
            if (IsOneElement())
            {
                first = null;
                last = null;

                return value;
            }

            var newLast = last.Previous;
            newLast.Next = null;
            last = newLast;

            return value;
        }

        private bool IsEmpty() => first == null && last == null;

        private bool IsOneElement() => first != null && first.Equals(last);
    }
    
    public class LRUCache
    {
        private readonly Dictionary<int, (int, Node)> map = new ();
        private readonly int capacity;

        private readonly Rating rating = new Rating();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            if (!map.TryGetValue(key, out var res))
                return -1;
            
            rating.ToFirst(res.Item2);

            return res.Item1;
        }

        public void Put(int key, int value)
        {
            if (map.TryGetValue(key, out var v))
            {
                rating.ToFirst(v.Item2);
                map[key] = (value, v.Item2);
                return;
            }

            if (map.Count == capacity)
            {
                map.Remove(rating.RemoveLast());
            }
            
            var node = new Node(key);
            rating.AddFirst(node);
            map[key] = (value, node);
        }
    }
}