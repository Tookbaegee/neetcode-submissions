public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        int[] tmp = new int[2];
        tmp[0] = k;
        Dfs(root, tmp);
        return tmp[1];
    }

    private void Dfs(TreeNode node, int[] tmp) {
        if (node == null) return;

        Dfs(node.left, tmp);
        if (tmp[0] == 0) return;

        tmp[0]--;
        if (tmp[0] == 0) {
            tmp[1] = node.val;
            return;
        }

        Dfs(node.right, tmp);
    }
}