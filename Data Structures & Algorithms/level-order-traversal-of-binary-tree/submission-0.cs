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
    public List<List<int>> LevelOrder(TreeNode root) {
        if (root == null) return new List<List<int>>();
        var result = new List<List<int>>();
        var queue = new Queue<TreeNode>();

        queue.Enqueue(root);
        while (queue.Count > 0) {
            int size = queue.Count;
            var list = new List<int>();
            for (int i = 0; i < size; i++) {
                TreeNode node = queue.Dequeue();
                list.Add(node.val);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            result.Add(list);
        }

        return result;
    }
}
