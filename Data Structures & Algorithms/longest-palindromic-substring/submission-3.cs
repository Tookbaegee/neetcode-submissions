public class Solution {
    public string LongestPalindrome(string s) {
        if (s.Length == 0)
        {
            return "";
        }
        if (s.Length == 1)
        {
            return s;
        }

        var dp = new bool[s.Length, s.Length];
        // every individual character is a palindome
        // dp[left, right]
        for (var i = 0; i < s.Length; i++)
        {
            dp[i, i] = true;
        }


        var longestSubStart = 0;
        var longestSubLength = 1;

        for (var subLength = 2; subLength <= s.Length; subLength++)
        {
            for (var left = 0; left + subLength <= s.Length; left++)
            {
                var right = left + subLength - 1;

                // outer ends matched
                if (s[left] == s[right])
                {
                    // inner was also palindrome
                    // if substring length is less than 3, inner is trivially palindrome
                    if (subLength < 3 || dp[left + 1, right - 1])
                    {
                        dp[left, right] = true;
                    }
                }

                if (dp[left, right] && subLength > longestSubLength)
                {
                    longestSubStart = left;
                    longestSubLength = subLength;
                }
            }
        }

        return s.Substring(longestSubStart, longestSubLength);

    }
}
