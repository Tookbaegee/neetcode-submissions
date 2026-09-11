public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        // problem gives it away - the distance between i & j is capped by k (inclusive)
        // we'll slide the windows to check for the duplicates
        // for each index but we should definitely be able to look ahead.
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 1; j <= k && i + j < nums.Length; j++)
            {
                if (nums[i] == nums[i + j])
                {
                    return true;
                }
            }
        }
        return false;
    }
}