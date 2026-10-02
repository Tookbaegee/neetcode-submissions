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
    // try dfs with recursion
    public int MaxDepth(TreeNode root) {
        return this.DFS(root);
    }

    public int DFS (TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        return 1 + Math.Max(this.DFS(node.left), this.DFS(node.right));
    }
}
