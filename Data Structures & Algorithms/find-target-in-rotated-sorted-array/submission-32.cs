public class Solution {
    public int Search(int[] nums, int target) {
        var l = 0;
        var r = nums.Length - 1;

        // find the deflection point for the rotation
        // then we can do binary on the two segments
        while (l <= r)
        {
            var mid = (l + r) / 2;

            if (target == nums[mid])
            {
                return mid;
            }
            // mid is in the left of the deflection so move right
            // why can't we compare against nums[l]?
            // because once we are in the right side, l can no longer be the indicator to tell if new mid belongs to left or right segments
            if (nums[mid] > nums[r])
            {
                // since mid is in the left segment and target is greater than mid, target has to be greater than r so we move right on left
                if (target > nums[mid] || target < nums[l])
                {
                    // trivial we look for target in the right side
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
                // // 
                // if (target > nums[mid] && target < nums[l])
                // {
                //     // will never end up here since target is always greater than r if mid is greater than r
                //     return -999;
                // }

                // // target is less tham mid and target is greater than r so target must be on the left segment
                // if (target < nums[mid] && target > nums[r])
                // {
                //     r = mid - 1;
                // }
                // // target is less than mid and target is less than l so target must be on the right
                // if (target < nums[mid] && target < nums[l])
                // {
                //     l = mid + 1;
                // }
            }
            // mid is in the right of the deflection point
            else
            {
                // mid was less than r so if target is less than mid target is less than r
                // so it must be on the left of mid
                if (target < nums[mid] || target > nums[r])
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
                // if (target < nums[mid] && target > nums[l])
                // {
                //     // never enters here
                //     return -999;
                // }
                // // mid was less than r and if target is greater than m but less than r, must be between so look right
                // if (target > nums[mid] && target < nums[l])
                // {
                //     l = mid + 1;
                // }
                // // it's going to be on the left segment so look left of mid
                // if (target > nums[mid] && target > nums[r])
                // {
                //     r = mid - 1;
                // }
            }
        }

        return -1;
    }
}
