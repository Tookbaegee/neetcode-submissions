public class Solution {
    public int Rob(int[] nums) {
        var cache = new int[nums.Length];
        var cache2 = new int[nums.Length];
        if (nums.Length == 0)
        {
            return 0;
        }

        if (nums.Length == 1)
        {
            return nums[0];
        }

        return Math.Max(this.DFS(nums[..(nums.Length - 1)], 0, cache), this.DFS(nums[1..nums.Length], 0, cache2));
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
