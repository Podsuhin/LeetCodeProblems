using System;
using System.Text;

namespace LeetCodeProblems.String.GoalParserInterpretation_1678
{
    public class Solution
    {
        public string Interpret(string command)
        {
            var strBuilder = new StringBuilder();

            var counter = 0;
            while (counter < command.Length)
            {
                switch (command[counter])
                {
                    case 'G':
                        strBuilder.Append('G');
                        counter++;
                        continue;
                    case '(' when command[counter + 1] == ')':
                        strBuilder.Append('o');
                        counter += 2;
                        continue;
                    case '(' when command[counter + 1] == 'a':
                        strBuilder.Append("al");
                        counter += 4;
                        continue;
                    default:
                        throw new InvalidOperationException(command[counter].ToString());
                }
            }

            return strBuilder.ToString();
        }
    }
}