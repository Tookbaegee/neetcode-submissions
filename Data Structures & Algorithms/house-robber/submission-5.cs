public class Solution {
    public int Rob(int[] nums) {
        var cache = new int[nums.Length];

        return Math.Max(this.DFS(nums, 0, cache), this.DFS(nums, 1, cache));
    }

    public int DFS(int[] nums, int i, int[] cache)
    {
        if (i >= nums.Length)
        {
            return 0;
        }

        if (cache[i] > 0)
        {
            return cache[i];
        }

        var maxSum = Math.Max(nums[i] + this.DFS(nums, i + 2, cache), this.DFS(nums, i + 1, cache));

        cache[i] = maxSum;

        return maxSum;
    }
}
