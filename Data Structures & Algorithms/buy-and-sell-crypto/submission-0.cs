public class Solution {
    public int MaxProfit(int[] prices) {

        var maxAfterI = new Dictionary<int, int>();
        maxAfterI[prices.Length-1] = prices[prices.Length -1];

        var maxPrice = 0;
        for (var i = prices.Length - 2; i >= 0; i--)
        {
            maxAfterI[i] = Math.Max(prices[i], maxAfterI[i + 1]);

            maxPrice = Math.Max(maxPrice, maxAfterI[i] - prices[i]);
        }

        return maxPrice;
    }
}
