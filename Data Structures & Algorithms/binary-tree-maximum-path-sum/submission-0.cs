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

    public int MaxPathSum(TreeNode root) {
        int output = int.MinValue;
        MaxPathSum(root, ref output);
        return output;
    }

    private int MaxPathSum(TreeNode root, ref int output) {
        if (root == null) return 0;

        int left = Math.Max(0, MaxPathSum(root.left, ref output));
        int right = Math.Max(0, MaxPathSum(root.right, ref output));

        int current = root.val;

        output = Math.Max(output, current + left + right);
        return current + Math.Max(left, right);
    }
}
