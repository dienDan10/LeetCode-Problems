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
    int kthSmallest(TreeNode* root, int k) {
        return dfs(root, k);
    }

    int dfs(TreeNode* root, int& k) {
        if (root == nullptr) return -1;

        int left = dfs(root->left, k);
        if (left != -1) return left;

        k--;
        if (k == 0) return root->val;

        return dfs(root->right, k);  
    }
};
