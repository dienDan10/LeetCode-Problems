/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode() : val(0), next(nullptr) {}
 *     ListNode(int x) : val(x), next(nullptr) {}
 *     ListNode(int x, ListNode *next) : val(x), next(next) {}
 * };
 */

class Solution {
public:
    ListNode* reverseKGroup(ListNode* head, int k) {
        // find the first node of the next group
        ListNode* next_group = head;
        int count = k;
        while (count > 0 && next_group != nullptr) {
            next_group = next_group->next;
            count--;
        }
        // return the head without reverse if the size is not enough
        if (count > 0) return head;

        // reverse this group
        ListNode* cur = head;
        ListNode* prev = nullptr;
        while (head != next_group) {
            ListNode* temp = head->next;
            head->next = prev;
            prev = head;
            head = temp;
        }
        // at this point cur is the end node of the reversed part
        cur->next = reverseKGroup(next_group, k);
        return prev;
    }
};
