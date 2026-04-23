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
    void reorderList(ListNode* head) {
        recursive(head, head->next);
    }

    ListNode* recursive(ListNode* head, ListNode* next) {
        if (next == nullptr) return head;

        head = recursive(head, next->next);
        if (head == nullptr) return nullptr;

        if (head == next || head->next == next) {
            next->next = nullptr;
            return nullptr;
        }

        ListNode* temp = head->next;
        head->next = next;
        next->next = temp;

        return temp;
    }
};
