public class Solution {

    Dictionary<(int, int), bool> both = new();

    public List<List<int>> PacificAtlantic(int[][] heights) {
        if (heights.Length == 0 || heights[0].Length == 0) {
            return [];
        }

        Dictionary<(int, int), bool> pacific = new();
        Dictionary<(int, int), bool> atlantic = new();
        var res = new List<List<int>>();
        // we'll try starting from the edges and making the way
        // do pacific first and as we do atlantic look up pacific if true we mark both

        // pacific

        for (var x = 0; x < heights[0].Length; x++) {
            this.DFS(heights, 0, x, 0, pacific, atlantic);
        }
        for (var y = 0; y < heights.Length; y++)
        {
            this.DFS(heights, y, 0, 0, pacific, atlantic);
        }


        //atlantic

        for (var x = 0; x < heights[0].Length; x++) {
            this.DFS(heights, heights.Length - 1, x, 0, atlantic, pacific);
        }
        for (var y = 0; y < heights.Length; y++)
        {
            this.DFS(heights, y, heights[0].Length - 1, 0, atlantic, pacific);
        }

        foreach (var (x, y) in this.both.Keys)
        {
            res.Add(new List<int> { y, x });
        }

        return res;
    }

    // we don't need to backtrack here since the water flows from greater height to less
    public void DFS(int[][] heights, int y, int x, int prevHeight,
                    Dictionary<(int, int), bool> ocean, Dictionary<(int, int), bool> otherOcean) {
        // base condition should be the differentiator
        if (y < 0 || x < 0 || y >= heights.Length || x >= heights[y].Length) {
            return;
        }

        var h = heights[y][x];

        if (ocean.ContainsKey((x, y))) {
            return;
        }

        if (prevHeight > h) {
            return;
        }

        ocean[(x, y)] = true;
        if (otherOcean.ContainsKey((x,y)))
        {
            this.both[(x, y)] = true;
        }

        heights[y][x] = 1001;
        this.DFS(heights, y - 1, x, h, ocean, otherOcean);
        this.DFS(heights, y, x - 1, h, ocean, otherOcean);
        this.DFS(heights, y + 1, x, h, ocean, otherOcean);
        this.DFS(heights, y, x + 1, h, ocean, otherOcean);
        heights[y][x] = h;

    }
}
