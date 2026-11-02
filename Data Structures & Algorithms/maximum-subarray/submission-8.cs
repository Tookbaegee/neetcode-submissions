public class Solution {
    public int MaxSubArray(int[] nums) {
        var maxSum = nums[0];
        var prevSum = 0;

        // we can try using fuck what was the guy's name called
        // the algo for computing subsequence/subararay
        // we use 1 dp with previous stored

        foreach (var num in nums) {
            var sum = Math.Max(prevSum + num, num);
            maxSum = Math.Max(maxSum, sum);
            prevSum = sum;
        }

        return maxSum;
    }
}
