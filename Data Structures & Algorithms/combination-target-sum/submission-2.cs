public class Solution {
    private List<List<int>> res = new();
    public List<List<int>> CombinationSum(int[] nums, int target) {
        Array.Sort(nums);
        this.DFS(nums, target, 0, 0, new List<int>());
        return res;
    }

    public void DFS(int[] nums, int target, int cur, int sum, List<int> output)
    {
        if (sum == target)
        {
            res.Add(new List<int>(output));
            return;
        }

        var next = cur;
        // short circuit by checking if next exceeds the minium
        while (next < nums.Length && nums[next] <= target - sum)
        {
            output.Add(nums[next]);
            this.DFS(nums, target, next, sum + nums[next], output);
            output.RemoveAt(output.Count() - 1); // backtracking
            next++;
        }
    }
}
