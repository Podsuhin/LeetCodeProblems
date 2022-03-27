using System.Collections.Generic;

namespace LeetCodeProblems.Array.SelfDividingNumbers_728
{
    public class Solution
    {
        public IList<int> SelfDividingNumbers(int left, int right)
        {
            var result = new List<int>();
            for (int i = left; i <= right; i++)
            {
                var counter = 0;
                var iString = i.ToString();

                for (int j = 0; j < iString.Length; j++)
                {
                    var number = int.Parse(iString[j].ToString());
                    if (number == 0)
                        continue;

                    if (i % number == 0)
                        counter++;
                }

                if (counter == iString.Length)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}