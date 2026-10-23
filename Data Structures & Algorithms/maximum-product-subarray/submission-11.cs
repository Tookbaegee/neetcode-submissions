public class Solution {
    // prefix and suffix
    public int MaxProduct(int[] nums) {
        var prefix = 1;
        var suffix = 1;
        var res = int.MinValue;
        for (var i = 0; i < nums.Length; i++)
        {
            if (prefix == 0)
            {
                prefix = 1;
            }

            if (suffix == 0)
            {
                suffix = 1;
            }

            prefix = prefix * nums[i]; 
            suffix = suffix * nums[nums.Length - 1 - i];

            res = Math.Max(res, Math.Max(prefix, suffix));
        }

        return res;
    }
}
