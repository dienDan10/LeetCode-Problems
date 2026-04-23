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
    int maxPathSum(TreeNode* root) {
        int result = std::numeric_limits<int>::min();
        dfs(root, result);
        return result;
    }

    int dfs(TreeNode* root, int& result) {
        if (root == nullptr) return 0;

        int left = std::max(0, dfs(root->left, result));
        int right = std::max(0, dfs(root->right, result));

        result = std::max(result, root->val + left + right);
        return root->val + std::max(left, right);
    }
};
