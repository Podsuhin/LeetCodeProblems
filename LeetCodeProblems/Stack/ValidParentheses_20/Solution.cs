using System.Collections.Generic;

namespace LeetCodeProblems.Stack.ValidParentheses_20
{
    public class Solution 
    {
        private readonly Dictionary<char, char> brackets = new Dictionary<char, char> 
        {
            [')'] = '(',
            ['}'] = '{', 
            [']'] = '[', 
        };
    
        public bool IsValid(string s) 
        {   
            var stack = new Stack<char>();
            foreach(var ch in s)
            {
                if(ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                }
                else
                {
                    if(!stack.TryPop(out var openB) 
                       || openB != brackets[ch])
                        return false;
                }
            }
        
            return stack.Count == 0;
        }
    }
}