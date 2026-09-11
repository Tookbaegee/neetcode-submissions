public class Solution {
    public int LengthOfLongestSubstring(string s) {

        var dupMap = new Dictionary<char, int>();

        var maxLength = 0;
        var l = 0;
        // we can keep left pointer l instead of calculating length & offsets based on i
        for (var r = 0; r < s.Length; r++)
        {
            if (dupMap.ContainsKey(s[r]))
            {
                l = Math.Max(dupMap[s[r]] + 1, l);
                dupMap[s[r]] = r;

            }
            else
            {
                dupMap.Add(s[r], r);
            }

            maxLength = Math.Max(maxLength, r - l + 1);
        }
        return maxLength;
    }
}
