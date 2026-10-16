public class Solution {
    // let's try bottom up it will be more apparent
    public int Rob(int[] nums) {
        if (nums.Length == 0)
        {
            return 0;
        }
        if (nums.Length == 1)
        {
            return nums[0];
        }

        return Math.Max(BottomUp(nums[..(nums.Length - 1)]), BottomUp(nums[1..]));

    }

    public int BottomUp(int[] nums)
    {

        var rob1 = 0;
        var rob2 = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var newRob = Math.Max(rob1 + nums[i], rob2);
            rob1 = rob2;
            rob2 = newRob;
        }

        return rob2;
    }
}
