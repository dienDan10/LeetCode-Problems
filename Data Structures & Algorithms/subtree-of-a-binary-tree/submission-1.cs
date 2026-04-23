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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        string rootString = SerializeTree(root);
        string subRootString = SerializeTree(subRoot);

        return rootString.Contains(subRootString);
    }

    private string SerializeTree(TreeNode root) {
        if (root == null) return "#";

        return root.val + "," + SerializeTree(root.left) + "," + SerializeTree(root.right);
    }

}
