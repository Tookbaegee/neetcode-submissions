public class Solution {
    // bottom up
    public bool WordBreak(string s, List<string> wordDict) {
        if (s.Length == 0 || wordDict.Count() == 0)
        {
            return false;
        }

        // here we can use bool array since we can assume default false as not reachable
        var dp = new bool[s.Length + 1];
        dp[s.Length] = true;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            foreach (var word in wordDict)
            {
                if (i + word.Length <= s.Length && s[i..(i + word.Length)] == word)
                {
                    dp[i] = dp[i + word.Length];
                    if (dp[i])
                    {
                        break;
                    }
                }
            }
        }

        return dp[0];
    }
}
