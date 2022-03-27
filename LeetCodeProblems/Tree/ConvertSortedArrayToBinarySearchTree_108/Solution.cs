namespace LeetCodeProblems.Tree.ConvertSortedArrayToBinarySearchTree_108
{
    public class Solution
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return nums.Length == 0
                ? null
                : GetTree(nums, 0, nums.Length - 1);
        }

        private static TreeNode GetTree(int[] nums, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex)
                return null;

            if (leftIndex == rightIndex)
                return new TreeNode(val: nums[leftIndex]);

            var middleIndex = (rightIndex + leftIndex) / 2;
            var node = new TreeNode(val: nums[middleIndex]);

            if (middleIndex - 1 >= 0)
                node.left = GetTree(nums, leftIndex, middleIndex - 1);

            if (middleIndex + 1 < nums.Length)
                node.right = GetTree(nums, middleIndex + 1, rightIndex);

            return node;
        }
    }
    
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int val;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}