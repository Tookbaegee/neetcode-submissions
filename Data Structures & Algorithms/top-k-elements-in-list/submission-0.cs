public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {

        // key - num, value - count => T = O(nlog(n)) S = O(n)
        var charCount = new Dictionary<int, int>();
        // n
        for (var i = 0; i < nums.Length; i++)
        {
            if (charCount.ContainsKey(nums[i]))
            {
                charCount[nums[i]]++;
            }
            else
            {
                charCount[nums[i]] = 1;
            }
        }

        // nlog(n)
        var sortedCharCount = charCount.OrderBy(x => x.Value).Reverse();

        // k <= n
        var ans = new List<int>();

        var en = sortedCharCount.GetEnumerator();

        while(en.MoveNext() && k > 0)
        {
            ans.Add(en.Current.Key);
            k--;
        }

        return ans.ToArray();
    }
}
