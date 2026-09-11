public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        // how can we achieve O(n)

        // look up?

        var dups = new Dictionary<int, bool>();
        for (var i = 0; i < nums.Length ; i++)
        {
            if (dups.ContainsKey(nums[i])){
                return true;
            }

            dups.Add(nums[i], true);

            if (i >= k)
            {
                dups.Remove(nums[i - k]);
            }
        }

        return false;
    }
}