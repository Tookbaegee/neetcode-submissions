public class Solution {
    public int[][] Merge(int[][] intervals) {

        var res = new List<int[]>();

        Array.Sort(intervals, (interval1, interval2) => interval1[0] - interval2[0]);
        var mStart = intervals[0][0];
        var mEnd = intervals[0][1];
        for (var i = 0; i < intervals.Length; i++)
        {
            var start = intervals[i][0];
            var end = intervals[i][1];
            // end was after mStart
            if (end >= mStart && start <= mEnd)
            {
                mStart = Math.Min(mStart, start);
                mEnd = Math.Max(mEnd, end);
            }
            // start is greater than mEnd
            // or end is less than mStart 
            // so insert the merged interval and start a new merge interval
            else
            {
                res.Add(new int[] { mStart, mEnd });
                mStart = start;
                mEnd = end;
            }
        }

        res.Add(new int[] { mStart, mEnd });


        return res.ToArray();
    }
}
