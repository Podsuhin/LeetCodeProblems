using System;

namespace LeetCodeProblems.SlidingWindow.LongestSubarray_1493
{
    public class Solution 
    {
        public int LongestSubarray(int[] nums)
        {
            var bestResult = 0;
            
            int? delIndex = null;
            var currentResult = 0;
            
            for (int current = 0; current < nums.Length; current++)
            {
                if (nums[current] == 1)
                {
                    currentResult++;
                    bestResult = Math.Max(currentResult, bestResult);
                }
                else
                {
                    if (!delIndex.HasValue)
                    {
                        delIndex = current;
                    }
                    else
                    {
                        currentResult = (int) current - delIndex.Value - 1;
                        delIndex = current;
                    }
                }
            }

            return delIndex.HasValue ? bestResult : bestResult - 1;
        }
    }
}