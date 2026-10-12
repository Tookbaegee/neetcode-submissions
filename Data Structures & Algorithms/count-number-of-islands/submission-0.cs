public class Solution {
    public int NumIslands(char[][] grid) {
        var found = 0;
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (this.DFS(grid, i, j))
                {
                    found++;
                }
            }
        }

        return found;
    }

    public bool DFS (char[][] grid, int y, int x)
    {
        if (y >= grid.Length || x >= grid[0].Length || y < 0 || x < 0 || grid[y][x] != '1')
        {
            return false;
        }

        grid[y][x] = '#';
        this.DFS(grid, y - 1, x);
        this.DFS(grid, y + 1, x);
        this.DFS(grid, y, x - 1);
        this.DFS(grid, y, x + 1);
        return true;
    }
}
