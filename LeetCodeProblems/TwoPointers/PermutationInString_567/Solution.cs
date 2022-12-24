using System.Collections.Generic;

namespace LeetCodeProblems.TwoPointers.PermutationInString_567
{
    public class Solution 
    {
        public bool CheckInclusion(string s1, string s2) 
        {
            var map = new Dictionary<char, int>();
            foreach(var ch in s1)
            {
                if(map.TryGetValue(ch, out var counter))
                    map[ch] = (++counter);
                else
                    map.Add(ch, 1);
            }
        
            var left = 0;
            var commonCounter = 0;
            for(var i = 0;i < s2.Length; i++)
            {
                if(map.TryGetValue(s2[i], out var c))
                {
                    if(c == 0)
                        commonCounter--;
                
                    c--;
                    map[s2[i]] = c;
                
                    if(c == 0)
                        commonCounter++;
                }
            
                if(commonCounter == map.Count)
                    return true;
            
                if(i >= (s1.Length-1))
                {
                    if(map.TryGetValue(s2[left], out var c1))
                    {
                        if(c1 == 0)
                            commonCounter--;
                        c1++;
                        map[s2[left]] = c1;
                
                        if(c1 == 0)
                            commonCounter++;
                    }
                
                    left++;
                }
            }
        
            return false;
        }
    }
}