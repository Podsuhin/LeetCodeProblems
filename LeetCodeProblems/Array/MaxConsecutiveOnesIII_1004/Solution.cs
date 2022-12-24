using System;
using System.Collections.Generic;

namespace LeetCodeProblems.Array.MaxConsecutiveOnesIII_1004
{
    public class Solution
    {
        public int LongestOnes(int[] nums, int k)
        {
            var start = 0;
            var nullIndexes = new LinkedList<int>();
            var maxSum = 0;

            var newK = k;
            
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    if (k == 0)
                    {
                        maxSum = Math.Max(i - start, maxSum);
                        start = i + 1;
                    }
                    else if(newK == 0)
                    {
                        maxSum = Math.Max(i - start, maxSum);
                        nullIndexes.AddLast(i);
                        
                        var nullIndex = nullIndexes.First.Value;
                        nullIndexes.RemoveFirst();
                        start = nullIndex + 1;
                    }
                    else
                    {
                        newK--;
                        nullIndexes.AddLast(i);
                    }
            }

            if (start == nums.Length)
                return maxSum;
            
            maxSum = Math.Max(nums.Length - start, maxSum);

            return maxSum;
        }
    }
}