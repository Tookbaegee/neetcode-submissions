public class Solution {
    // Bottom Up
    public int LongestCommonSubsequence(string text1, string text2) {
        if (text1.Length == 0 || text2.Length == 0)
        {
            return 0;
        }

        var dp = new int[text1.Length + 1, text2.Length + 1];

        for (var i = text1.Length - 1; i >= 0; i--)
        {
            for (var j = text2.Length - 1; j >=0; j--)
            {
                if (text1[i] == text2[j])
                {
                    dp[i, j] = 1 + dp[i + 1, j + 1];
                    continue;
                }
                
                dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j + 1]);
            }
        }

        return dp[0, 0];
    }
}
