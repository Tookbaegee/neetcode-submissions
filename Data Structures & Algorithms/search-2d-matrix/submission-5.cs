public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        var m = matrix.Length;
        var n = matrix[0].Length;

        return this.SearchMatrixBinary(matrix, target, 0, n * m - 1);
    }

    public bool SearchMatrixBinary(int[][] matrix, int target, int start, int end) {
        // we can do some modular arithmetic
        // we need to know the offset we go left or right translated to rowStart & rowEnd
        // we can use start as the offset from m (starts at [rowStart][start])
        // and end as the offset from n (ends at [rowEnd][end])

        // let's start with total length

        //// instead of tracking rowStart & rowEnd & colStart & colEnd, just use 1d index, we are
        ///running through na imaginary 1d array
        var totalLength = end - start + 1;

        var mid = start + (totalLength / 2);
        var m = matrix.Length;
        var n = matrix[0].Length;

        if (start > m * n - 1 || end < 0) {
            return false;
        }

        var mCol = mid % n;
        var mRow = mid / n;

        if (target == matrix[mRow][mCol]) {
            return true;
        }

        if (totalLength < 2) {
            return false;
        }

        if (target < matrix[mRow][mCol]) {
            return SearchMatrixBinary(matrix, target, start, mid - 1);

        } else {
            return SearchMatrixBinary(matrix, target, mid + 1, end);
        }
    }
}
