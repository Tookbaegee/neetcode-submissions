public class Solution {
    public bool WordBreak(string s, List<string> wordDict) {
        if (s.Length == 0 || wordDict.Count() == 0)
        {
            return false;
        }

        var cache = new Dictionary<int, bool>();

        return this.TopDown(s, wordDict, 0, cache);
    }

    public bool TopDown (string s, List<string> wordDict, int i, Dictionary<int, bool> cache)
    {
        if (i == s.Length)
        {
            return true;
        }

        if (cache.ContainsKey(i))
        {
            return cache[i];
        }

        var broke = false;

        foreach (var word in wordDict)
        {
            if (i + word.Length <= s.Length && s[i..(i + word.Length)] == word)
            {
                broke = broke || TopDown(s, wordDict, i + word.Length, cache);
            }
        }

        cache[i] = broke;

        return broke;
    }
}
