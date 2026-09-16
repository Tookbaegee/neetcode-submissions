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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        // we need to identify nth from the end - need to reverse
        // but it's actually easier to count the length of list by two pointer and remove n - 1
        if (head == null) {
            return head;
        }

        var cur = head;

        var hl = 0;
        while (cur != null)
        {
            cur = cur.next;
            hl++;
        }

        // remove n - 1
        var m = hl - n;

        if (m == 0)
        {
            return head.next;
        }

        // m is the index of element we are removing
        cur = head;
        while (cur != null) {
            if (m == 1)
            {
                cur.next = cur.next.next;
                break;
            }

            cur = cur.next;
            m--;
        }

        return head;
    }
}
