using System.Collections.Generic;

namespace LeetCodeProblems.Stack.NextGreaterElementI_496
{
    public class Solution 
    {
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            var stack = new Stack<int>();
            var results = new Dictionary<int, int>();

            foreach (var digit in nums2)
            {
                while (stack.TryPeek(out var topDigit) && digit > topDigit)
                {
                    results.Add(stack.Pop(), digit);
                }
                
                stack.Push(digit);
            }

            for (var i = 0; i < nums1.Length; i++)
            {
                if (results.TryGetValue(nums1[i], out var digit))
                    nums1[i] = digit;
                else
                    nums1[i] = -1;
            }

            return nums1;
        }
    }
}