public class Solution {
    public int ClimbStairs(int n) {     
        var cache = new int[n];
        return this.Climb(n, 0, cache);
    }

    public int Climb(int n, int i, int[] cache)
    {
        if (i == n)
        {
            return 1;
        }
        if (i > n)
        {
            return 0;
        }

        if (cache[i] != 0)
        {
            return cache[i];
        }

        var ways = Climb(n, i + 1, cache) + Climb(n, i + 2, cache);

        cache[i] = ways;
        return ways;
    }
}
