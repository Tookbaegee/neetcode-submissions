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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {

        ListNode newList;
        ListNode curList;

        if (list1 == null)
        {
            return list2;
        }
        if (list2 == null)
        {
            return list1;
        }

        if (list1.val < list2.val)
        {
            newList = new ListNode(list1.val);
            list1 = list1.next;
        }
        else
        {
            newList = new ListNode(list2.val);
            list2 = list2.next;
        }

        curList = newList;
        do
        {
            if (list1 == null && list2 != null)
            {
                curList.next = list2;
                break;
            }
            else if (list1 != null && list2 == null)
            {
                curList.next = list1;
                break;
            }
            else
            {
                if (list1.val < list2.val)
                {
                    curList.next = new ListNode(list1.val);
                    list1 = list1.next;
                }
                else
                {
                    curList.next = new ListNode(list2.val);
                    list2 = list2.next;
                }
            }
            curList = curList.next;
        }
        while (list1 != null || list2 != null);

        return newList;
    }
}