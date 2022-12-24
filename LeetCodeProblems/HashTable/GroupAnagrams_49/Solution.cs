using System.Collections.Generic;
using System.Linq;

namespace LeetCodeProblems.HashTable.GroupAnagrams_49
{
    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var map = new Dictionary<string, IList<string>>();

            foreach (var str in strs)
            {
                var sortedString = GetSortedString(str);
                if (map.TryGetValue(sortedString, out var list))
                {
                    list.Add(str);
                }
                else
                {
                    map.Add(sortedString, new List<string>{str});
                }
            }

            return map.Values.ToList();
        }

        private string GetSortedString(string str)
        {
            return new string(str.OrderBy(x => x).ToArray());
        }
    }
}