using System.Collections.Generic;

namespace LeetCodeProblems.Stack.NextGreaterElementII_503
{
    public class Solution 
    {
        public int[] NextGreaterElements(int[] nums)
        {
            var stack = new Stack<(int digit, int index)>();
            var result = new int[nums.Length];
            
            for (var i = 0; i < nums.Length; i++)
            {
                while (stack.TryPeek(out var item) 
                       && nums[i] > item.digit)
                {
                    result[stack.Pop().index] = nums[i];
                }
                
                stack.Push((nums[i], i));
            }

            for (var i = 0; i < nums.Length; i++)
            {
                while (stack.TryPeek(out var item) 
                       && nums[i] > item.digit)
                {
                    result[stack.Pop().index] = nums[i];
                }
            }

            while (stack.Count > 0)
            {
                result[stack.Pop().index] = -1;
            }

            return result;
        }
    }
}