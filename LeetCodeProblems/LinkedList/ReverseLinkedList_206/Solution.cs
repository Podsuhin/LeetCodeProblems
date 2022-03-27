namespace LeetCodeProblems.LinkedList.ReverseLinkedList_206
{
    public class Solution
    {
        public ListNode ReverseList(ListNode head)
        {
            var current = head;
            ListNode previous = null;

            while (current != null)
            {
                var tempForNext = current.next;
                current.next = previous;

                previous = current;
                current = tempForNext;
            }

            return previous;
        }
    }
    
    public class ListNode
    {
        public ListNode next;
        public int val;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}