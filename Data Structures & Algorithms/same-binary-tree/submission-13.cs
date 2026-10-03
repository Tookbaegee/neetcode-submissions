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
        // BFS
        if (p == null && q == null)
        {
            return true;
        }

        if (p != null ^ q != null)
        {
            return false;
        }

        var pQueue = new Queue<TreeNode>();
        var qQueue = new Queue<TreeNode>();
        pQueue.Enqueue(p);
        qQueue.Enqueue(q);

        while (pQueue.Count() > 0 && qQueue.Count() > 0)
        {
            var pNode = pQueue.Dequeue();
            var qNode = qQueue.Dequeue();

            if (pNode != null && qNode != null && pNode.val != qNode.val)
            {
                return false;
            }

            if (pNode.left == null ^ qNode.left == null)
            {
                return false;
            }

            if (pNode.right == null ^ qNode.right == null)
            {
                return false;
            }

            if (pNode.left != null && qNode.left != null)
            {
                pQueue.Enqueue(pNode.left);
                qQueue.Enqueue(qNode.left);
            }

            if (pNode.right != null && qNode.right != null)
            {
                pQueue.Enqueue(pNode.right);
                qQueue.Enqueue(qNode.right);
            }
        }

        return true;
    }
}
