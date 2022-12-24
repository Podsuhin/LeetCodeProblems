namespace LeetCodeProblems.Array.SubarraySumEqualsK_560
{
    public class Solution
    {
        public int SubarraySum(int[] nums, int k)
        {
            var prefixSum = new int[nums.Length + 1];
            prefixSum[0] = 0;
            var sum = 0;
            for (int i = 1; i < prefixSum.Length; i++)
            {
                sum += nums[i - 1];
                prefixSum[i] = sum;
            }

            var counter = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    if (prefixSum[j + 1] - prefixSum[i] == k)
                        counter++;
                }
            }

            return counter;
        }
    }
}