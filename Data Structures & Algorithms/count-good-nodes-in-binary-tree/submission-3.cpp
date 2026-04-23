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
    int goodNodes(TreeNode* root) {
        int count = 0;
        dfs(root, count, std::numeric_limits<int>::min());
        return count;
    }

    void dfs(TreeNode* root, int& count, int max) {
        if (root == nullptr) return;

        if (root->val >= max) count++;

        dfs(root->left, count, std::max(root->val, max));
        dfs(root->right, count, std::max(root->val, max));
    }
};
