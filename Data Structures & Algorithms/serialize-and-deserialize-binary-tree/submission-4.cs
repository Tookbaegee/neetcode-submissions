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

public class Codec {

    private int deserzIndex = 0;
    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        return this.PreOrderSerialize(root);
    }

    public string PreOrderSerialize(TreeNode root)
    {
        if (root == null)
        {
            return "|";
        }

        return root.val.ToString() + "," + this.PreOrderSerialize(root.left) + "," + this.PreOrderSerialize(root.right);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        var delimited = data.Split(',');
        return this.PreOrderDeserialize(delimited);
    }

    public TreeNode PreOrderDeserialize(string[] data)
    {
        // need this check for when index goes out of bound - children of last elm
        if (this.deserzIndex >= data.Length)
        {
            return null;
        }

        var curChar = data[deserzIndex++];
        if (curChar == "|")
        {
            return null;
        }

        var node = new TreeNode(int.Parse(curChar));
        node.left = this.PreOrderDeserialize(data);
        node.right = this.PreOrderDeserialize(data);

        return node;
    }
}
