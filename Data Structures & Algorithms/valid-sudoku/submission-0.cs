public class Solution {
    public bool IsValidSudoku(char[][] board) {
        // x index, value
        var dupRowMap = new Dictionary<(int, int), bool>();
        // x index, value
        var dupColMap = new Dictionary<(int, int), bool>();
        // x grid ref, y grid ref, value
        var dupSubBoxMap = new Dictionary<(int, int, int), bool>();

        var boardXLength = board.Length;
        var boardYLength = board[0].Length;

        for (var i = 0; i < boardXLength; i++)
        {
            for (var j = 0; j < boardYLength; j++)
            {
                var num = board[i][j];
                if (num == '.')
                {
                    continue;
                }
                if (dupRowMap.ContainsKey((i, num)))
                {
                    return false;
                }
                else
                {
                    dupRowMap.Add((i,num), true);
                }
                if (dupColMap.ContainsKey((j, num)))
                {
                    return false;
                }
                else
                {
                    dupColMap.Add((j,num), true);
                }
                if (dupSubBoxMap.ContainsKey((i / 3, j / 3, num)))
                {
                    return false;
                }
                else
                {
                    dupSubBoxMap[(i / 3, j / 3, num)] = true;
                }
            }
        }

        return true;
    }

}
