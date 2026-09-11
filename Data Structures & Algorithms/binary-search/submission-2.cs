public class Solution {
    public int Search(int[] nums, int target) {
        // nums come sorted in ascending
        // split in middle - binary
        var found = -1;
        var m = nums.Length / 2;
        var start = 0;
        var end = nums.Length - 1;
        // 0 1 2 3 4 5
        // 0 1
        while (found == -1 && end >= 0 && start < nums.Length) {
            var curLength = end - start + 1;

            if (curLength == 1) {
                if (nums[start] == target) {
                    found = start;
                }
                break;
            } else {
                m = start + (curLength / 2);

                if (nums[m] > target) {
                    end = m - 1;
                } else if (nums[m] < target) {
                    start = m + 1;
                } else {
                    found = m;
                }
            }
        }

        return found;
    }
}
