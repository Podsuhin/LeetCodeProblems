namespace LeetCodeProblems.TwoPointers.StringCompression_443
{
    public class Solution
    {
        public int Compress(char[] chars)
        {
            var insertIndex = 0;
            char currentSymbol = chars[0];
            var counter = 1;
            var length = 0;

            for (int i = 1; i < chars.Length; i++)
            {
                if (chars[i] == currentSymbol)
                {
                    counter++;
                }
                else
                {
                    string stringForInsert = null;
                    if (counter > 1)
                        stringForInsert = $"{currentSymbol}{counter}";
                    else stringForInsert = currentSymbol.ToString();

                        for (int j = 0; j < stringForInsert.Length; j++)
                        chars[insertIndex + j] = stringForInsert[j];

                    length += stringForInsert.Length;
                    insertIndex = stringForInsert.Length + insertIndex;
                    counter = 1;
                    currentSymbol = chars[i];
                }
            }
            
            var str = currentSymbol + (counter > 1 ? counter.ToString() : string.Empty);
            for (int j = 0; j < str.Length; j++)
                chars[insertIndex + j] = str[j];

            length += str.Length;

            return length;
        }
    }
}