public class Solution {
    public int ClimbStairs(int n) {     
        var cache = new int[n];

        return this.Climb(n, cache);
    }

    public int Climb(int i, int[] cache)
    {
        if (i < 0)
        {
            return 0;
        }

        if (i == 0 || i == 1)
        {
            return 1;
        }

        if (cache[i - 1] != 0)
        {
            return cache[i - 1];
        }

        cache[i - 1] = this.Climb(i - 1, cache) + this.Climb(i - 2, cache);

        return cache[i - 1];
    }
}
