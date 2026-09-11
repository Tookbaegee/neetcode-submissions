public class Solution {
    public int LongestConsecutive(int[] nums) {
        var sortedNums = new List<int>(nums);
        sortedNums.Sort();

        // next expected sequence element as key, length as int
        var streaksLength = new Dictionary<int, int>();

        for (var i = 0; i < sortedNums.Count(); i++) {
            if (!streaksLength.ContainsKey(sortedNums[i] + 1)) {
                if (streaksLength.ContainsKey(sortedNums[i])) {
                    streaksLength.Add(sortedNums[i] + 1, streaksLength[sortedNums[i]] + 1);
                } else {
                    streaksLength.Add(sortedNums[i] + 1, 1);
                }
            }
        }

        return streaksLength.OrderBy(kvp => kvp.Value).Reverse().FirstOrDefault().Value;
    }
}
