public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        return TopKFrequentByCountAsGroupHash(nums, k);
    }

    public int[] TopKFrequentByCountAsGroupHash(int[] nums, int k)
    {
        // key - num, value - count => T = O(nlog(n)) S = O(n)
        var charCount = new Dictionary<int, int>();
        // key - count, value - groups of nums => 
        var countGroup = new Dictionary<int, Dictionary<int, bool>>();

        // n
        for (var i = 0; i < nums.Length; i++)
        {
            if (!charCount.ContainsKey(nums[i]))
            {
                charCount[nums[i]] = 0;
            }
            
            var newCount = charCount[nums[i]] + 1;
            charCount[nums[i]] = newCount;

            if (!countGroup.ContainsKey(newCount))
            {
                countGroup[newCount] = new Dictionary<int, bool>();
            }
            countGroup[newCount].Add(nums[i], true);
            if (countGroup.ContainsKey(newCount - 1))
            {
                countGroup[newCount - 1].Remove(nums[i]);
            }
        }


        // nlog(n) - let's see if we can avoid sorting
        // var sortedCharCount = charCount.OrderBy(x => x.Value).Reverse();
        // var en = sortedCharCount.GetEnumerator();

        // now with countGroups

        // k <= n
        var ans = new List<int>();

        var en = countGroup.Reverse().GetEnumerator();

        while(en.MoveNext() && k > 0)
        {
            var groupEn = en.Current.Value.GetEnumerator();
            while(groupEn.MoveNext() && k > 0)
            {
                ans.Add(groupEn.Current.Key);
                k--;
            }
        }

        return ans.ToArray();
    }

public int[] TopKFrequentByNumAsKey(int[] nums, int k)
    {
        // key - num, value - count => T = O(nlog(n)) S = O(n)
        var charCount = new Dictionary<int, int>();

        // n
        for (var i = 0; i < nums.Length; i++)
        {
            if (!charCount.ContainsKey(nums[i]))
            {
                charCount[nums[i]] = 0;
            }
            
            charCount[nums[i]]++;
        }

        // nlog(n) sorting
        var sortedCharCount = charCount.OrderBy(x => x.Value).Reverse();
        var en = sortedCharCount.GetEnumerator();

        // k <= n
        var ans = new List<int>();

        while(en.MoveNext() && k > 0)
        {
            ans.Add(en.Current.Key);
        }

        return ans.ToArray();
    }

}
