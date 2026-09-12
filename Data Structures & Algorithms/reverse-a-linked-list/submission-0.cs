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
    public ListNode ReverseList(ListNode head) {
        if (head == null)
        {
            return head;
        }

        var reverseTail = new ListNode(head.val);

        while (head.next != null)
        {
            head = head.next;
            var newHead = new ListNode(head.val);
            newHead.next = reverseTail;
            reverseTail = newHead;
        }

        return reverseTail;
    }
}
