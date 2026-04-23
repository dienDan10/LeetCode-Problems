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

    public int DiameterOfBinaryTree(TreeNode root) {
        int[] diameter = new int[1] {0};
        TraverseTree(root, diameter);
        return diameter[0];
    }

    private int TraverseTree(TreeNode root, int[] diameter) {
        if (root == null) return 0;

        int left = TraverseTree(root.left, diameter);
        int right = TraverseTree(root.right, diameter);
        diameter[0] = Math.Max(left + right, diameter[0]);
        
        return Math.Max(left, right) + 1;
    }
}
