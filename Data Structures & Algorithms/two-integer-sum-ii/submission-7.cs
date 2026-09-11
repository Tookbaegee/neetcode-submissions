public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        // since the array is sorted, we can slide right pointer to left to make the sum smaller and slide the left pointer to the right to make the sum larger
        var i = 0;
        var j = numbers.Length - 1;

        while (i < j)
        {
            var curSum = numbers[i] + numbers[j];
            if (curSum == target)
            {
                return [i+1, j+1];
            }
            if (curSum < target)
            {
                i++;
            }
            if (curSum > target)
            {
                j--;
            }
        }

        return [];
    }
}
