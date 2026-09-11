public class Solution {
    public bool IsAnagram(string s, string t) {
        var charCount = new Dictionary<char, int>();

        if (s.Length != t.Length)
        {
            return false;
        }

        var l = s.Length;
        for (var i = 0; i < l; i++)
        {
            if (charCount.ContainsKey(s[i]))
            {
                charCount[s[i]]++;
            }
            else
            {
                charCount[s[i]] = 1;
            }
        }

        for (var i = 0; i < l; i++)
        {
            if (charCount.ContainsKey(t[i]))
            {
                charCount[t[i]]--;
            }
            else
            {
                // when t contains a string that s doesn't have
                return false;
            }
        }

        return charCount.All(kvp => kvp.Value == 0);
    }
}
