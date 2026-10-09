public class Solution {
    private List<List<int>> res = new List<List<int>>();


    public List<List<int>> CombinationSum(int[] nums, int target) {

        for (var i = 0; i < nums.Length; i++)
        {
            this.NextCombination(nums, target, i, 0, new List<int>());
        }

        return res;
    }

    public void NextCombination(int[] nums, int target, int cur, int sum, List<int> output)
    {
        if (cur >= nums.Length)
        {
            return;
        }

        var curSum = sum + nums[cur];
        if (curSum > target)
        {
            return;
        }

        var curOut = new List<int>(output);
        curOut.Add(nums[cur]);

        if (curSum < target)
        {
            var next = cur;
            while (next < nums.Length)
            {
                NextCombination(nums, target, next, curSum, curOut);
                next++;
            }
        }
        
        if (curSum == target)
        {
            res.Add(curOut);
            return;
        }
    }
}
