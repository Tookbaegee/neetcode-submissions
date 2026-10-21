public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        var s1CharCount = new Dictionary<char, int>();
        var l = 0;
        var r = 0;

        for (var i = 0 ; i < s1.Length; i++)
        {
            s1CharCount[s1[i]] = s1CharCount.ContainsKey(s1[i]) ? s1CharCount[s1[i]] + 1 : 1;
        }

        while (r < s2.Length && l <= r)
        {
            if (s1CharCount.ContainsKey(s2[r]) && s1CharCount[s2[r]] > 0)
            {
                s1CharCount[s2[r]]--;

                if (r - l + 1 == s1.Length)
                {
                    return true;
                }

                r++;
            }
            else
            {
                // if (s1CharCount.ContainsKey(s2[r]))
                // {
                //     s1CharCount[s2[l]]++;
                //     l++;
                // }
                // else
                // {
                    // while (l <= r)
                    // {
                if (s1CharCount.ContainsKey(s2[l]))
                {
                    s1CharCount[s2[l]]++;
                }
                else
                {
                    r++;
                }
                l++;

                
                    // }
                // }
            }
        }

        return false;
    }
}
