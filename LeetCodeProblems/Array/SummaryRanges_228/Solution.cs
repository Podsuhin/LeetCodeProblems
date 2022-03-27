using System.Collections.Generic;
using System.Linq;

namespace LeetCodeProblems.Array.SummaryRanges_228
{
    public class Solution 
    {
        public IList<string> SummaryRanges(int[] nums)
        {
            if (nums.Length == 0)
                return new List<string>();

            var result = new List<string>();
            
            var startValue = nums[0];
            var previous = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - 1 != previous)
                {
                    Write(result, startValue, previous);
                    startValue = nums[i];
                }

                previous = nums[i];
            }
            
            Write(result, startValue, nums.Last());

            return result;
        }

        private void Write(IList<string> result, int start, int finish)
        {
            result.Add(start == finish ? start.ToString() : $"{start}->{finish}");
        }
    }
}