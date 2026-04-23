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
        // find length of the list
        int length = 0;
        ListNode temp = head;
        while (temp != null) {
            length++;
            temp = temp.next;
        }

        // find the node to remove
        int removeIndex = length - n;
        if (removeIndex == 0) return head.next;

        ListNode prev = head;
        for (int i = 1; i < removeIndex; i++) { // move prev the the node right before the remove node
            prev = prev.next;
        }

        // remove the node
        prev.next = prev.next.next;
        return head;
    }   
}
