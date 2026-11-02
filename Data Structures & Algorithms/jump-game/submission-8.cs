public class Solution {
    // greedy we can use the fact that
    // if i can reach the left most good index (i is less than or equal to i + nums[j])
    public bool CanJump(int[] nums) {
        var newBoundary = nums.Length - 1;
        for (var i = newBoundary - 1; i >= 0; i--)
        {
            if (i + nums[i] >= newBoundary)
            {
                newBoundary = i;
            }
        }

        return newBoundary == 0;
    }
}
