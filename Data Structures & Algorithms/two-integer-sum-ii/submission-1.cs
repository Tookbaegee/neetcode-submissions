public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var twoSums = new Dictionary<int, int>();

        for (var i = 0; i < numbers.Length; i++)
        {
            if (twoSums.ContainsKey(numbers[i]) && twoSums[numbers[i]] != i)
            {
                var complementIndex = twoSums[numbers[i]];
                return complementIndex > i ? [i + 1, complementIndex + 1] : [complementIndex + 1, i + 1];
            }
            else
            {
                if(!twoSums.ContainsKey(target - numbers[i]))
                {
                    twoSums.Add(target - numbers[i], i);
                }
            }
        }

        return [];
    }
}
