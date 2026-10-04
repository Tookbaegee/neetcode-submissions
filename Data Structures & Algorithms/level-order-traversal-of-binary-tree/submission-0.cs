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
    public List<List<int>> LevelOrder(TreeNode root) {
        if (root == null)
        {
            return [];
        }

        var q = new Queue<TreeNode>();
        var output = new List<List<int>>();
        q.Enqueue(root);

        while (q.Count() > 0)
        {
            var size = q.Count();
            var levelGroup = new List<int>();

            for (var i = 0; i < size; i++)
            {
                var node = q.Dequeue();
                levelGroup.Add(node.val);                

                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
            output.Add(levelGroup);
        }

        return output;
    }
}
