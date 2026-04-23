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
        var map = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++) {
            map.Add(inorder[i], i);
        }
        return BuildTree(preorder, 0, preorder.Length - 1, 0, inorder.Length - 1, map);
    }

    private TreeNode BuildTree(int[] preorder, int start1, int end1, int start2, int end2, Dictionary<int, int> map) {
        if (end1 < start1) return null;

        TreeNode root = new TreeNode(preorder[start1]);
        if (end1 == start1) return root;

        // find index of the root in inorder array
        int rootIdx = map[preorder[start1]];

        // construct left and right subtree
        int leftSize = rootIdx - start2;
        int rightSize = end2 - rootIdx;

        root.left = BuildTree(preorder, start1 + 1, start1 + leftSize, 
                     rootIdx - leftSize, rootIdx - 1, map);
        root.right = BuildTree(preorder, start1 + leftSize + 1, start1 + leftSize + rightSize, 
                     rootIdx + 1, rootIdx + rightSize, map);
        return root;
    }
}
