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
    // serializing against large array can explode memory
    // let's try keeping k in recursion stack and match
    private int order = 0;
    private int k;
    private int output = 0;

    public int KthSmallest(TreeNode root, int k) {
        this.k = k;
        this.MatchInOrder(root);
        return output;
    }

    // In Order goes left root right - in BST, iteration will go in sorted manner.
    public void MatchInOrder(TreeNode root)
    {
        if (root == null || order >= k)
        {
            return;
        }

        this.MatchInOrder(root.left);

        order++;
        if (k == order)
        {
            output = root.val;
        }

        this.MatchInOrder(root.right);
    }
}
