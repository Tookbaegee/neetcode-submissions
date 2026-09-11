public class Solution {
    private Dictionary<string, bool> dupMap = new Dictionary<string, bool>();

    public List<List<int>> ThreeSum(int[] nums) {
        var i = 0;
        var j = nums.Length - 1;

        var sortedNums = new List<int>(nums);
        sortedNums.Sort();
        
        List<List<int>> triplets = [];
        for (var k = 0; k < nums.Length - 2; k++)
        {
            var target = 0 - sortedNums[k];
            i = k + 1;
            j = nums.Length - 1;
            while (i < j)
            {
                var twoSum = sortedNums[i] + sortedNums[j];
                if (twoSum == target)
                {
                    List<int> triplet = [sortedNums[k], sortedNums[i], sortedNums[j]];
                    var hash = GetTripletHash(triplet);
                    if (!dupMap.ContainsKey(hash))
                    {
                        triplets.Add(triplet);
                        dupMap.Add(hash, true);
                    }
                    i++;
                    j--;
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
        }
        return triplets;
    }

    public static string GetTripletHash (List<int> triplet)
    {
        triplet.Sort();
        return triplet.Aggregate(new StringBuilder(), (sb, x) => sb.Append(x.ToString()), sb => sb.ToString());
    }
}
