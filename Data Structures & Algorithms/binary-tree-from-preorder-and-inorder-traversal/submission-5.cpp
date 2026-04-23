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
    TreeNode* buildTree(vector<int>& preorder, vector<int>& inorder) {
        std::unordered_map<int, int> dictionary {};
        for (int i = 0; i < inorder.size(); i++) {
            dictionary[inorder[i]] = i;
        }
        int preIdx = 0;
        return buildTree(preorder, 0, preorder.size() - 1, preIdx, dictionary);
    }

    TreeNode* buildTree(vector<int>& preorder, int l, int r, int& preIdx,
         std::unordered_map<int, int>& dictionary) {
            if (l > r) return nullptr;

            TreeNode* node = new TreeNode(preorder[preIdx]);
            int node_index = dictionary[preorder[preIdx]];
            preIdx++;

            node->left = buildTree(preorder, l, node_index - 1, preIdx, dictionary);
            node->right = buildTree(preorder, node_index + 1, r, preIdx, dictionary);

            return node;
    }
};
