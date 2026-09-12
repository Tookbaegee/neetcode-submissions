/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public bool HasCycle(ListNode head) {
        if (head == null)
        {
            return false;
        }

        ListNode p1 = head.next;
        ListNode p2 = head.next?.next;

        // if there's a cycle - broken clock is right twice a day. we let two iterations going at the same time, one slower, one faster and see if we meet at the same node.h
        while (p1 != null && p2 != null)
        {
            // Equals does reference comparison - address check
            if (p1.Equals(p2))
            {
                return true;
            }
            p1 = p1.next;
            p2 = p2.next?.next;
        }

        return false;
    }
}
