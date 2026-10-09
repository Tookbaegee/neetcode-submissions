public class Solution {
    private bool found = false;
    public bool Exist(char[][] board, string word) {
        if (board.Length == 0 || board[0].Length == 0) {
            return false;
        }
        for (var j = 0; j < board.Length; j++)
        {
            for (var i = 0; i < board[0].Length; i++)
            {
                this.TraverseBoard(board, word, i, j, 0, new Dictionary<(int, int), bool>());
            }
        }

        return found;
    }

    public void TraverseBoard(char[][] board, string word, int x, int y, int strIdx, Dictionary<(int, int), bool> visited) {
        // since base condition we already incremented on the match as we recurse match on length all char must 
        // have matched
        if (strIdx == word.Length)
        {
            found = true;
            return;
        }

        // match case could go out of bound - take guard below the match base case
        if (y >= board.Length || x >= board[0].Length || x < 0 || y < 0) {
            return;
        }

        if (visited.ContainsKey((x, y)))
        {
            return;
        }

        // we need to be able to skip it so the current word is not considered
        // but we onnly skip if concat is empty string, once the word starts to form we can't skip.
        // problem of skipping - makes it hard to track what's really visited vs. skipped.
        // also if there's a starting character that can't be used to progress, skipping will halt and won't cover 
        // the entire space. so instead use 2D for loops to start from each cell.
    
        // if (strIdx == 0 && word[strIdx] != board[y][x] ) {
        //     // down
        //     TraverseBoard(board, word, x, y + 1, strIdx, visited);
        //     // right
        //     TraverseBoard(board, word, x + 1, y, strIdx, visited);

        //     return;
        // }

        // match condition here is essential if we choose to use skip instead 
        if (word[strIdx] == board[y][x])
        {
    // we have option to go up, down, left, right
            visited[(x, y)] = true;
            // current problem is we are covering duplicate spaces - once the space is visited we cannot go back.
            // keep hashmap and backtrack as well with concat

            // up
            TraverseBoard(board, word, x, y - 1, strIdx + 1, visited);
            // visited.Remove((x, y - 1));
            // down
            TraverseBoard(board, word, x, y + 1, strIdx + 1, visited);
            // visited.Remove((x, y + 1));
            // left
            TraverseBoard(board, word, x - 1, y, strIdx + 1, visited);
            // visited.Remove((x - 1, y));
            // right
            TraverseBoard(board, word, x + 1, y, strIdx + 1, visited);
            // visited.Remove((x + 1, y));
            visited.Remove((x, y));
        }
    }
}
