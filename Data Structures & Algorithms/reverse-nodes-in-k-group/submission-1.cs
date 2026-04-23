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
    public ListNode ReverseKGroup(ListNode head, int k) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        return Recursion(dummy, k);
    }

    private ListNode Recursion(ListNode groupPrev, int k) {
        ListNode kth = GetKthNode(groupPrev, k);
        if (kth == null) {
            return groupPrev.next;
        }

        ListNode groupNext = Recursion(kth, k);
        ListNode prev = groupNext;
        ListNode cur = groupPrev.next;
        while (cur != groupNext) {
            ListNode next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
        }

        groupPrev.next = kth;
        return kth;
    }

    private ListNode GetKthNode(ListNode groupPrev, int k) {
        while (k > 0 && groupPrev != null) {
            groupPrev = groupPrev.next;
            k--;
        }

        return groupPrev;
    }
    
}
