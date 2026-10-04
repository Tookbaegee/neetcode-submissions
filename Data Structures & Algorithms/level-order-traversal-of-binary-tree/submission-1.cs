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
    private List<List<int>> output = new List<List<int>>();

    public List<List<int>> LevelOrder(TreeNode root) {
        this.DFS(root, 0);

        return output;
    }

    public void DFS (TreeNode root, int level)
    {
        if (root == null)
        {
            return;
        }

        if (output.Count() == level)
        {
            output.Add(new List<int>());
        }

        output[level].Add(root.val);
        this.DFS(root.left, level + 1);
        this.DFS(root.right, level + 1);
    }

    
}
