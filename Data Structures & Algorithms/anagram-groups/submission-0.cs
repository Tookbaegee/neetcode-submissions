public class Solution {


    public List<List<string>> GroupAnagrams(string[] strs) {

        var charCountHashes = new Dictionary<string, List<int>>();
        for (var i = 0; i < strs.Length; i++)
        {
            var hash = GetCharCountHashForIndex(strs[i]);
            if (charCountHashes.ContainsKey(hash))
            {
                charCountHashes[hash].Add(i);
            }
            else
            {
                charCountHashes[hash] = new List<int>();
                charCountHashes[hash].Add(i);
            }
        }

        var groupedAnagram = GetGroupedAnagrams(strs, charCountHashes);

        return groupedAnagram;
    }

    // method 1 - by hashing using sorted kvp (a1h1t1)

    public static string GetCharCountHashForIndex(string s)
    {
        var charCounts = new Dictionary<char, int>();

        for (var i = 0; i < s.Length; i++)
        {
            if (charCounts.ContainsKey(s[i]))
            {
                charCounts[s[i]]++;
            }
            else {
                charCounts[s[i]] = 1;
            }
        }

        var sb = new StringBuilder();
        
        foreach(var kvp in charCounts.OrderBy(kvp => kvp.Key))
        {
            sb.Append($"{kvp.Key}{kvp.Value}");
        }

        return sb.ToString();
    }

    public static List<List<string>> GetGroupedAnagrams(string[] strs, Dictionary<string, List<int>> charCountHashes)
    {
        var groupedAnagrams = new List<List<string>>();
        foreach(var kvp in charCountHashes)
        {
            var group = new List<string>();

            foreach(var index in kvp.Value)
            {
                group.Add(strs[index]);
            }

            groupedAnagrams.Add(group);
        }

        return groupedAnagrams;
    }
}
