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

        return buildTree(preorder, 0, preorder.size() - 1, 0, preorder.size() - 1, dictionary);
    }

    TreeNode* buildTree(vector<int>& preorder, int l1, int r1, 
        int l2, int r2, std::unordered_map<int, int>& dictionary) {

            TreeNode* node = new TreeNode(preorder[l1]);
            if (l1 == r1) return node;

            int node_index = dictionary[preorder[l1]];
            int left_size = node_index - l2;
            int right_size = r2 - node_index;

            if (left_size > 0)
                node->left = buildTree(preorder, l1 + 1, l1 + left_size, 
                    l2, node_index - 1, dictionary);
            if (right_size > 0)
                node->right = buildTree(preorder, l1 + left_size + 1, r1, 
                    node_index + 1, node_index + right_size, dictionary);
            
            return node;
    }
};
