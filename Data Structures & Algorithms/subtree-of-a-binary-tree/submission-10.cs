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
        if (subRoot == null)
        {
            return true;
        }

        // This is a DFS - meaning we can't just dig down to the subtree of root that has equal val as subroot's root

        return this.TraverseRoot(root, subRoot);
    }

    public bool TraverseRoot(TreeNode root, TreeNode subRoot)
    {
        if (root == null)
        {
            return false;
        }

        if (this.IsSameSubTree(root, subRoot))
        {
            return true;
        }

        return this.TraverseRoot(root.left, subRoot) || this.TraverseRoot(root.right, subRoot);
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

        if (p.val != q.val)
        {
            return false;
        }

        return this.IsSameSubTree(p.left, q.left) && this.IsSameSubTree(p.right, q.right);

    }
}
