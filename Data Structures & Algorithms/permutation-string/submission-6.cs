public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        // for char instead of dictionary we can do alphabet freq array esp forced to a case
        // var s1CharCount = new Dictionary<char, int>();
        var s1CharCount = new int[26];
        var s2CharCount = new int[26];

        for (var i = 0; i < 26; i++)
        {
            s1CharCount[i] = 0;
            s2CharCount[i] = 0;
        }

        var windowLength = s1.Length;

        if (s1.Length > s2.Length)
        {
            return false;
        }

        var l = 0;   
        var r = 0;

        for (var i = 0 ; i < s1.Length; i++)
        {
            s1CharCount[charToIndex(s1[i])]++;
        }

        // window boot
        while (r < windowLength)
        {
            s2CharCount[charToIndex(s2[r])]++;
            r++;
        }

        if (checkMatch(s1CharCount, s2CharCount))
        {
            return true;
        }

        while (r < s2.Length)
        {
            s2CharCount[charToIndex(s2[l])]--;
            l++;

            s2CharCount[charToIndex(s2[r])]++;
            r++;

            if (checkMatch(s1CharCount, s2CharCount))
            {
                return true;
            }
        }


        return false;
    }

    public static bool checkMatch(int[] charCount1, int[] charCount2)
    {
        for (var i = 0; i < 26; i++)
        {
            if (charCount1[i] != charCount2[i])
            {
                return false;
            }
        }
        
        return true;
    }

    public static int charToIndex(char c)
    {
        return c >= 'a' && c <= 'z' ? c - 97 : throw new ArgumentException("char out of bound");
    }
}
