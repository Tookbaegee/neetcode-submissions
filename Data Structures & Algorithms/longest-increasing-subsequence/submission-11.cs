public class Solution {
    public int LengthOfLIS(int[] nums) {
        var tails = new List<int>();

        foreach (int number in nums) {
            int left = 0;
            int right = tails.Count();

            while (left < right) {
                int middle = left + (right - left) / 2;

                if (tails[middle] < number) {
                    left = middle + 1;
                } else {
                    right = middle;
                }
            }

            if (left == tails.Count()) {
                tails.Add(number);
            } else {
                tails[right] = number;
            }
        }

        return tails.Count;
    }
}
