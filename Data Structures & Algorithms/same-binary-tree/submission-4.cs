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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        return this.IsSameSubTree(p, q);
    }

    public bool IsSameSubTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
        {
            return true;
        }

        if (p == null ^ q == null)
        {
            return false;
        }

        if (p != null && q != null && p.val != q.val)
        {
            return false;
        }

        return this.IsSameSubTree(p.left, q.left) && this.IsSameSubTree(p.right, q.right);
    }
}
