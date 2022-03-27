using System.Collections.Generic;
using System.Linq;

namespace LeetCodeProblems.Array.KeyboardRow_500
{
    public class Solution
    {
        // private static readonly ISet<char> firstSet = new HashSet<char>
        // {
        //     'q','w','e','r','t','y','u','i','o','p','Q','W','E','R','T','Y','U','I','O','P'
        // };
        
        private static readonly char[] firstSet = new char[]
        {
            'q','w','e','r','t','y','u','i','o','p','Q','W','E','R','T','Y','U','I','O','P'
        };
        
        // private static readonly ISet<char> thirdSet = new HashSet<char>
        // {
        //     'z','x','c','v','b','n','m','Z','X','C','V','B','N','M'
        // };
        
        private static readonly char[] thirdSet = new char[]
        {
            'z','x','c','v','b','n','m','Z','X','C','V','B','N','M'
        };
        
        // private static readonly ISet<char> secondSet = new HashSet<char>
        // {
        //     'a','s','d','f','g','h','j','k','l','A','S','D','F','G','H','J','K','L'
        // };
        
        private static readonly char[] secondSet = new char[]
        {
            'a','s','d','f','g','h','j','k','l','A','S','D','F','G','H','J','K','L'
        };
        
        public string[] FindWords(string[] words)
        {
            return GetWords(words).ToArray();
        }

        private static IEnumerable<string> GetWords(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                var first = 0;
                var second = 0;
                var third = 0;

                var counter = 0;

                for (var i = 0; i < word.Length; i++)
                {
                    if (firstSet.Contains(word[i]))
                        first++;
                    else if (secondSet.Contains(word[i]))
                        second++;
                    else
                        third++;

                    counter = 0;
                    if (first > 0) counter++;
                    if (second > 0) counter++;
                    if (third > 0) counter++;

                    if (counter > 1)
                    {
                        counter = -1;
                        break;
                    }
                }

                if (counter > 0)
                {
                    yield return word;
                }
            }
        }
    }
}