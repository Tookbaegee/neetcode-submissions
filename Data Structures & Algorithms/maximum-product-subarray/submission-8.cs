public class Solution {
    public int MaxProduct(int[] nums) {
        int res = nums[0];
        int maxProductBefore = nums[0];
        int minProductBefore = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            var currentMax = Math.Max(nums[i], Math.Max(maxProductBefore * nums[i], minProductBefore * nums[i]));
            minProductBefore = Math.Min(nums[i], Math.Min(maxProductBefore * nums[i], minProductBefore * nums[i]));

            maxProductBefore = currentMax;
            res = Math.Max(res, currentMax);
        }

        return res;
    }
}