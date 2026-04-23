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
    ListNode* mergeKLists(vector<ListNode*>& lists) {
        if (lists.size() == 0) return nullptr;

        return divide(lists, 0, lists.size() - 1);
    }

    ListNode* divide(vector<ListNode*>& lists, int l, int r) {
        if (l == r) return lists[l];

        int m = l + (r - l) / 2;
        ListNode* l1 = divide(lists, l, m);
        ListNode* l2 = divide(lists, m + 1, r);

        return merge_2_list(l1, l2);
    }

    ListNode* merge_2_list(ListNode* l1, ListNode* l2) {
        ListNode dummy{};
        ListNode* next = &dummy;
        while (l1 != nullptr && l2 != nullptr) {
            if (l1->val < l2->val) {
                next->next = l1;
                l1 = l1->next;
            } else {
                next->next = l2;
                l2 = l2->next;
            }

            next = next->next;
        }

        next->next = l1 != nullptr ? l1 : l2;
        return dummy.next;
    }
};
