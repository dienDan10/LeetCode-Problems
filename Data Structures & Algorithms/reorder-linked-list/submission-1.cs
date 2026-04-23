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
        // find middle of the linked list
        ListNode slow = head;
        ListNode fast = head;
        while (fast.next != null && fast.next.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        // reverse the second half
        ListNode right = ReverseList(slow.next);
        slow.next = null;

        // merge two part
        ListNode left = head;
        while (right != null) {
            ListNode nextLeft = left.next;
            ListNode nextRight = right.next;

            left.next = right;
            right.next = nextLeft;
            
            left = nextLeft;
            right = nextRight;
        }
    }

    public ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        while (head != null) {
            ListNode next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }

        return prev;
    }
}
