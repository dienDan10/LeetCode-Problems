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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null) return list2;
        if (list2 == null) return list1;
        
        ListNode cur1 = list1;
        ListNode cur2 = list2;
        ListNode head = null, tail = null;
        while (cur1 != null && cur2 != null) {
            if (cur1.val < cur2.val) {
                if (head == null) {
                    head = cur1;
                    tail = cur1;
                } else {
                    tail.next = cur1;
                    tail = tail.next;
                }

                cur1 = cur1.next;
            } else {
                if (head == null) {
                    head = cur2;
                    tail = cur2;
                } else {
                    tail.next = cur2;
                    tail = tail.next;
                }
                cur2 = cur2.next;
            }
        }

        if (cur1 != null) {
            tail.next = cur1;
        } 

        if (cur2 != null) {
            tail.next = cur2;
        }

        return head;
    }
}