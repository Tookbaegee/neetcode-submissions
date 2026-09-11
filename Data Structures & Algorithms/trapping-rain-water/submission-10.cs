public class Solution {
    // try prefix & suffix
    public int Trap(int[] height) {
        if (height.Length == 0)
        {
            return 0;
        }

        var leftMax = new int[height.Length];
        var rightMax = new int[height.Length];

        leftMax[0] = height[0];
        // look back to left as we progress right
        for (var i = 1; i < leftMax.Length; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
        }

        rightMax[rightMax.Length - 1] = height[height.Length - 1];
        for (var j = rightMax.Length - 2; j >= 0; j--)
        {
            rightMax[j] = Math.Max(rightMax[j + 1], height[j]);
        }

        var totalArea = 0;
        for (var i = 0; i < height.Length; i++)
        {
            totalArea += Math.Min(leftMax[i], rightMax[i]) - height[i];
        }

        return totalArea;
    }
}
