public class Solution {
    // Bottom Up
    public int UniquePaths(int m, int n) {
        if (m == 0 || n == 0)
        {
            return 0;
        }

        var dp = new int[m + 1, n + 1];
        dp[m, n - 1] = 1;
        for (var y = m - 1; y >= 0; y--)
        {
            for (var x = n - 1; x >= 0; x--)
            {
                dp[y, x] = dp[y + 1, x] + dp[y, x + 1];
            }
        }

        return dp[0, 0];
    }
}
