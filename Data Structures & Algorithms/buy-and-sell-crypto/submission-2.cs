public class Solution {
    public int MaxProfit(int[] prices) {

        var minBuyBeforeI = new Dictionary<int, int>();
        minBuyBeforeI[0] = prices[0];

        var maxProfit = 0;
        for (var i = 1; i < prices.Length; i++)
        {
            minBuyBeforeI[i] = Math.Min(prices[i], minBuyBeforeI[i - 1]);

            maxProfit = Math.Max(maxProfit, prices[i] - minBuyBeforeI[i]);
        }

        return maxProfit;
    }
}
