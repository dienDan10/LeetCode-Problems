/*
// Definition for a Node.
class Node {
public:
    int val;
    Node* next;
    Node* random;
    
    Node(int _val) {
        val = _val;
        next = NULL;
        random = NULL;
    }
};
*/

class Solution {
public:
    Node* copyRandomList(Node* head) {
        std::unordered_map<Node*, Node*> dic {};

        Node* temp = head;
        while (temp != nullptr) {
            dic[temp] = new Node(temp->val);
            temp = temp->next;
        }

        for(const auto& p : dic) {
            if (p.first->next != nullptr) {
                p.second->next = dic[p.first->next];
            }

            if (p.first->random != nullptr) {
                p.second->random = dic[p.first->random];
            }
        }

        return dic[head];
    }
};
