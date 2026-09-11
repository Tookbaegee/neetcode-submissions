public class Solution {
    public int Search(int[] nums, int target) {
        var l = 0;
        var r = nums.Length - 1;

        // find the deflection point for the rotation
        // then we can do binary on the two segments
        while (l < r)
        {
            var mid = (l + r) / 2;

            // mid is in the left of the deflection so move right
            // why can't we compare against nums[l]?
            // because once we are in the right side, l can no longer be the indicator to tell if new mid belongs to left or right segments
            if (nums[mid] > nums[r])
            {
                l = mid + 1;
            }
            // mid is in the right of the deflection point so move left (mid inclusive since we don't do mid checks)
            else
            {
                r = mid;   
            }
        }

        var pivot = l;
        l = 0;
        r = nums.Length - 1;

        if (target >= nums[pivot] && target <= nums[r])
        {
            l = pivot;
        }
        else
        {
            r = pivot - 1;
        }

        while (l <= r)
        {
            var m = (l + r) / 2;

            if (nums[m] == target)
            {
                return m;
            }
            
            if (nums[m] > target)
            {
                r = m - 1;
            }
            else
            {
                l = m + 1;
            }
        }

        return -1;
    }
}
