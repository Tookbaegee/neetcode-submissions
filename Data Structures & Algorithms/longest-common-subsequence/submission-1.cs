public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        // recurrence
        // i for index of text1, j for index of text2
        // if t1[i] != t2[j] we either move i on text 1 or j on text 2, see if char matches
        // if t1[i] == t2[j] we move both to right
        // dp[i, j] = Max(dp[i, j + 1], dp[i + 1, j]) || 1 + dp[i + 1, j + 1] if match
        // if (i == t1.Length || j == t2.Length) return 0;

        var cache = new Dictionary<(int, int), int>();

        return TopDownDFS(text1, text2, 0, 0, cache);
    }

    public int TopDownDFS(string t1, string t2, int i, int j, Dictionary<(int, int), int> cache)
    {
        if (i == t1.Length || j == t2.Length)
        {
            return 0;
        }

        if (cache.ContainsKey((i, j)))
        {
            return cache[(i, j)];
        }
        
        if (t1[i] == t2[j])
        {
            cache[(i, j)] = 1 + TopDownDFS(t1, t2, i + 1, j + 1, cache);

            return cache[(i, j)];
        }

        cache[(i, j)] = Math.Max(TopDownDFS(t1, t2, i + 1, j, cache), TopDownDFS(t1, t2, i, j + 1, cache));

        return cache[(i, j)];
    }

}
