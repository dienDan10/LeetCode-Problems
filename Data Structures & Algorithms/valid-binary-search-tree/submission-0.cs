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

public class Solution {
    public bool IsValidBST(TreeNode root) {
        return Traversal(root, int.MinValue, int.MaxValue);
    }

    private bool Traversal(TreeNode node, int min, int max) {
        if (node == null) return true;

        if (node.val <= min || node.val >= max) 
            return false;

        bool left = Traversal(node.left, min, Math.Min(max, node.val));
        if (!left) return false;
        bool right = Traversal(node.right, Math.Max(node.val, min), max);
        if (!right) return false;

        return true;
    }
}
