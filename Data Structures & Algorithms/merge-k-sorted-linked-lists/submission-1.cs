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
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists.Length == 0) return null;

        var heap = new PriorityQueue<ListNode, int>();
        foreach (var list in lists) {
            heap.Enqueue(list, list.val);
        }

        ListNode head = new ListNode(0);
        ListNode tail = head;
        while (heap.Count > 0) {
            tail.next = heap.Dequeue();
            tail = tail.next;
            if (tail.next != null) {
                heap.Enqueue(tail.next, tail.next.val);
            }
        }

        return head.next;
    }
}
