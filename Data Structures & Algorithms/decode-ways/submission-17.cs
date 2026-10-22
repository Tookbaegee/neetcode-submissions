public class Solution {
    public int NumDecodings(string s) {
        var cache = new int[s.Length];
        for (var i = 0; i < cache.Length; i++)
        {
            cache[i] = -1;
        }

        return this.DFS(s, 0, cache);
    }

    // there are two branching decisions
    // one is when we take 1 digit
    // two is when we take 2 digits

    // we can only take 2 digits if:
    // leading character is not 0 (so if the leaded character is 0 we must take 2)
    public int DFS(string s, int i, int[] cache)
    {
        if (i > s.Length)
        {
            return 0;
        }

        if (i == s.Length)
        {
            return 1;
        }

        if (s[i] == '0')
        {
            return 0;
        }

        if (cache[i] > -1)
        {
            return cache[i];
        }

        cache[i] = this.DFS(s, i + 1, cache);

        if (i + 2 <= s.Length && s[i..(i + 2)].CompareTo("26") <= 0)
        {
            cache[i] += this.DFS(s, i + 2, cache);
        }

        return cache[i];
    }
}
