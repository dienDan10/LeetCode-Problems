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

class Codec {
public:

    // Encodes a tree to a single string.
    string serialize(TreeNode* root) {
        std::string result{};
        serialize(root, result);
        result.pop_back();
        return result;
    }

    void serialize(TreeNode* root, std::string& result) {
        if (root == nullptr) {
            result.append("#,");
            return;
        }

        result.append(std::to_string(root->val));
        result.append(",");

        serialize(root->left, result);
        serialize(root->right, result);
    }

    // Decodes your encoded data to tree.
    TreeNode* deserialize(string data) {
        if (data == "") return nullptr;
        int start = 0;
        return deserialize(data, start);
    }

    TreeNode* deserialize(std::string& data, int& start) {
        int end = data.find(',', start);
        if (end == std::string::npos) {
            end = data.size();
        }

        std::string substr = data.substr(start, end - start);
        start = end + 1;
        if (substr == "#") {
            return nullptr;
        }

        int value = std::stoi(substr);
        TreeNode* root = new TreeNode(value);
        root->left = deserialize(data, start);
        root->right = deserialize(data, start);

        return root;
    }
};
