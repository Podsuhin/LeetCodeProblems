using System.Collections.Generic;

namespace LeetCodeProblems.Stack
{
    public class Node
    {
        public IList<Node> children;
        public int val;

        public Node()
        {
        }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    public class Solution
    {
        public IList<int> Postorder(Node root)
        {
            var result = new List<int>();
            if (root == null) return result;

            var current = root;
            var currentChild = -1;

            var previousPath = new Stack<State>();

            while (true)
            {
                //comp

                if (current.children != null
                    && current.children.Count > currentChild + 1)
                {
                    currentChild++;
                    previousPath.Push(new State
                    {
                        Node = current,
                        ChildCounter = currentChild
                    });

                    current = current.children[currentChild];
                    currentChild = -1;

                    continue;
                }

                result.Add(current.val);

                if (previousPath.Count == 0)
                    break;

                var state = previousPath.Pop();
                current = state.Node;
                currentChild = state.ChildCounter;
            }

            return result;
        }

        private struct State
        {
            public Node Node;
            public int ChildCounter;
        }
    }
}