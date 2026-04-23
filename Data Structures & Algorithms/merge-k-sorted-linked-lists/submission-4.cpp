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

        for (int size = 1; size < lists.size(); size *= 2) {
            for (int left = 0; left + size < lists.size(); left += size * 2) {
                lists[left] = merge_2_list(lists[left], lists[left + size]);
            }
        }

        return lists[0];
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
