using System;
using System.Collections.Generic;

namespace LeetCodeProblems.HashTable.InsertDeleteGetRandom_380
{
    public class RandomizedSet
    {
        private readonly Random random = new Random();
        private readonly Dictionary<int, int> map = new Dictionary<int, int>();
        private readonly List<int> values = new List<int>();

        public bool Insert(int val)
        {
            if(map.ContainsKey(val))
            {
                return false;
            }
            
            values.Add(val);
            map.Add(val, values.Count - 1);
            return true;
        }

        public bool Remove(int val)
        {
            if(!map.TryGetValue(val, out var index))
            {
                return false;
            }
            
            values[index] = values[^1]; 
            map[values[index]] = index;
            
            values.RemoveAt(values.Count-1);
            map.Remove(val);
            
            return true;
        }

        public int GetRandom()
        {
            return values[random.Next(0, values.Count-1)];
        }
    }

    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */
}