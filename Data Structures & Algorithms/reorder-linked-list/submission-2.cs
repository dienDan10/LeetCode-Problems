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
        ReorderList(head, head.next);
    }

    private ListNode ReorderList(ListNode head, ListNode next) {
        if (next == null) return head;

        ListNode currentHead = ReorderList(head, next.next);
        if (currentHead == null) return null;

        if (currentHead == next || currentHead.next == next) {
            next.next = null;
            return null;
        }

        ListNode temp = currentHead.next;
        currentHead.next = next;
        next.next = temp;
        return temp;
    }
}
