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
    // constraint - each node value is unique in tree
    private int preOrderIndex = 0;
    private Dictionary<int, int> inOrderIdxHash = new Dictionary<int, int>();

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        // preorder - root left right
        // inorder - left root right

        // 1 2 3 4
        // 2 1 3 4

        // // preorder q
        // var q = new Queue<TreeNode>();
        // q.Enqueue(new TreeNode(preorder[0]));

        // i for preorder
        // val - index hash
        inOrderIdxHash = new Dictionary<int, int>();
        for (var j = 0; j < inorder.Length; j++) {
            inOrderIdxHash.Add(inorder[j], j);
        }

        return this.DFS(preorder, 0, preorder.Length - 1);
    }

    private TreeNode DFS(int[] preorder, int l, int r)
    {
        if (l > r)
        {
            return null;
        }

        int rootVal = preorder[preOrderIndex];
        var root = new TreeNode(rootVal);

        int mid = inOrderIdxHash[rootVal];

        preOrderIndex++;

        root.left = this.DFS(preorder, l, mid - 1);
        root.right = this.DFS(preorder, mid + 1, r);
        return root;
    }
}
