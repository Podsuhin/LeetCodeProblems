using System;
using System.Collections.Generic;

namespace LeetCodeProblems.TwoPointers.LongestSubstringWithoutRepeatingCharacters_3
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var maxLine = 0;
            var start = 0;
            var countOfRepeat = 0;

            var map = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (map.TryGetValue(s[i], out var index))
                {
                    if (index >= start)
                        start = index + 1;

                    map[s[i]] = i;
                }
                else
                {
                    map.Add(s[i], i);
                }
                
                maxLine = Math.Max(maxLine, i - start + 1);
            }

            return maxLine;
        }
    }
}