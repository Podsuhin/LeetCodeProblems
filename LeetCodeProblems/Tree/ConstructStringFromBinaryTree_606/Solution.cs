using System.Text;

namespace LeetCodeProblems.Tree.ConstructStringFromBinaryTree_606
{
    public class Solution
    {
        public string Tree2str(TreeNode root)
        {
            var sb = new StringBuilder();
            InternalPreorder(root, sb);
            return sb.ToString();
        }

        private void InternalPreorder(TreeNode node, StringBuilder builder)
        {
            builder.Append(node.val);

            var leftIsExist = node.left != null;
            if (leftIsExist)
            {
                builder.Append('(');
                InternalPreorder(node.left, builder);
                builder.Append(')');
            }

            if (node.right != null)
            {
                if (!leftIsExist)
                    builder.Append("()");
                builder.Append('(');
                InternalPreorder(node.right, builder);
                builder.Append(')');
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