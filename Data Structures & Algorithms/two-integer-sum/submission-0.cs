public class Solution {
    // exactly one pair per nums
    public int[] TwoSum(int[] nums, int target) {
        var twoSums = new Dictionary<int, int>();
 
        for (var i = 0; i < nums.Length; i++)
        {
            if (twoSums.ContainsKey(nums[i]))
            {
                return [twoSums[nums[i]], i];
            }
            else
            {
                twoSums[target - nums[i]] = i;
            }
        }

        return [];
    }
}
