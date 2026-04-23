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
    bool isSubtree(TreeNode* root, TreeNode* subRoot) {
        std::string tree = serialize_tree(root);
        std::string sub = serialize_tree(subRoot);

        if (tree.find(sub) != std::string::npos) {
            return true;
        }

        return false;
    }

    std::string serialize_tree(TreeNode* root) {
        if (root == nullptr) return "#";

        return std::to_string(root->val) + "," 
            + serialize_tree(root->left) + "," 
            + serialize_tree(root->right);
    }
};
