
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        // dynamic programming solution with pre-processed left Max & right Max to inspect the max
        // bound at i to
        // right & left so given l & r window boundaries we can see what max value is
        var leftMax = new Dictionary<int, int>();
        var rightMax = new Dictionary<int, int>();

        rightMax[nums.Length - 1] = nums[nums.Length - 1];
        for (var i = nums.Length - 2; i >= 0; i--) {
            if (i % k == 0) {
                rightMax[i] = nums[i];
            } else {
                rightMax[i] = Math.Max(rightMax[i + 1], nums[i]);
            }
        }

        leftMax[0] = nums[0];
        for (var i = 1; i < nums.Length; i++) {
            if (i % k == 0) {
                leftMax[i] = nums[i];
            } else {
                leftMax[i] = Math.Max(leftMax[i - 1], nums[i]);
            }
        }

        var output = new int[nums.Length - k + 1];
        for (var i = 0; i < nums.Length - k + 1; i++) {
            output[i] = Math.Max(leftMax[i + k - 1], rightMax[i]);
        }

        return output;
    }
}
