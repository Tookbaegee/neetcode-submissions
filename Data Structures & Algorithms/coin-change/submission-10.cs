public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if (amount == 0)
        {
            return 0;
        }

        var cache = new Dictionary<long, int>();

        var numCoins = this.TopDown(coins, amount, 0, cache);

        return numCoins > 0 ? numCoins : -1;
    }

    // probably better with bottom up
    public int TopDown(int[] coins, int amount, long sum, Dictionary<long, int> cache)
    {
        if (sum > amount)
        {
            return -1;
        }

        if (sum == amount)
        {
            return 0;
        }

        if (cache.ContainsKey(sum))
        {
            return cache[sum];
        }

        // returns # of coins
        var min = int.MaxValue;
        foreach (var coin in coins)
        {
            var numCoin = TopDown(coins, amount, sum + coin, cache);
            if (numCoin >= 0)
            {
                min = Math.Min(numCoin, min);
            }
        }

        cache[sum] = min != int.MaxValue ? 1 + min : -1;
        return cache[sum];
    }
}
