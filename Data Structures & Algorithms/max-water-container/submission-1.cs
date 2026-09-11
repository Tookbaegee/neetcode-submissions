public class Solution {
    public int MaxArea(int[] heights) {
        var i = 0;
        var j = heights.Length - 1;

        var maxArea = 0;

        // since further inwards we go, it reduces x, we need to check if moving in is worth from either side
        while (i < j)
        {
            var width = j - i;
            var height = Math.Min(heights[i], heights[j]);
            var curArea = width * height;

            maxArea = Math.Max(maxArea, curArea);

            // move i if heights[i] < heights[j] since it will definitely be smaller 
            if (heights[i] < heights[j])
            {
                i++;
                continue;
            }
            // shift left if moving j to left is a gain
            if (heights[i] >= heights[j])
            {
                j--;
                continue;
            }

            break;
        }

        return maxArea;
    }
}
