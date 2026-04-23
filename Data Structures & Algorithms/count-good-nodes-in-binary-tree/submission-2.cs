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
    public int GoodNodes(TreeNode root) {
       return GoodNodes(root, root.val);
    }

    private int GoodNodes(TreeNode root, int max) {
        if (root == null) return 0;

        int left = GoodNodes(root.left, Math.Max(max, root.val));
        int right = GoodNodes(root.right, Math.Max(max, root.val));

        if (max > root.val) return left + right;
        return left + right + 1;
    }
}
