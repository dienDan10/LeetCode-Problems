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
        return Traversal(root, int.MinValue);
    }

    public int Traversal(TreeNode node, int max) {
        if (node == null) return 0;
        int count = 0;

        if (node.val >= max) {
            count++;
            max = node.val;
        }

        int leftCount = Traversal(node.left, max);
        int rightCount = Traversal(node.right, max);
        return count + leftCount + rightCount;
    }
}
