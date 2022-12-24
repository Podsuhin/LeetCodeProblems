using System.Collections.Generic;
using System.Linq;

namespace LeetCodeProblems.Array.MergeIntervals_56
{
    public class Solution 
    {
        public int[][] Merge(int[][] intervals) 
        {
            var si = intervals.OrderBy(x => x[0]).ToList();
            var result = new List<int[]>{ si[0] };
        
            for(var i = 1;i < si.Count; i++)
            {   
                if(result[^1][1] >= si[i][0])
                {
                    if(si[i][1] > result[result.Count - 1][1])
                    {
                        result[result.Count - 1][1] = si[i][1];
                    }
                }
                else
                {
                    result.Add(si[i]);
                }
            }
        
            return result.ToArray();
        }
    }
}