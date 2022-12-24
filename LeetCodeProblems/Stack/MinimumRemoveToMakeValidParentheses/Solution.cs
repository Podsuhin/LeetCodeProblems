using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.Stack.MinimumRemoveToMakeValidParentheses
{
    public class Solution 
    {
        public string MinRemoveToMakeValid(string s) 
        {
            var dropIndexes = new HashSet<int>();
            var stack = new Stack<int>();

            for(var i = 0; i < s.Length; i++)
            {
                if(s[i] == '(')
                {
                    stack.Push(i);
                }

                if(s[i] == ')')
                {
                    if(stack.Count > 0)
                        stack.Pop();
                    else
                    {
                        dropIndexes.Add(i);
                    }
                }
            }

            foreach(var index in stack)
                dropIndexes.Add(index);

            if(dropIndexes.Count == 0)
                return s;

            var sb = new StringBuilder();
            for(var j = 0; j < s.Length; j++)
            {
                if(!dropIndexes.Contains(j))
                    sb.Append(s[j]);
            }

            return sb.ToString();
        }
    }
}