public class Solution {
    public int LargestRectangleArea(int[] heights) {
        // height, index
        var areaStack = new Stack<(int, int)>();

        var maxArea = 0;

        for (var i = 0; i < heights.Length; i++)
        {
            var start = i;
            while (areaStack.Count() > 0 && areaStack.Peek().Item1 > heights[i])
            {
                var (height, index) = areaStack.Pop();
                maxArea = Math.Max(maxArea, height * (i - index));
                start = index;
            }

            areaStack.Push((heights[i], start));
        }

        while (areaStack.Count() > 0)
        {
            var (cHeight, cIndex) = areaStack.Pop();

            maxArea = Math.Max(maxArea, cHeight * (heights.Length - cIndex));
            
        }
        return maxArea;
    }
}
