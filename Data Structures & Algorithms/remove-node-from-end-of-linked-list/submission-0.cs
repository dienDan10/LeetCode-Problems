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
        ListNode cur = head;
        ListNode prev = cur;
        while (removeIndex > 0) {
            if (prev != cur) {
                prev = prev.next;
            } 
            cur = cur.next;
            removeIndex--;
        }

        // remove the node
        if (prev == cur) return prev.next;
        prev.next = cur.next;
        return head;
    }   
}
