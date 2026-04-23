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
    bool isValidBST(TreeNode* root) {
        return dfs(root, std::numeric_limits<int>::min(), std::numeric_limits<int>::max());
    }

    bool dfs(TreeNode* root, int min, int max) {
        if (root == nullptr) return true;
        if (root->val <= min || root->val >= max) return false;

        if (!dfs(root->left, min, root->val)) return false;
        if (!dfs(root->right, root->val, max)) return false;

        return true;
    }
};
