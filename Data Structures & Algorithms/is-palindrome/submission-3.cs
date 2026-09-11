public class Solution {
    public bool IsPalindrome(string s) {
        var i = 0;
        var j = s.Length -1;

        while (i <= j)
        {
            while(!Regex.IsMatch(s[i].ToString(), @"^[a-zA-Z0-9]+$") && i < s.Length - 1)
            {
                i++;
            }

            while (!Regex.IsMatch(s[j].ToString(), @"^[a-zA-Z0-9]+$") && j > 0)
            {
                j--;
            }

            if (i < j && s[i].ToString().ToUpper() != s[j].ToString().ToUpper())
            {
                return false;
            }

            i++;
            j--;
        }
        return true;
    }
}
