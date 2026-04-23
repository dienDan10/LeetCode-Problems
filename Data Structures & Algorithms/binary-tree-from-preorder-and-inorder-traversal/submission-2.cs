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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        int preIdx = 0;
        int inoIdx = 0;
        return BuildTree(preorder, inorder, ref preIdx, ref inoIdx, int.MaxValue);
    }

    private TreeNode BuildTree(int[] preorder, int[] inorder, ref int preIdx, ref int inoIdx, int stop) {
        if (preIdx >= preorder.Length) return null;
        if (inorder[inoIdx] == stop) {
            inoIdx++;
            return null;
        }

        TreeNode root = new TreeNode(preorder[preIdx]);
        preIdx++;
        root.left = BuildTree(preorder, inorder, ref preIdx, ref inoIdx, root.val);
        root.right = BuildTree(preorder, inorder, ref preIdx, ref inoIdx, stop);
        return root;
    }
}
