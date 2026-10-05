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
    private int maxSum = int.MinValue;

    public int MaxPathSum(TreeNode root) {
        this.DFSSum(root);
        return maxSum;
    }

    public int DFSSum(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        
        var leftSum = Math.Max(0, this.DFSSum(root.left));
        var rightSum = Math.Max(0, this.DFSSum(root.right));

        // only chilren - we either take only left, only right
        var childMax = Math.Max(leftSum, rightSum);

        // including root - for us to take both children, we need to take parent
        var curMax = Math.Max(root.val + childMax, root.val + leftSum + rightSum);

        // or just consider root without any children - we already floored child with Max 0 so no need
        this.maxSum = Math.Max(this.maxSum, curMax);
        return root.val + childMax;
    }
}
