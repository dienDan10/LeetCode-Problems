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
        return MergeKListsRecursion(lists, 0, lists.Length);
    }

    private ListNode MergeKListsRecursion(ListNode[] lists, int start, int end) {
        if (end - start == 1) return lists[start];

        int middle = start + (end - start) / 2;
        ListNode l1 = MergeKListsRecursion(lists, start, middle);
        ListNode l2 = MergeKListsRecursion(lists, middle, end);
        
        return Merge2List(l1, l2);
    }

    private ListNode Merge2List(ListNode l1, ListNode l2) {
        ListNode head = new ListNode(0);
        ListNode tail = head;
        while (l1 != null && l2 != null) {
            if (l1.val < l2.val) {
                tail.next = l1;
                l1 = l1.next;
            } else {
                tail.next = l2;
                l2 = l2.next;
            }

            tail = tail.next;
        }

        tail.next = l1 != null ? l1 : l2;
        return head.next;
    }
}
