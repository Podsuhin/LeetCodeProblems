using System.Collections.Generic;
using System.Linq;

namespace LeetCodeProblems.Tree.MaximumLevelSumOfABinaryTree_1161
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
        private readonly Dictionary<int, int> mapping = new Dictionary<int, int>();

        public int MaxLevelSum(TreeNode root)
        {
            ComputedResult(root, 1);

            var max = mapping.First().Value;
            var maxLevel = mapping.First().Key;
            foreach (var kvp in mapping.Skip(1))
            {
                if (kvp.Value > max)
                {
                    max = kvp.Value;
                    maxLevel = kvp.Key;
                }
            }

            return maxLevel;
        }

        private void ComputedResult(TreeNode node, int level)
        {
            if (mapping.ContainsKey(level))
                mapping[level] += node.val;
            else
            {
                mapping.Add(level, node.val);
            }

            if (node.left != null)
                ComputedResult(node.left, level + 1);
            if (node.right != null)
                ComputedResult(node.right, level + 1);
        }
    }
}