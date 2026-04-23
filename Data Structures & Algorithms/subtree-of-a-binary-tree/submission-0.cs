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
        if (root == null) return false;

        bool isSame = IsSame(root, subRoot);
        if (isSame) return true;

        bool left = IsSubtree(root.left, subRoot);
        if (left) return true;

        bool right = IsSubtree(root.right, subRoot);
        if (right) return true;

        return false;
    }

    private bool IsSame(TreeNode root, TreeNode subRoot) {
        if (root == null && subRoot == null) 
            return true;

        if (subRoot == null || root == null || root.val != subRoot.val)
            return false;

        bool left = IsSame(root.left, subRoot.left);
        if (!left) return false;

        bool right = IsSame(root.right, subRoot.right);
        if (!right) return false;

        return true;
    }
}
