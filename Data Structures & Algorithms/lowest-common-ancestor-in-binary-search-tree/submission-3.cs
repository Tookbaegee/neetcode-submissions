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

/**
*   If both values are smaller than the current node -> both must lie in the left subtree.
*   If both values are greater than the current node -> both must lie in the right subtree.
*   Otherwise, the current node is the split point where one node is on the left and the other is on the right (or one is equal to the current node).
*   That split point is the Lowest Common Ancestor (LCA).
*
*/
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null || p == null || q == null)
        {
            return root;
        }

        if (Math.Max(p.val, q.val) < root.val)
        {
            return this.LowestCommonAncestor(root.left, p, q);
        }

        if (Math.Min(p.val, q.val) > root.val)
        {
            return this.LowestCommonAncestor(root.right, p, q);
        }

        return root;
    }
}
