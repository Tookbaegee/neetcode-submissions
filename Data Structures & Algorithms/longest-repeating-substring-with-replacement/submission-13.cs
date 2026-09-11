public class Solution {
    public int CharacterReplacement(string s, int k) {
        var l = 0;
        var r = 0;
        //
        var maxLength = 0;
        var charCount = new Dictionary<char, int>();
        // var lForChar = new Dictionary<char, int>();
        var mostFreqChar = s[0];
        while (r < s.Length) {
            charCount[s[r]] = charCount.ContainsKey(s[r]) ? charCount[s[r]] + 1 : 1;

            mostFreqChar = charCount[s[r]] > charCount[mostFreqChar] ? s[r] : mostFreqChar;
            // if (!lForChar.ContainsKey(s[r])) {
            //     lForChar[s[r]] = r;
            // }

            var gap = r - l + 1 - charCount[mostFreqChar];
            if (gap <= k) {
                maxLength = Math.Max(maxLength, r - l + 1);
            } else {
                charCount[s[l]]--;
                l++;
            }

            r++;
        }

        return maxLength;
    }
}
