public class Solution {
    public int CountSubstrings(string s) {
        if (s.Length == 0)
        {
            return 0;
        }
        if (s.Length == 1)
        {
            return 1;
        }

        var res = 0;
        var dp = new bool[s.Length, s.Length];
        // every individual character is a palindome
        // dp[left, right]
        for (var i = 0; i < s.Length; i++)
        {
            dp[i, i] = true;
            res++;
        }

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
                    if (subLength <= 3 || dp[left + 1, right - 1])
                    {
                        res++;
                        dp[left, right] = true;
                    }
                }
            }
        }

        return res;

    }
}
