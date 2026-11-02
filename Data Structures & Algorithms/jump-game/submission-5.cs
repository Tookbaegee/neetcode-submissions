public class Solution {
    public bool CanJump(int[] nums) {
        // we can take a greedy approach - if sum so far is not zero we do max sum and continue
        // if sum is less we return false
        
        var cache = new Dictionary<int, bool>();

        return TopDown(nums, 0, cache);
    }

    // recurrence - if 0 return, if nums[i] > 0, try i = 1 to nums[i] and add index
    // dp[i] = for j = 1 to nums[i] agg || dp[j]
    // 1 dp is fine since variable is nums[i]
    public bool TopDown(int[] nums, int i, Dictionary<int, bool> cache)
    {
        if (i == nums.Length - 1)
        {
            return true;
        }

        if (i >= nums.Length)
        {
            return false;
        }

        if (nums[i] == 0)
        {
            return false;
        }

        if (cache.ContainsKey(i))
        {
            return cache[i];
        }

        var reached = false;
        for (var j = 1; j < Math.Min(nums[i] + 1, nums.Length); j++)
        {
            reached = reached || TopDown(nums, i + j, cache);
        }

        cache[i] = reached;
        return reached;
    }
}
