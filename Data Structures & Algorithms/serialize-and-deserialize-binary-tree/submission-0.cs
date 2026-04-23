/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Codec {

    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        if (root == null) return "";
        StringBuilder builder = new StringBuilder();
        Preorder(root, builder);
        return builder.Remove(0, 1).ToString();
    }

    private void Preorder(TreeNode root, StringBuilder builder) {
        if (root == null) {
            builder.Append(",#");
            return;
        }

        builder.Append("," + root.val);
        Preorder(root.left, builder);
        Preorder(root.right, builder);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        if (data == "") return null;
        int start = 0;
        return Deserialize(data, ref start);
    }

    private TreeNode Deserialize(string data, ref int start) {
        if (start > data.Length) return null;
        int end = data.IndexOf(',', start);
        if (end == -1) {
            end = data.Length;
        }

        string s = data.Substring(start, end - start);
        start = end + 1;
        if (int.TryParse(s, out int value)) {
            TreeNode root = new TreeNode(value);
            root.left = Deserialize(data, ref start);
            root.right = Deserialize(data, ref start);
            return root;
        } 

        return null;
    }
}
