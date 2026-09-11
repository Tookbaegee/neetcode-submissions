public class Solution {
    public int FindMin(int[] nums) {
        // what if we concatenated the copy of nums
        // can't iterate through array
        // we can land somewhere in the middle of the sorted array at nums.Length

        var l = 0;
        var r = nums.Length - 1;
        var output = int.MaxValue;
        while (l <= r) {
            var length = r - l + 1;
            var m = l + (length / 2);

            if (nums[l] > nums[r]) // when l is greater than r nums is rotated
            {
                output = Math.Min(output, nums[m]);
                if (nums[m] < nums[l]) // if m is less than left of nums, number should be between l and m (m inclusive)
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }
            else
            {
                output = Math.Min(output, nums[l]);
                break;
            }
        }

        return output;
    }
}
