namespace LeetCodeProblems.TwoPointers.MergeSortedArray_88
{
    public class Solution 
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n) 
        {
            m--;
            n--;
        
            for(var i = nums1.Length-1;i >= 0; i--)
            {
                if(n < 0)
                    break;
                
                if(m < 0)
                {
                    nums1[i] = nums2[n];
                    n--;
                }
                else if(nums1[m] > nums2[n])
                {
                    nums1[i] = nums1[m];
                    m--;
                }
                else
                {
                    nums1[i] = nums2[n];
                    n--;
                }
            }
        }
    }
}