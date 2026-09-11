public class Solution {
    public bool hasDuplicate(int[] nums) {
        var dupNums = new Dictionary<int, bool>();

        for (var i = 0; i < nums.Count(); i++)
        {
            if (!dupNums.ContainsKey(nums[i]))
            {
                dupNums[nums[i]] = true;
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}