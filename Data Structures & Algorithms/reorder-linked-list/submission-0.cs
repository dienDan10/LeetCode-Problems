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
        ListNode slow = head;
        ListNode fast = head;

        while (fast.next != null && fast.next.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode right = ReverseList(slow.next);
        slow.next = null;
        ListNode start = new ListNode(0);
        ListNode tail = start;
        while (right != null && head != null) {
            tail.next = head;
            head = head.next;
            tail = tail.next;

            tail.next = right;
            right = right.next;
            tail = tail.next;
        }

        tail.next = head != null ? head : right;

        head = start.next;
    }

    public ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        ListNode cur = head;
        while (cur != null) {
            ListNode next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
        }

        return prev;
    }
}
