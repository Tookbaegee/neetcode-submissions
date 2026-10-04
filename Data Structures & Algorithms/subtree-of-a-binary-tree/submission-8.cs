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
        var q = new Queue<TreeNode>();
        if (subRoot == null)
        {
            return true;
        }

        if (root == null)
        {
            return false;
        }
        q.Enqueue(root);

        while (q.Count() > 0)
        {
            var node = q.Dequeue();

            if (this.IsSameTree(node, subRoot))
            {
                return true;
            }

            if (node.left != null)
            {
                q.Enqueue(node.left);
            }
            if (node.right != null)
            {
                q.Enqueue(node.right);
            }
        }

        return false;
    }

    public bool IsSameTree(TreeNode p, TreeNode q)
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

        return this.IsSameTree(p.left, q.left) && this.IsSameTree(p.right, q.right);
    }
}
