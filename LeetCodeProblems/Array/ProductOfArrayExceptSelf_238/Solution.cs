using System;

namespace LeetCodeProblems.Array.ProductOfArrayExceptSelf_238
{
    public class Solution 
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var answer = new int[nums.Length];
            answer[1] = nums[0];
        
            for(var i = 2;i < nums.Length; i++)
            {
                answer[i] = answer[i - 1] * nums[i - 1];
            }

            for(var i = nums.Length - 2; i >= 0; i--)
            {
                if(i == 0)
                {
                    answer[i] = nums[i + 1];
                    break;
                }
            
                nums[i] = nums[i] * nums[i + 1];
                answer[i] = answer[i] * nums[i + 1];
            }
        
            return answer;
        }
    }
}