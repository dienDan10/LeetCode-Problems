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
        int preIdx = 0;
        for (int i = 0; i < inorder.Length; i++) {
            map.Add(inorder[i], i);
        }
        return BuildTree(preorder, 0, preorder.Length - 1, map, ref preIdx);
    }

    private TreeNode BuildTree(int[] preorder, int l, int r, Dictionary<int, int> map, ref int preIdx) {
        if (l > r) return null;

        int rootValue = preorder[preIdx];
        preIdx++;
        int rootIdx = map[rootValue];
        TreeNode root = new TreeNode(rootValue);
        root.left = BuildTree(preorder, l, rootIdx - 1, map, ref preIdx);
        root.right = BuildTree(preorder, rootIdx + 1, r, map, ref preIdx);

        return root;
    }
}
