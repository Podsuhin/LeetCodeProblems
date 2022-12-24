namespace LeetCodeProblems.Array.MoveZeroes_283
{
    public class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] == 0)
                    Shift(nums, i);
            }
        }

        private void Shift(int[] nums, int nullIndex)
        {
            for (int i = nullIndex + 1; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    nums[i - 1] = 0;
                    break;
                }

                nums[i - 1] = nums[i];
                
                if (IsLast(i, nums))
                    nums[i] = 0;
            }
        }

        private bool IsLast(int index, int[] array) => array.Length - 1 == index;
    }
}