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
    public TreeNode InvertTree(TreeNode root) {
        if (root == null)
        {
            return root;
        }

        var q = new Queue<TreeNode>();

        q.Enqueue(root);
        while (q.Count > 0)
        {
            var node = q.Dequeue();

            var tmp = node.left;
            node.left = node.right;
            node.right = tmp;

            if (node.left != null)
            {
                q.Enqueue(node.left);
            }
            if (node.right != null)
            {
                q.Enqueue(node.right);
            }
        }
        return root;
    }
}
