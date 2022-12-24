namespace LeetCodeProblems.Tree.ValidateBinarySearchTree_98
{
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

    public class Solution
    {
        public bool IsValidBST(TreeNode root)
        {
            return IsValid(root, null, null);
        }

        private bool IsValid(TreeNode root, int? rightLine, int? leftLine)
        {
            if (root.left != null)
            {
                if (root.left.val >= root.val)
                    return false;

                if (rightLine.HasValue && root.left.val >= rightLine.Value)
                    return false;

                if (leftLine.HasValue && root.left.val <= leftLine.Value)
                    return false;

                if (!IsValid(root.left, root.val, leftLine))
                    return false;
            }

            if (root.right != null)
            {
                if (root.right.val <= root.val)
                    return false;

                if (rightLine.HasValue && root.right.val >= rightLine.Value)
                    return false;

                if (leftLine.HasValue && root.right.val <= leftLine.Value)
                    return false;

                if (!IsValid(root.right, rightLine, root.val))
                    return false;
            }

            return true;
        }
    }
}