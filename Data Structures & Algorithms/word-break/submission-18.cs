public class Solution {
    TrieNode root = new TrieNode();

    public bool WordBreak(string s, List<string> wordDict) {
        if (s.Length == 0 || wordDict.Count() == 0)
        {
            return false;
        }
        this.BuildTrie(wordDict);

        // max length helps cut down the heuristic by us only iterating s at i up to the maximum word length
        // or till the end of the word, whatever is shorter
        int maxLen = 0;
        foreach (string word in wordDict) {
            maxLen = Math.Max(maxLen, word.Length);
        }

        // here we can use bool array since we can assume default false as not reachable
        var dp = new bool[s.Length + 1];
        dp[s.Length] = true;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            for (var j = i; j < Math.Min(s.Length, i + maxLen); j++)
            {
                if (SearchTrie(s[i..(j + 1)]))
                {
                    // j + 1 since it's by the length of the word
                    dp[i] = dp[j + 1];
                    if (dp[i])
                    {
                        break;
                    }
                }
            }
        }

        return dp[0];
    }

    public bool SearchTrie(string word)
    {
        var node = root;
        for (var i = 0; i < word.Length; i++)
        {
            if (!node.HasChild(word[i]))
            {
                return false;
            }

            node = node.GetChild(word[i]);
        }

        return node.eof;
    }

    public void BuildTrie(List<string> wordDict)
    {
        foreach (var word in wordDict)
        {
            var node = root;
            for (var i = 0; i < word.Length; i++)
            {
                if (!node.HasChild(word[i]))
                {
                    var child = new TrieNode(word[i], i == word.Length - 1);
                    node.AddChild(child);
                }
                node = node.GetChild(word[i]);
            }
            node.eof = true;
        }
    }
}

// s and wordDict[i] consist of only lowercase English letters.
public class TrieNode
{
    public char val;
    public TrieNode[] children = new TrieNode[26];
    public bool eof;

    public TrieNode()
    {
        val = ' ';
        eof = false;
    }

    public TrieNode(char val, bool eof)
    {
        this.val = val;
        this.eof = eof;
    }

    public void AddChild(TrieNode child)
    {
        this.children[child.val - 'a'] = child;
    }

    public TrieNode GetChild(char val)
    {
        return this.children[val - 'a'];
    }

    public bool HasChild(char val)
    {
        return this.children[val - 'a'] != null;
    }
}
