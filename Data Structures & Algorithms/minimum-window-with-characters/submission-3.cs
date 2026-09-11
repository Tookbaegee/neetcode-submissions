public class Solution {
    public string MinWindow(string s, string t) {
        
        if (s.Length == 0)
        {
            return "";
        }

        var tCharCount = new Dictionary<char, int>();
        var wCharCount = new Dictionary<char, int>();


        for (var i = 0; i < t.Length; i++)
        {
            tCharCount[t[i]] = tCharCount.ContainsKey(t[i]) ? tCharCount[t[i]] + 1 : 1;
        }

        var l = 0;
        var r = 0;
        
        var minimumLength = int.MaxValue;
        var minL = 0;
        var have = 0;
        var need = tCharCount.Count();

        while (r < s.Length)
        {
            wCharCount[s[r]] = wCharCount.ContainsKey(s[r]) ? wCharCount[s[r]] + 1 : 1;

            if (tCharCount.ContainsKey(s[r]) && wCharCount[s[r]] == tCharCount[s[r]])
            {
                have++;
            }

            while (have == need)
            {
                if (minimumLength > r - l + 1)
                {
                    minimumLength = r - l + 1;
                    minL = l;
                }
            
                if (wCharCount.ContainsKey(s[l]))
                {
                    wCharCount[s[l]]--;
                    if (tCharCount.ContainsKey(s[l]) && wCharCount[s[l]] < tCharCount[s[l]])
                    {
                        have--;
                    }
                }
                l++;
            }

            r++;
        }

        return minimumLength != int.MaxValue ? s.Substring(minL, minimumLength) : "";
    }

    // public static int charToIndex(char c)
    // {
    //     return c >= 'a' && c <= 'z' ? c - 'a' + 26 : c - 'A';
    // }

    // public static bool sHasEveryT(int[] sCharCount, int[] tCharCount)
    // {
    //     var hasEveryT = true;
    //     for (var i = 0; i < 52; i++)
    //     {
    //         if (tCharCount[i] > 0)
    //         {
    //             hasEveryT &= sCharCount[i] > 0;
    //         }
    //     }

    //     return hasEveryT;
    // }
}
