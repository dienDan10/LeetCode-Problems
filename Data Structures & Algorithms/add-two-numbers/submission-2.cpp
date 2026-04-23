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
    ListNode* addTwoNumbers(ListNode* l1, ListNode* l2) {
        ListNode head;
        ListNode* temp = &head;
        int left = 0;
        while (l1 != nullptr || l2 != nullptr || left != 0) {
            int num1 = l1 != nullptr ? l1->val : 0;
            int num2 = l2 != nullptr ? l2->val : 0;
            int result = num1 + num2 + left;

            left = result / 10;
            result %= 10;

            temp->next = new ListNode(result);
            temp = temp->next;

            l1 = l1 != nullptr ? l1->next : nullptr;
            l2 = l2 != nullptr ? l2->next : nullptr;
        }

        return head.next;
    }
};
