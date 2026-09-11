public class Solution {
    public int LengthOfLongestSubstring(string s) {

        var dupMap = new Dictionary<char, int>();

        var maxLength = 0;
        var l = 0;
        // we can slide the dupMap - if the next char is dup while we expand on dup map, the duplicate will be at the beginning of the sequence guaranteed (since dupMap[s[r-1]] did not collide)
        for (var r = 0; r < s.Length; r++)
        {
            while (dupMap.ContainsKey(s[r]))
            {
                dupMap.Remove(s[l]);
                l++;
            }

            dupMap.Add(s[r], r);
            maxLength = Math.Max(maxLength, r - l + 1);
        }
        return maxLength;
    }
}
