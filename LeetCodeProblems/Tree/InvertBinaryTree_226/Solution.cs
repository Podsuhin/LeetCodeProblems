namespace LeetCodeProblems.Tree.InvertBinaryTree_226
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
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            if (root.left != null)
                root.left = InvertTree(root.left);
            if (root.right != null)
                root.right = InvertTree(root.right);

            var temp = root.left;
            root.left = root.right;
            root.right = temp;

            return root;
        }
    }
}