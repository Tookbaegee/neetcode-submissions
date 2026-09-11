public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {

        var numWindows = nums.Length - k + 1;
        var q = new LinkedList<int>();

        var l = 0;
        var output = new int[nums.Length - k + 1];

        for (var r = 0; r < nums.Length; r++)
        {
            while (q.Count() > 0 && nums[r] > nums[q.Last.Value])
            {
                q.RemoveLast();
            }
            q.AddLast(r);

            //  l     r 
            // -8 7 5 7 1 6 0
            // secondMax[l] = 7 
            // instead of just maintaining maxInWindow, we need to maintain a sorted index (queue) within the window 
            // or maintain leftMax & rightMax for each [i] - then we do the larger of 

            if (r - l + 1 == k && l <= r)
            {
                output[l] = nums[q.First.Value];
                if (l == q.First.Value)
                {
                    q.RemoveFirst();
                }
                l++;
            }
        }

        return output;
    }
}
