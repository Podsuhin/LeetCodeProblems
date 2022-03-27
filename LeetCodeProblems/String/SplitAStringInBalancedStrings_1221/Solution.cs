namespace LeetCodeProblems.String.SplitAStringInBalancedStrings_1221
{
    public class Solution
    {
        public int BalancedStringSplit(string s)
        {
            var result = 0;

            var lStack = 0;
            var rStack = 0;

            foreach (var let in s)
            {
                if (let == 'R')
                    rStack++;
                if (let == 'L')
                    lStack++;

                if (rStack == lStack)
                {
                    lStack = 0;
                    rStack = 0;

                    result++;
                }
            }

            if (rStack > 0 || lStack > 0)
                result++;

            return result;
        }
    }
}