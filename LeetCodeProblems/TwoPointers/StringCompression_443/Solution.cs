namespace LeetCodeProblems.TwoPointers.StringCompression_443
{
    public class Solution
    {
        public int Compress(char[] chars)
        {
            var cCount = 1;
            var symbol = chars[1];
            var counter = 1;

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == symbol)
                {
                    counter++;
                }
                else
                {
                    cCount += counter == 1 ? 0 : counter.ToString().Length;
                    counter = 1;
                    symbol = chars[i];
                }
            }
            
            cCount += counter == 1 ? 0 : counter.ToString().Length;

            return cCount;
        }
    }
}