/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */

class Solution {
public:
    vector<int> rightSideView(TreeNode* root) {
        std::vector<int> result{};
        if (root == nullptr) return result;

        std::queue<TreeNode*> my_queue{};
        my_queue.push(root);
        while (!my_queue.empty()) {
            int size = my_queue.size();
            for (int i = 0; i < size; i++) {
                TreeNode* node = my_queue.front();
                my_queue.pop();
                if (node->left != nullptr) my_queue.push(node->left);
                if (node->right != nullptr) my_queue.push(node->right);

                if (i == size - 1) result.push_back(node->val);
            }
        }

        return result;
    }
};
