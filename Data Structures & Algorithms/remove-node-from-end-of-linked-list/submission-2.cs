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
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        ListNode right = head;
        while (n > 0) {
            right = right.next;
            n--;
        }

        ListNode left = dummy;
        while (right != null) {
            right = right.next;
            left = left.next;
        }

        left.next = left.next.next;
        return dummy.next;
    }   
}
