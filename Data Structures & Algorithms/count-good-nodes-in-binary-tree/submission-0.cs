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
    private int goodNodes = 0;

    public int GoodNodes(TreeNode root) {
        Traversal(root, int.MinValue);
        return goodNodes;    
    }

    public void Traversal(TreeNode node, int max) {
        if (node == null) return;

        if (node.val >= max) {
            goodNodes++;
            max = node.val;
        }

        Traversal(node.left, max);
        Traversal(node.right, max);
    }
}
