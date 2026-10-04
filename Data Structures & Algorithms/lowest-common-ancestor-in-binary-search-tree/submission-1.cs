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

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null)
        {
            return root;
        }

        Stack<TreeNode> pStack = new Stack<TreeNode>();
        Stack<TreeNode> qStack = new Stack<TreeNode>();

        this.PreOrder(root, p.val, pStack);
        this.PreOrder(root, q.val, qStack);

        while (pStack.Peek() != qStack.Peek() && pStack.Count > 0 && qStack.Count > 0)
        {
            if (pStack.Count() > qStack.Count())
            {
                pStack.Pop();
            }
            else if (pStack.Count() < qStack.Count())
            {
                qStack.Pop();
            }
            else
            {
                pStack.Pop();
                qStack.Pop();
            }
        }

        return pStack.Peek();
    }

    public bool PreOrder(TreeNode root, int val, Stack<TreeNode> stack)
    {
        stack.Push(root);

        if (val < root.val)
        {
            return this.PreOrder(root.left, val, stack);
        }

        if (val > root.val)
        {
            return this.PreOrder(root.right, val, stack);
        }

        return true;
    }
}
