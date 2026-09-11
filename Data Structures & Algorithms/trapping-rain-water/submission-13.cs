public class Solution {
    public int Trap(int[] height) {
        var l = 0;
        var r = height.Length - 1;

        var leftMax = height[0];
        var rightMax = height[height.Length - 1];

        var totalArea = 0;
        while (l < r)
        {
            if (leftMax < rightMax)
            {
                l++;
                leftMax = Math.Max(leftMax, height[l]);
                totalArea += leftMax - height[l];
            }
            else
            {
                r--;
                rightMax = Math.Max(rightMax, height[r]);
                totalArea += rightMax - height[r];
            }
        }

        return totalArea;
    }
}
