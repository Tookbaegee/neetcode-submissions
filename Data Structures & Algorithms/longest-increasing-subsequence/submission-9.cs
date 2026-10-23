public class Solution {
    public int LengthOfLIS(int[] nums) {
        var maxCache = new int[nums.Length, nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 0; j < nums.Length; j++)
            {
                maxCache[i, j] = -1;
            }
        }

        return MaxTopDown(nums, 0, -1, maxCache);
    }

    public int MaxTopDown(int[] nums, int i, int j, int[,] cache)
    {
        if (i == nums.Length)
        {
            return 0;
        }

        if (j >= 0 && cache[i, j] > -1)
        {
            return cache[i, j];
        }

        // even if nums[i] greater than last we may decide not to take it to take a chance
        var count = MaxTopDown(nums, i + 1, j, cache); // skip

        if (j == -1 || nums[i] > nums[j])
        {
            count = Math.Max(count, 1 + MaxTopDown(nums, i + 1, i, cache));
        }

        // we can't just keep single dimension for the cache because the result cached at i might have
        // started with a different starting number - keep i and j for where it first started
        if (j >= 0)
        {
            cache[i, j] = count;
        }

        return count;
    }
}
