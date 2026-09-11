public class Solution {

    public string Encode(IList<string> strs) {
        var sb = new StringBuilder();
        foreach (var str in strs.ToList())
        {
            // can't do str.Length + '#' (char) since int + char = int resolved first which ends up being 40
            sb.Append(str.Length + "#" + str);
            // sb.Append($"{str.Length}#{str}");
        }

        return sb.ToString();
    }

    public List<string> Decode(string s) {
        var i = 0;
        var strs = new List<string>();
        var wordLengthString = "";
        while (i < s.Length)
        {
            if (s[i] == '#')
            {
                var wordLength = int.Parse(wordLengthString);
                var decodedWord = s.Substring(i + 1, wordLength);
                strs.Add(decodedWord);
                i += wordLength + 1;
                wordLengthString = "";
            }
            else
            {
                wordLengthString += s[i];
                i++;
            }
        }

        return strs;
    }
}
