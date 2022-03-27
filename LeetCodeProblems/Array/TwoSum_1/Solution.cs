using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeProblems.Array.TwoSum_1
{
    public class Solution
    {
        private class MyComparer : IComparer<(int index, int value)>
        {
            public int Compare((int index, int value) x, (int index, int value) y)
            {
                return x.value.CompareTo(y.value);
            }

            public static MyComparer Instance { get; set; } = new();
        }
        
        public int[] TwoSum(int[] nums, int target)
        {
            var pairs = GetPairs(nums).ToArray();
            System.Array.Sort(pairs, MyComparer.Instance);

            for (int i = 0; i < pairs.Length; i++)
            {
                var itemSearch = target - pairs[i].value;
                var result = System.Array.BinarySearch(pairs, i + 1, pairs.Length - (i + 1), (0, itemSearch), MyComparer.Instance);

                if (result >= 0)
                    return new[]
                    {
                        pairs[i].index, pairs[result].index
                    };
            }

            throw new InvalidOperationException();
        }

        private static IEnumerable<(int index, int value)> GetPairs(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                yield return (i, nums[i]);
            }
        }
    }
}