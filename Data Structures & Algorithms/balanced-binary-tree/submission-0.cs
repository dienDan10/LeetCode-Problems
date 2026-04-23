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
    public bool IsBalanced(TreeNode root) {
        if (PostOrder(root) == -1) return false;
        return true;
    }

    private int PostOrder(TreeNode root) {
        if (root == null) return 0;

        int left = PostOrder(root.left);
        if (left == -1) return -1;
        int right = PostOrder(root.right);
        if (right == -1) return -1;

        int heightBalanced = Math.Abs(left - right);
        if (heightBalanced > 1) return -1;

        return Math.Max(left, right) + 1;
    }
}
