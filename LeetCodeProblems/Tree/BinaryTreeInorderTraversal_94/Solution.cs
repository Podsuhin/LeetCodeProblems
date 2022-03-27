using System.Collections.Generic;

namespace LeetCodeProblems.Tree.BinaryTreeInorderTraversal_94
{
    public class Solution
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            var path = new List<int>();
            if (root == null) return path;
            ComputedTree(root, path);
            return path;
        }

        private void ComputedTree(TreeNode root, List<int> path)
        {
            if (root.left != null)
            {
                ComputedTree(root.left, path);
            }

            path.Add(root.val);

            if (root.right != null)
            {
                ComputedTree(root.right, path);
            }
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