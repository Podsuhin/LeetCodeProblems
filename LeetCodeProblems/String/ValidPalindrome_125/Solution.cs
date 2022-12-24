namespace LeetCodeProblems.String.ValidPalindrome_125
{
    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            var left = 0;
            var right = s.Length - 1;

            while (left < right)
            {
                if (!(char.IsLetter(s[left]) || char.IsDigit(s[left])))
                {
                    left++;
                    continue;
                }

                if (!(char.IsLetter(s[right]) || char.IsDigit(s[right])))
                {
                    right--;
                    continue;
                }
                
                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }
}