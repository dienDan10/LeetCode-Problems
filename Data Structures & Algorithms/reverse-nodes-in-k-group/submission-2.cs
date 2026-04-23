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
        ListNode nextGroup = head;
        int count = k;
        while (count > 0 && nextGroup != null) {
            count--;
            nextGroup = nextGroup.next;
        }

        if (count > 0) return head;

        ListNode prev = ReverseKGroup(nextGroup, k);
        while (head != nextGroup) {
            ListNode temp = head.next;
            head.next = prev;
            prev = head;
            head = temp;
        }

        return prev;
    }
}
