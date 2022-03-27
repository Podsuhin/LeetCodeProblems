using System;

namespace LeetCodeProblems.Array.MaximizeDistanceToClosestPerson_849
{
    public class Solution 
    {
        public int MaxDistToClosest(int[] seats)
        {
            var leftSeats = new int[seats.Length];

            for (var i = 0; i < leftSeats.Length; i++)
            {
                if (seats[i] == 1)
                {
                    leftSeats[i] = 0;
                    continue;
                }

                var previousIndex = i - 1;
                if (previousIndex < 0)
                {
                    leftSeats[i] = int.MaxValue;
                    continue;
                }

                if (leftSeats[previousIndex] == int.MaxValue)
                {
                    leftSeats[i] = int.MaxValue;
                    continue;
                }

                leftSeats[i] = leftSeats[previousIndex] + 1;
            }

            var result = 0;
            var previousS = int.MaxValue;
            for (int i = leftSeats.Length - 1; i >= 0; i--)
            {
                if (seats[i] == 1)
                {
                    previousS = 0;
                    continue;
                }
                
                var currentS = 0;
                if (previousS == int.MaxValue)
                {
                    result = Math.Max(Math.Min(leftSeats[i], int.MaxValue), result);
                    continue;
                }

                currentS = previousS + 1;
                result = Math.Max(Math.Min(leftSeats[i], currentS), result);
                previousS = currentS;
            }

            return result;
        }
    }
}