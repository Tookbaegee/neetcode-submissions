public class Solution {
    public int UniquePaths(int m, int n) {
        // try 2D DP
        var cache = new Dictionary<(int, int), int>();

        return this.TopDownDFS(m, n, 0, 0, cache);
    }

    private int TopDownDFS(int m, int n, int x, int y, Dictionary<(int, int), int> cache)
    {
        if (y == m - 1 && x == n - 1)
        {
            return 1;
        }

        if (y > m - 1 || x > n - 1)
        {
            return 0;
        }

        // (y, x)
        if (cache.ContainsKey((y, x)))
        {
            return cache[(y, x)];
        }

        cache[(y, x)] = TopDownDFS(m, n, x + 1, y, cache) + TopDownDFS(m, n, x, y + 1, cache);

        return cache[(y, x)];
    }
}
