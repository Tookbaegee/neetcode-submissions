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
    public void ReorderList(ListNode head) {
        // how about if we reverse the list and pick one at a time from the original & reversed
        // the problem of copying a list is it's difficult to identify where the half is since we need to compare by reference
        // fast & slow pointer can help us
        if (head == null || head.next == null)
        {
            return;
        }

        var slowHead = head;
        var fastHead = head;

        while (fastHead.next?.next != null)
        {
            fastHead = fastHead.next.next;
            slowHead = slowHead.next;
        }

        var halfHead = slowHead.next;
        // essential here so we don't end up adding the next pointers at the end (at mid point)
        slowHead.next = null;

        ListNode reversedTail = new ListNode(halfHead.val);
        halfHead = halfHead.next;
        // once we know where the half should go, we can reverse the second half
        // we can copy values here since we have already identified the half.

        while (halfHead != null)
        {
            var newHead = new ListNode(halfHead.val);
            newHead.next = reversedTail;
            reversedTail = newHead;
            halfHead = halfHead.next;
        }
        // take one by one 1 , n-1,

        ListNode nextHead = head.next;
        var fromHead = false;
        while (nextHead != null || reversedTail != null)
        {
            if (fromHead)
            {
                var nextHeadTmp = head.next;
                head.next = nextHead;
                nextHead = nextHeadTmp;
                head = head.next;
                fromHead = false;
            }
            else
            {
                nextHead = head.next;
                head.next = reversedTail;
                head = head.next;
                reversedTail = reversedTail.next;
                fromHead = true;
            }
        }
    }
}
