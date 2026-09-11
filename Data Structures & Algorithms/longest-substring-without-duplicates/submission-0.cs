public class Solution {
    public int LengthOfLongestSubstring(string s) {

        var dupMap = new Dictionary<char, int>();

        var length = 0;
        var maxLength = 0;
        // we can slide the dupMap - if the next char is dup while we expand on dup map, the duplicate will be at the beginning of the sequence guaranteed (since dupMap[s[i-1]] did not collide)
        for (var i = 0; i < s.Length; i++)
        {
            if (dupMap.ContainsKey(s[i]))
            {
                for (var j = i - length; j < dupMap[s[i]]; j++)
                {
                    if (dupMap.ContainsKey(s[j]))
                    {
                        dupMap.Remove(s[j]);
                    }
                }

                length = i - dupMap[s[i]];
                dupMap[s[i]] = i;
            }
            else
            {
                dupMap.Add(s[i], i);
                length++;
            }
            maxLength = Math.Max(length, maxLength);
        }
        return maxLength;
    }
}
