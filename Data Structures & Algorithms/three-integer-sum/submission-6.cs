public class Solution {
    private Dictionary<string, bool> dupMap = new Dictionary<string, bool>();

    public List<List<int>> ThreeSum(int[] nums) {
        var i = 0;
        var j = nums.Length - 1;

        var sortedNums = new List<int>(nums);
        sortedNums.Sort();
        
        List<List<int>> triplets = [];
        var prevNumK = 100001;
        for (var k = 0; k < nums.Length - 2; k++)
        {
            if (sortedNums[k] > 0)
            {
                break;
            }
            if (k > 0 && sortedNums[k] == sortedNums[k-1])
            {
                continue;
            }

            var target = 0 - sortedNums[k];
            i = k + 1;
            j = nums.Length - 1;
            var prevNumI = 100001;

            while (i < j)
            {
                var twoSum = sortedNums[i] + sortedNums[j];
                if (twoSum == target)
                {
                    List<int> triplet = [sortedNums[k], sortedNums[i], sortedNums[j]];
                    // var hash = GetTripletHash(triplet);
                    // if (!dupMap.ContainsKey(hash))
                    // {
                    prevNumI = sortedNums[i];
                    triplets.Add(triplet);
                    // dupMap.Add(hash, true);
                    // }
                    i++;
                    j--;
                    while (i < j && sortedNums[i] == sortedNums[i - 1])
                    {
                        i++;
                    }
                }
                else if (twoSum < target)
                {
                    i++;
                }
                else if (twoSum > target)
                {
                    j--;
                }
            }
            prevNumK = sortedNums[k];
        }
        return triplets;
    }

    // public static string GetTripletHash (List<int> triplet)
    // {
    //     triplet.Sort();
    //     return triplet.Aggregate(new StringBuilder(), (sb, x) => sb.Append(x.ToString()), sb => sb.ToString());
    // }
}
