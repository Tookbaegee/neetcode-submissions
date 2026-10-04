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
    public bool IsValidBST(TreeNode root) {
        return this.PreOrder(root, int.MinValue, int.MaxValue);
    }

    // Track bounds in recursion stack
    // if we go right, lowerbound is root
    // if we go left, upper bound is root
    // if we go right while upper
    public bool PreOrder(TreeNode root, int lowerBound, int upperBound)
    {
        if (root == null)
        {
            return true;
        }

        if (root.val <= lowerBound)
        {
            return false;
        }

        if (root.val >= upperBound)
        {
            return false;
        }

        return this.PreOrder(root.left, lowerBound, root.val) && this.PreOrder(root.right, root.val, upperBound);
    }
}
