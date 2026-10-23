public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if (amount == 0) {
            return 0;
        }
        var dp = new int[amount + 1];

        for (var i = 0; i < dp.Length; i++) {
            dp[i] = amount + 1;
        }

        dp[amount] = 0;
        long remainder = amount;
        while (remainder >= 0) {
            if (dp[remainder] > amount)
            {
                remainder--;
                continue;
            }

            foreach (var coin in coins) {
                
                if (remainder - coin >= 0) {
                    dp[remainder - coin] = Math.Min(dp[remainder] + 1, dp[remainder - coin]);
                } 
            }

            remainder--;
        }

        return dp[0] > amount ? -1 : dp[0];
    }
}
